using System.ComponentModel;

namespace ProjectPlatoV2.Forms
{
    partial class AlertBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertBox));
            this.imgInfo = new System.Windows.Forms.PictureBox();
            this.txtInfo = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.Time = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize) (this.imgInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.Time)).BeginInit();
            this.SuspendLayout();
            // 
            // imgInfo
            // 
            this.imgInfo.BackColor = System.Drawing.Color.Transparent;
            this.imgInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgInfo.ErrorImage = null;
            this.imgInfo.Image = ((System.Drawing.Image) (resources.GetObject("imgInfo.Image")));
            this.imgInfo.InitialImage = null;
            this.imgInfo.Location = new System.Drawing.Point(12, 12);
            this.imgInfo.Name = "imgInfo";
            this.imgInfo.Size = new System.Drawing.Size(70, 70);
            this.imgInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgInfo.TabIndex = 2;
            this.imgInfo.TabStop = false;
            // 
            // txtInfo
            // 
            this.txtInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtInfo.ForeColor = System.Drawing.Color.White;
            this.txtInfo.Location = new System.Drawing.Point(88, 12);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(214, 70);
            this.txtInfo.TabIndex = 3;
            this.txtInfo.Text = "ERROR PARSING TEXT";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 7;
            this.bunifuElipse1.TargetControl = this;
            // 
            // Time
            // 
            this.Time.Enabled = true;
            this.Time.Interval = 1000D;
            this.Time.SynchronizingObject = this;
            this.Time.Elapsed += new System.Timers.ElapsedEventHandler(this.Time_Elapsed);
            // 
            // AlertBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (30)))), ((int) (((byte) (30)))), ((int) (((byte) (41)))));
            this.ClientSize = new System.Drawing.Size(314, 96);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.imgInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "AlertBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AlertBox";
            this.Load += new System.EventHandler(this.AlertBox_Load);
            ((System.ComponentModel.ISupportInitialize) (this.imgInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.Time)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Timers.Timer Time;

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;

        private System.Windows.Forms.Label txtInfo;

        private System.Windows.Forms.PictureBox imgInfo;

        #endregion
    }
}