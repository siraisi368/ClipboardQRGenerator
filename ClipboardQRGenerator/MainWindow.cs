using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Toolkit.Uwp.Notifications;
using Newtonsoft.Json.Linq;
using QRCoder;
using Windows.ApplicationModel.Chat;

namespace ClipboardQRGenerator
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            MyClipboardViewer viewer = new MyClipboardViewer(this);

            // イベントハンドラを登録
            viewer.ClipboardHandler += this.OnClipBoardChanged;
            InitializeComponent();
        }

        private readonly QRCtrl qrCtrl = new QRCtrl();
        public List<string> geneLog = new List<string>();
        private bool is_gene = false;
        
        public void ReDrawList()
        {
            listView1.Items.Clear();
            columnHeader1.Width = 443;
            foreach (string value in geneLog)
            {
                string[] items = { value };
                listView1.Items.Add(new ListViewItem(items));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            generateLogWrapper generateLogWrapper = new generateLogWrapper();
            geneLog = generateLogWrapper.ReadLog();
            ReDrawList();
            textBox1.Text = Properties.Settings.Default.qrW;
            textBox2.Text = Properties.Settings.Default.qrH;
            comboBox1.SelectedIndex = Properties.Settings.Default.ECCLv;
            comboBox2.SelectedIndex = Properties.Settings.Default.SaveKind;
            comboBox3.SelectedIndex = Properties.Settings.Default.SaveFileName;
            textBox3.Text = Properties.Settings.Default.SavePath;
            checkBox1.Checked = Properties.Settings.Default.is_Filesave;
            checkBox2.Checked = Properties.Settings.Default.is_saveLog;
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            is_gene = true;
            button2.Enabled = false;
            button3.Enabled = true;
            toolStripStatusLabel1.Text = "更新待機(クリップボード監視中)";
            this.Text += " - クリップボード監視中";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            is_gene = false;
            button2.Enabled = true;
            button3.Enabled = false;
            toolStripStatusLabel1.Text = "準備完了";
            this.Text = "ClipboardQRGenerator";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFolderDialog ofd = new OpenFolderDialog() {
                Title = "保存先フォルダを選択してください",
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = ofd.Path;
                Properties.Settings.Default.SavePath = textBox3.Text;
            }
        }
        private string lastdata = null;
        private void OnClipBoardChanged(object sender, ClipboardEventArgs args)
        {
            try
            {
                if (lastdata == args.Text || !is_gene) return;
                else
                {
                    Console.WriteLine(args.Text);
                    int.TryParse(textBox1.Text, out int Width);
                    int.TryParse(textBox2.Text, out int Height);

                    (int, int) geneSize = (Width,Height);

                    string[] sepArr = new string[] { "\r\n" };
                    string tocsv = args.Text.Replace("\t", ",");
                    string[] lines = tocsv.Split(sepArr,StringSplitOptions.RemoveEmptyEntries);

                    if(lines.Count() > 1)
                    {
                        foreach(string value in lines)
                        {
                            geneLog.Add(value);
                            Image qrTSV = qrCtrl.MakeQRCode(value);
                            if (Properties.Settings.Default.is_Filesave)
                                qrCtrl.SaveQRImage(qrTSV,
                                    qrCtrl.FilePathGenerator(value, Properties.Settings.Default.SaveFileName, Properties.Settings.Default.SaveKind, textBox3.Text),
                                    geneSize);
                            pictureBox1.Image = qrTSV;
                        }
                        ToastNotifySender($"QRコードを{lines.Count()}件生成しました。");
                        lastdata = args.Text;
                    }
                    else
                    {
                        geneLog.Add(args.Text);
                        lastdata = args.Text;
                        Image qr = qrCtrl.MakeQRCode(args.Text);
                        qrCtrl.CopyQRCode(qr,geneSize);

                        if (Properties.Settings.Default.is_Filesave)
                            qrCtrl.SaveQRImage(qr,
                                qrCtrl.FilePathGenerator(args.Text, Properties.Settings.Default.SaveFileName,Properties.Settings.Default.SaveKind,textBox3.Text),
                                geneSize);
                        pictureBox1.Image = qr;
                    }
                    
                    ReDrawList();
                }
            }
            catch
            {
                ToastNotifySender("QRコードの生成に失敗しました。");
            }
        }

        private void ToastNotifySender(string Message)
        {
            new ToastContentBuilder()
                            .AddArgument("action", "viewConversation")
                            .AddArgument("conversationId", 9813)
                            .AddText(Message)
                            .Show();
            ToastNotificationManagerCompat.OnActivated += this.ToastNotificationManagerCompat_OnActivated;
        }

        private void ToastNotificationManagerCompat_OnActivated(ToastNotificationActivatedEventArgsCompat e)
        {
            // e.Argument で押されたボタンを確認
            var arg = e.Argument;
            //キャンセル時
            if (arg == "cancel") return;
            //「開く」ボタン時
            if (arg == "openWeb") return;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ECCLv = comboBox1.SelectedIndex;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 1 || comboBox3.SelectedIndex == 2)
            {
                DialogResult Result = MessageBox.Show("クリップボードの内容をファイル名にする場合\r\n" +
                                "ファイル名として使用できない文字はすべて「 _ 」に変換されます。", "情報", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (Result == DialogResult.OK)
                    Properties.Settings.Default.SaveFileName = comboBox3.SelectedIndex;
                else
                    Properties.Settings.Default.SaveFileName = comboBox3.SelectedIndex = 0;
            }
            Properties.Settings.Default.SaveFileName = comboBox3.SelectedIndex;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.qrW = textBox1.Text;
            Properties.Settings.Default.qrH = textBox2.Text;
            generateLogWrapper generateLogWrapper = new generateLogWrapper();
            generateLogWrapper.WriteLog(geneLog);
            Properties.Settings.Default.Save();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.is_Filesave = checkBox1.Checked;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
        }

        private void qRをコピーToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int selectindex;
                selectindex = listView1.SelectedItems[0].Index;
                int.TryParse(textBox1.Text, out int Width);
                int.TryParse(textBox2.Text, out int Height);

                (int, int) geneSize = (Width, Height);
                int code = qrCtrl.CopyQRCode(qrCtrl.MakeQRCode(geneLog[selectindex]), geneSize);
                if(code == 0) ToastNotifySender("QRコードのコピーに成功しました");
                if(code == 1) ToastNotifySender("QRコードのコピーに失敗しました");
            }
        }

        private void ファイル名を指定して保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int selectindex;
                selectindex = listView1.SelectedItems[0].Index;
                int.TryParse(textBox1.Text, out int Width);
                int.TryParse(textBox2.Text, out int Height);

                (int, int) geneSize = (Width, Height);

                SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "PNG画像データ(*.png)|*.png|JPG画像データ(*.jpg)|(*.jpg)|GIF画像データ(*.gif)|(*.gif)|BMP画像データ(*.bmp)|(*.bmp)",
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    int code=qrCtrl.SaveQRImage(qrCtrl.MakeQRCode(geneLog[selectindex]), sfd.FileName, geneSize);
                    ToastNotifySender("QRコードの保存に成功しました");
                    if(code == 0 )ToastNotifySender("QRコードの保存に成功しました");
                    if(code == 1) ToastNotifySender("QRコードの保存に失敗しました");
                }
            }
        }

        private void 保存フォルダに保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int selectindex;
                selectindex = listView1.SelectedItems[0].Index;
                int.TryParse(textBox1.Text, out int Width);
                int.TryParse(textBox2.Text, out int Height);

                Image qr = qrCtrl.MakeQRCode(geneLog[selectindex]);
                int code = qrCtrl.SaveQRImage(qr,
                            qrCtrl.FilePathGenerator(geneLog[selectindex], Properties.Settings.Default.SaveFileName, Properties.Settings.Default.SaveKind, textBox3.Text),
                            (Width, Height));
                if (code == 0) ToastNotifySender("QRコードの保存に成功しました");
                if (code == 1) ToastNotifySender("QRコードの保存に失敗しました");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("生成ログをクリアします。\r\nこの処理は元に戻せません。よろしいですか。","警告",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
            {
                geneLog = new List<string>();
                ReDrawList();
            }
        }

        private void このソフトウェアについてToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About f = new About();
            f.ShowDialog();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.is_saveLog = checkBox2.Checked;
        }
    }
}