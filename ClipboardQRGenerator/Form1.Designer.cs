namespace ClipboardQRGenerator
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.qRをコピーToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qRを保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ファイル名を指定して保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存フォルダに保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.このソフトウェアについてToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(246, 119);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "QR生成の設定";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "(非推奨)レベルL(7%)",
            "レベルM(15%)",
            "(推奨)レベルQ(25%)",
            "レベルH(30%)"});
            this.comboBox1.Location = new System.Drawing.Point(10, 84);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(223, 24);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "誤り訂正レベル";
            this.toolTip1.SetToolTip(this.label3, "誤り訂正レベル\r\nQRコードのうち何%が損傷しても読み取り可能かを表すレベルです。\r\n通常はレベルQあれば問題ありません。");
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(133, 39);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "180";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "x";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "180";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "生成解像度";
            this.toolTip1.SetToolTip(this.label1, "生成解像度\r\n生成されるQRコードの解像度を設定できます。\r\n900x900以下推奨");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 354);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(841, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(55, 17);
            this.toolStripStatusLabel1.Text = "準備完了";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(771, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "Developed by siraisi368";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Location = new System.Drawing.Point(266, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(563, 119);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "QRコード保存の設定";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "日時",
            "クリップボード内容",
            "日時+クリップボード内容",
            "URL・フォルダパス内ファイル名"});
            this.comboBox3.Location = new System.Drawing.Point(260, 84);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(297, 24);
            this.comboBox3.TabIndex = 8;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(257, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "ファイル名形式";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "(推奨).PNG形式",
            ".JPG形式",
            ".GIF形式",
            ".BMP形式"});
            this.comboBox2.Location = new System.Drawing.Point(6, 84);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(245, 24);
            this.comboBox2.TabIndex = 6;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "保存形式";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(482, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "選択";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "保存先：";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(145, 20);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "生成時に保存する";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(72, 39);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(404, 23);
            this.textBox3.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listView1);
            this.groupBox3.Location = new System.Drawing.Point(13, 139);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(455, 208);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "QR化ログ";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(449, 186);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "内容";
            this.columnHeader1.Width = 443;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.qRをコピーToolStripMenuItem,
            this.qRを保存ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // qRをコピーToolStripMenuItem
            // 
            this.qRをコピーToolStripMenuItem.Name = "qRをコピーToolStripMenuItem";
            this.qRをコピーToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.qRをコピーToolStripMenuItem.Text = "QRをコピー";
            this.qRをコピーToolStripMenuItem.Click += new System.EventHandler(this.qRをコピーToolStripMenuItem_Click);
            // 
            // qRを保存ToolStripMenuItem
            // 
            this.qRを保存ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイル名を指定して保存ToolStripMenuItem,
            this.保存フォルダに保存ToolStripMenuItem});
            this.qRを保存ToolStripMenuItem.Name = "qRを保存ToolStripMenuItem";
            this.qRを保存ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.qRを保存ToolStripMenuItem.Text = "QRを保存";
            // 
            // ファイル名を指定して保存ToolStripMenuItem
            // 
            this.ファイル名を指定して保存ToolStripMenuItem.Name = "ファイル名を指定して保存ToolStripMenuItem";
            this.ファイル名を指定して保存ToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.ファイル名を指定して保存ToolStripMenuItem.Text = "ファイル名を指定して保存";
            this.ファイル名を指定して保存ToolStripMenuItem.Click += new System.EventHandler(this.ファイル名を指定して保存ToolStripMenuItem_Click);
            // 
            // 保存フォルダに保存ToolStripMenuItem
            // 
            this.保存フォルダに保存ToolStripMenuItem.Name = "保存フォルダに保存ToolStripMenuItem";
            this.保存フォルダに保存ToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.保存フォルダに保存ToolStripMenuItem.Text = "生成QR保存フォルダに保存";
            this.保存フォルダに保存ToolStripMenuItem.Click += new System.EventHandler(this.保存フォルダに保存ToolStripMenuItem_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Location = new System.Drawing.Point(474, 139);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(193, 208);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "最新のQR";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Location = new System.Drawing.Point(673, 139);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(156, 208);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "コントロール";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 172);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(144, 30);
            this.button4.TabIndex = 2;
            this.button4.Text = "クリップボードクリア";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(6, 58);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(144, 30);
            this.button3.TabIndex = 1;
            this.button3.Text = "監視終了";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 30);
            this.button2.TabIndex = 0;
            this.button2.Text = "監視開始";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "CQG - 待機中";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.このソフトウェアについてToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(180, 26);
            // 
            // このソフトウェアについてToolStripMenuItem
            // 
            this.このソフトウェアについてToolStripMenuItem.Name = "このソフトウェアについてToolStripMenuItem";
            this.このソフトウェアについてToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.このソフトウェアについてToolStripMenuItem.Text = "このソフトウェアについて";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 136);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(144, 30);
            this.button5.TabIndex = 3;
            this.button5.Text = "QR化ログクリア";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 376);
            this.ContextMenuStrip = this.contextMenuStrip2;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "ClipboardQRGenerator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem qRをコピーToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qRを保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ファイル名を指定して保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存フォルダに保存ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem このソフトウェアについてToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button5;
    }
}

