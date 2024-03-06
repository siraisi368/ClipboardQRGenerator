using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Toolkit.Uwp.Notifications;
using QRCoder;
using Windows.ApplicationModel.Chat;

namespace ClipboardQRGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            MyClipboardViewer viewer = new MyClipboardViewer(this);

            // イベントハンドラを登録
            viewer.ClipboardHandler += this.OnClipBoardChanged;
            InitializeComponent();
        }

        public Dictionary<int, QRCodeGenerator.ECCLevel> ECCLvs = new Dictionary<int, QRCodeGenerator.ECCLevel>()
        {
            { 0,QRCodeGenerator.ECCLevel.L},
            { 1,QRCodeGenerator.ECCLevel.M},
            { 2,QRCodeGenerator.ECCLevel.Q},
            { 3,QRCodeGenerator.ECCLevel.H},
        };

        public Dictionary<int, ImageFormat> SaveFileTypes = new Dictionary<int, ImageFormat>()
        {
            { 0,ImageFormat.Png},
            { 1,ImageFormat.Jpeg},
            { 2,ImageFormat.Gif},
            { 3,ImageFormat.Bmp},
        };
        public Dictionary<int, string> SaveFileTypeExists = new Dictionary<int, string>()
        {
            { 0,".png"},
            { 1,".jpg"},
            { 2,".gif"},
            { 3,".bmp"},
        };

        public List<string> geneLog = new List<string>();

        private bool is_gene = false;

        public string UrlToFileNameD6 (string url)
        {
            string respData = null;
            respData = Path.GetFileNameWithoutExtension(url);
            string[] tempList = respData.Split('_');
            respData = tempList[2];
            return respData;
        }

        public void MakeQRCode(string Value, bool is_preview = true, bool is_copy = true, bool is_save = true,string savepath=null)
        {
            QRCodeGenerator qRCG = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCG.CreateQrCode(Value, ECCLvs[Properties.Settings.Default.ECCLv]);
            QRCode qrCode = new QRCode(qRCodeData);
            using (Image img = qrCode.GetGraphic(20))
            {
                int.TryParse(textBox1.Text, out int Width);
                int.TryParse(textBox2.Text, out int Height);
                Bitmap bitmap1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Bitmap bitmap2 = new Bitmap(Width, Height);
                if (is_preview)
                {
                    using (Graphics g = Graphics.FromImage(bitmap1)) //表示用
                    {
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.DrawImage(img, 0, 0, pictureBox1.Width, pictureBox1.Height);
                    }
                    pictureBox1.Image = bitmap1;
                }
                using (Graphics g = Graphics.FromImage(bitmap2)) //クリップボード用
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(img, 0, 0, Width, Height);
                    Clipboard.SetImage(bitmap2);
                }

                if (checkBox1.Checked && is_save)
                {
                    switch (comboBox3.SelectedIndex)
                    {
                        case 0:
                            bitmap2.Save(textBox3.Text + @"\" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + SaveFileTypeExists[Properties.Settings.Default.SaveKind], SaveFileTypes[Properties.Settings.Default.SaveKind]);
                            break;
                        case 1:
                            bitmap2.Save(textBox3.Text + @"\" + ConvertFileName(Value) + SaveFileTypeExists[Properties.Settings.Default.SaveKind], SaveFileTypes[Properties.Settings.Default.SaveKind]);
                            break;
                        case 2:
                            bitmap2.Save(textBox3.Text + @"\" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss ") + ConvertFileName(Value) + SaveFileTypeExists[Properties.Settings.Default.SaveKind], SaveFileTypes[Properties.Settings.Default.SaveKind]);
                            break;
                        case 3:
                            bitmap2.Save(textBox3.Text + @"\" + UrlToFileNameD6(Value) + SaveFileTypeExists[Properties.Settings.Default.SaveKind], SaveFileTypes[Properties.Settings.Default.SaveKind]);
                            break;
                    }
                }
            }
        }

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

        public string ConvertFileName(string fileName)
        {
            string respData = fileName.Replace(" ", "");
            char[] UnAvailableChar = Path.GetInvalidFileNameChars();
            respData = respData.Replace(Environment.NewLine, "");
            foreach (char value in UnAvailableChar)
            {
                respData = respData.Replace(value, '_');
            }
            return respData;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = Properties.Settings.Default.ECCLv;
            comboBox2.SelectedIndex = Properties.Settings.Default.SaveKind;
            comboBox3.SelectedIndex = Properties.Settings.Default.SaveFileName;
            textBox3.Text = Properties.Settings.Default.SavePath;
            checkBox1.Checked = Properties.Settings.Default.is_Filesave;
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
                    lastdata = args.Text;
                    geneLog.Add(args.Text);
                    Console.WriteLine(args.Text);
                    MakeQRCode(args.Text);
                    ReDrawList();
                    new ToastContentBuilder()
                            .AddArgument("action", "viewConversation")
                            .AddArgument("conversationId", 9813)
                            .AddText("QRコードの生成に成功しました")
                            .Show();
                    ToastNotificationManagerCompat.OnActivated += this.ToastNotificationManagerCompat_OnActivated;
                }
            }
            catch
            {
                new ToastContentBuilder()
                            .AddArgument("action", "viewConversation")
                            .AddArgument("conversationId", 9813)
                            .AddText("QRコードの生成に失敗しました")
                            .Show();
                ToastNotificationManagerCompat.OnActivated += this.ToastNotificationManagerCompat_OnActivated;
            }
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
                MakeQRCode(geneLog[selectindex],false,true,false);
            }
        }

        private void ファイル名を指定して保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int selectindex;
                selectindex = listView1.SelectedItems[0].Index;
                MakeQRCode(geneLog[selectindex], false, true, false);
            }
        }
    }
}