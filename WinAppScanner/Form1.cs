using Fleck;
using NTwain;
using NTwain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WIATest;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static WIATest.WIAScanner;

namespace WinAppScanner
{
    public partial class Form1 : Form
    {
        ImageCodecInfo _tiffCodecInfo;
        TwainSession _twain;
        bool _stopScan;
        bool _loadingCaps;
        List<IWebSocketConnection> allSockets;
        WebSocketServer server;
        public Form1()
        {
            InitializeComponent();
            #region start soket
            if (NTwain.PlatformInfo.Current.IsApp64Bit)
            {
                Text = Text + " (64bit)";
            }
            else
            {
                Text = Text + " (32bit)";
            }
            foreach (var enc in ImageCodecInfo.GetImageEncoders())
            {
                if (enc.MimeType == "image/tiff") { _tiffCodecInfo = enc; break; }
            }

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            //Get the IP Address value from webconfig
            string IPAddress = "ws://" + System.Configuration.ConfigurationManager.AppSettings["IP"].ToString();

            //Get the Port No  value from webconfig
            var portno = System.Configuration.ConfigurationManager.AppSettings["port"];

            allSockets = new List<IWebSocketConnection>();
            server = new WebSocketServer(IPAddress + ":" + portno);

            server.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    Console.WriteLine("Open!");
                    allSockets.Add(socket);
                };
                socket.OnClose = () =>
                {
                    Console.WriteLine("Close!");
                    allSockets.Remove(socket);
                };
                socket.OnMessage = message =>
                {
                    if (message == "1100")
                    {
                        this.Invoke(new Action(() =>
                        {
                            this.WindowState = FormWindowState.Maximized;
                        }));
                    }
                };
            });
            #endregion
            BindScanner();
        }
        //Bind Scanner
        public void BindScanner()
        {
            List<DeviceClass> devices = WIAScanner.GetDevices();
            cmbscannerlist.ValueMember = "DeviceId";
            cmbscannerlist.DisplayMember = "DeviceName";
            cmbscannerlist.DataSource = devices;
        }
        //Convert Image To PDF
        public string ImagesToPdf(string imagepaths, string pdfpath)
        {
            iTextSharp.text.Rectangle pageSize = null;

            using (var srcImage = new Bitmap(imagepaths.ToString()))
            {
                pageSize = new iTextSharp.text.Rectangle(0, 0, srcImage.Width, srcImage.Height);
            }

            using (var ms = new MemoryStream())
            {
                var document = new iTextSharp.text.Document(pageSize, 0, 0, 0, 0);
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, ms).SetFullCompression();
                document.Open();
                var image = iTextSharp.text.Image.GetInstance(imagepaths.ToString());
                document.Add(image);
                document.Close();

                File.WriteAllBytes(pdfpath + @"\" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".pdf", ms.ToArray());
            }
            return pdfpath + @"\" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".pdf";
        }
        private void Home_SizeChanged(object sender, EventArgs e)
        {
            int pheight = this.Size.Height - 153;
            pbImage.Size = new Size(pheight - 150, pheight);
        }
        //Save As JPEG click event
        private void btnJPEG_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbscannerlist.SelectedItem == null)
                {
                    MessageBox.Show(" Select Scanner!! ");
                    return;
                }
                else
                {
                    //get images from scanner
                    List<System.Drawing.Image> images = WIAScanner.Scan((string)cmbscannerlist.SelectedValue);
                    var enviroment = System.Environment.CurrentDirectory;
                    //string projectDirectory = Directory.GetParent(enviroment).Parent.FullName + @"\ScanFiles";
                    string projectDirectory = @"D:\ScannerApp\ScanFiles";
                    string Imgpath = string.Empty;
                    foreach (System.Drawing.Image image in images)
                    {
                        pbImage.Image = image;
                        pbImage.Show();
                        pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        Imgpath = projectDirectory + @"\" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".jpeg";
                        //save scanned image into specific folder
                        image.Save(Imgpath, ImageFormat.Jpeg);
                    }
                    if (!string.IsNullOrEmpty(Imgpath))
                    {
                        byte[] buff = System.IO.File.ReadAllBytes(Imgpath);
                        foreach (var socket in allSockets.ToList())
                        {
                            socket.Send(buff);
                        }
                        this.Invoke(new Action(() =>
                        {
                            this.WindowState = FormWindowState.Minimized;
                        }));
                    }
                    MessageBox.Show("Scan Completed.");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }
        //Save As PDF click event
        private void btnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbscannerlist.SelectedItem == null)
                {
                    MessageBox.Show(" Select Scanner!! ");
                    return;
                }
                else
                {
                    //get images from scanner
                    List<System.Drawing.Image> images = WIAScanner.Scan((string)cmbscannerlist.SelectedValue);
                    var enviroment = System.Environment.CurrentDirectory;
                    string projectDirectory = @"D:\ScannerApp\ScanFiles";
                    string pdfpath = string.Empty;
                    string ImagePath = string.Empty;
                    foreach (System.Drawing.Image image in images)
                    {
                        pbImage.Image = image;
                        pbImage.Show();
                        pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        ImagePath = projectDirectory + @"\" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".jpeg";

                        //save scanned image into specific folder
                        image.Save(ImagePath, ImageFormat.Jpeg);
                        pdfpath=ImagesToPdf(ImagePath, projectDirectory);
                    }
                    if (!string.IsNullOrEmpty(ImagePath))
                    {
                        byte[] buff = System.IO.File.ReadAllBytes(ImagePath);
                        foreach (var socket in allSockets.ToList())
                        {
                            socket.Send(buff);
                        }
                        this.Invoke(new Action(() =>
                        {
                            this.WindowState = FormWindowState.Minimized;
                        }));
                    }
                    MessageBox.Show("Scan Completed.");
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }
    }
}
