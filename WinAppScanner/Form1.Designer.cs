using System.Windows.Forms;
namespace WinAppScanner
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.showImages = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.cmbscannerlist = new System.Windows.Forms.ComboBox();
            this.lblScanner = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnJPEG = new System.Windows.Forms.Button();
            this.btnPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // showImages
            // 
            this.showImages.Location = new System.Drawing.Point(242, 216);
            this.showImages.Name = "showImages";
            this.showImages.Size = new System.Drawing.Size(85, 23);
            this.showImages.TabIndex = 5;
            this.showImages.Text = "Show Images";
            this.showImages.UseVisualStyleBackColor = true;
            this.showImages.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1038, 3);
            this.splitter1.TabIndex = 38;
            this.splitter1.TabStop = false;
            // 
            // cmbscannerlist
            // 
            this.cmbscannerlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbscannerlist.FormattingEnabled = true;
            this.cmbscannerlist.Location = new System.Drawing.Point(113, 34);
            this.cmbscannerlist.Name = "cmbscannerlist";
            this.cmbscannerlist.Size = new System.Drawing.Size(239, 23);
            this.cmbscannerlist.TabIndex = 9;
            // 
            // lblScanner
            // 
            this.lblScanner.AutoSize = true;
            this.lblScanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScanner.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblScanner.Location = new System.Drawing.Point(25, 37);
            this.lblScanner.Name = "lblScanner";
            this.lblScanner.Size = new System.Drawing.Size(65, 16);
            this.lblScanner.TabIndex = 39;
            this.lblScanner.Text = "Scanner";
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(12, 75);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(1014, 488);
            this.pbImage.TabIndex = 40;
            this.pbImage.TabStop = false;
            // 
            // btnJPEG
            // 
            this.btnJPEG.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnJPEG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJPEG.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnJPEG.Location = new System.Drawing.Point(632, 588);
            this.btnJPEG.Name = "btnJPEG";
            this.btnJPEG.Size = new System.Drawing.Size(147, 45);
            this.btnJPEG.TabIndex = 41;
            this.btnJPEG.Text = "Save As JPEG";
            this.btnJPEG.UseVisualStyleBackColor = false;
            this.btnJPEG.Click += new System.EventHandler(this.btnJPEG_Click);
            // 
            // btnPDF
            // 
            this.btnPDF.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDF.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPDF.Location = new System.Drawing.Point(840, 588);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(163, 45);
            this.btnPDF.TabIndex = 42;
            this.btnPDF.Text = "Save As PDF";
            this.btnPDF.UseVisualStyleBackColor = false;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1038, 645);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.btnJPEG);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.lblScanner);
            this.Controls.Add(this.cmbscannerlist);
            this.Controls.Add(this.splitter1);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            //this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.SizeChanged += new System.EventHandler(this.Home_SizeChanged);
            //this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion



        //camera
        private System.Windows.Forms.Button showImages;
        private Splitter splitter1;
        private ComboBox cmbscannerlist;
        private Label lblScanner;
        private PictureBox pbImage;
        private Button btnJPEG;
        private Button btnPDF;
    }
}

