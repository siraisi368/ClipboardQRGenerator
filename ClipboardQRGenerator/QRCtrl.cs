﻿using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ClipboardQRGenerator
{
    public class QRCtrl
    {
        // 誤り訂正レベル
        public Dictionary<int, QRCodeGenerator.ECCLevel> ECCLvs = new Dictionary<int, QRCodeGenerator.ECCLevel>()
        {
            { 0,QRCodeGenerator.ECCLevel.L},
            { 1,QRCodeGenerator.ECCLevel.M},
            { 2,QRCodeGenerator.ECCLevel.Q},
            { 3,QRCodeGenerator.ECCLevel.H},
        };
        // ファイル形式
        public Dictionary<int, ImageFormat> SaveFileTypes = new Dictionary<int, ImageFormat>()
        {
            { 0,ImageFormat.Png},
            { 1,ImageFormat.Jpeg},
            { 2,ImageFormat.Gif},
            { 3,ImageFormat.Bmp},
        };
        // 拡張子String
        public Dictionary<int, string> SaveFileTypeExt = new Dictionary<int, string>()
        {
            { 0,".png"},
            { 1,".jpg"},
            { 2,".gif"},
            { 3,".bmp"},
        };
        static Encoding enc = Encoding.UTF8;
        public int ConvertPixelPerModule((int,int) size)
        {
            int respData = 5;
            if (size.Item1 >= 50 && size.Item2 >= 50 && size.Item1 <= 400 && size.Item2 <= 400)
            {
                respData = 5;
            }
            // 設定解像度が400px上 600下
            if (size.Item1 >= 400 && size.Item2 >= 400 && size.Item1 <= 600 && size.Item2 <= 600)
            {
                respData = 10;
            }
            // 設定解像度が600px上 1000下
            else if (size.Item1 >= 600 && size.Item2 >= 600 && size.Item1 <= 1000 && size.Item2 <= 1000)
            {
                respData = 20;
            }

            return respData;
        }
        /// <summary>
        /// 使用不可能な文字をアンダースコアに置換える関数
        /// </summary>
        /// <param name="fileName">ファイル名にしたい文字列</param>
        /// <returns></returns>
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
        /// <summary>
        /// ファイル名から品番と機種名を抽出して、アンダースコアで連結する関数
        /// </summary>
        /// <param name="url">ファイルパス</param>
        /// <returns></returns>
        public string UrlToFileNamePN_MN(string url)
        {
            string respData = null;
            url = url.Replace(Environment.NewLine,"");
            url = Path.GetFileNameWithoutExtension(url);
            if (url == "" || url == null) return "Unkown";
            string[] strings = url.Split('_');
            string[] str = Regex.Split(strings[1], "xx");
            respData = $"{strings[0]}_{str[0]}";
            
            return respData;
        }

        /// <summary>
        /// QR化したパス・URLのファイル名のみを抽出する関数
        /// </summary>
        /// <param name="url">ファイルパス</param>
        /// <returns></returns>
        public string UrlToFileName(string url)
        {
            string respData = null;
            respData = Path.GetFileNameWithoutExtension(url);
            return respData;
        }
        /// <summary>
        /// 保存用パス生成器
        /// </summary>
        /// <param name="value">qr化内容</param>
        /// <param name="fileNameType">ファイル名形式</param>
        /// <param name="fileExt">拡張子</param>
        /// <param name="folderPath">保存先フォルダ</param>
        /// <returns></returns>
        public string FilePathGenerator(string value, int fileNameType = 0, int fileExt = 0, string folderPath = null)
        {
            if (folderPath == null) return "Error";
            string respData = null;
            switch (fileNameType)
            {
                case 0: // 日時
                    respData = $@"{folderPath}\{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}{SaveFileTypeExt[fileExt]}";
                    break;
                case 1: // クリップボード内容
                    respData = $@"{folderPath}\{ConvertFileName(value)}{SaveFileTypeExt[fileExt]}";
                    break;
                case 2: // 日時＋クリップボード内容
                    respData = $@"{folderPath}\{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}{ConvertFileName(value)}{SaveFileTypeExt[fileExt]}";
                    break;
                case 3: // URL・ファイルパスのファイル名のみ
                    respData = $@"{folderPath}\{UrlToFileName(value)}{SaveFileTypeExt[fileExt]}";
                    break;
                case 4: //品番＋機種名
                    respData = $@"{folderPath}\{UrlToFileNamePN_MN(value)}{SaveFileTypeExt[fileExt]}";
                    break;
            }
            return respData;
        }

        /// <summary>
        /// 生成したQRコードを指定した解像度で保存する関数
        /// </summary>
        /// <param name="filePath">保存先パス</param>
        /// <param name="imageSize">目標解像度</param>
        /// <param name="saveFormat">保存する形式</param>
        /// <param name="saveImage">保存する画像</param>
        /// <returns></returns>
        public int SaveQRImage(Image saveImage, string filePath, (int?, int?) imageSize)
        {
            try
            {
                Bitmap bitmap = new Bitmap(width: (int)imageSize.Item1, height: (int)imageSize.Item2);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    g.DrawImage(saveImage, 0, 0, bitmap.Width, bitmap.Height);
                }
                bitmap.Save(filePath);
            }
            catch
            {
                return 1;
            }
            return 0;
        }
        /// <summary>
        /// 生成したQRコードを指定した解像度でクリップボードにコピーする関数
        /// </summary>
        /// <param name="qrImage">QRコード画像</param>
        /// <param name="imageSize">目標解像度</param>
        /// <returns></returns>
        public int CopyQRCode(Image qrImage, (int?, int?) imageSize)
        {
            try
            {
                Bitmap bitmap = new Bitmap(width: (int)imageSize.Item1, height: (int)imageSize.Item2);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    g.DrawImage(qrImage, 0, 0, bitmap.Width, bitmap.Height);
                }
                Clipboard.SetImage(bitmap);
                return 0;
            }
            catch { return 1; }
        }

        public Image MakeQRCode(string Value,int qrSize)
        {
            QRCodeGenerator qRCG = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCG.CreateQrCode(Value, ECCLvs[Properties.Settings.Default.ECCLv]);
            QRCode qrCode = new QRCode(qRCodeData);
            return qrCode.GetGraphic(qrSize);
        }
    }
}
