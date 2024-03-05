using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Toolkit.Uwp.Notifications;
using QRCoder;

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

        private bool is_gene = false;

        public void MakeQRCode(string Value)
        {
            QRCodeGenerator qRCG = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCG.CreateQrCode(Value, ECCLvs[Properties.Settings.Default.ECCLv]);
            QRCode qrCode = new QRCode(qRCodeData);
            using (Image img = qrCode.GetGraphic(20))
            {
                Bitmap bitmap1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                
                using(Graphics g = Graphics.FromImage(bitmap1))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(img,0,0, pictureBox1.Width, pictureBox1.Height);
                }
                pictureBox1.Image = bitmap1;
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = Properties.Settings.Default.ECCLv;
            comboBox2.SelectedIndex = Properties.Settings.Default.SaveKind;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            is_gene = true;
            button2.Enabled = false;
            button3.Enabled = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            is_gene = false;
            button2.Enabled = true;
            button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { 
                Title = "保存先フォルダを選択してください",
                Filter = "Folder|.",
                CheckFileExists = false
            };
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = Path.GetDirectoryName(sfd.FileName);
            }
        }
        private string lastdata = null;
        private void OnClipBoardChanged(object sender, ClipboardEventArgs args)
        {
            if(lastdata == args.Text) return;
            else
            {
                Console.WriteLine(args.Text);
                MakeQRCode(args.Text);
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ECCLv = comboBox1.SelectedIndex;
        }

    }
}
