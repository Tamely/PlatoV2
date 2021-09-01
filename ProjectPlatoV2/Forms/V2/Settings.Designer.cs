
using System.ComponentModel;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace ProjectPlatoV2.Forms.V2
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSwapped = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnReset = new Bunifu.Framework.UI.BunifuFlatButton();
            this.fnPath = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.SecHex = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.SecB = new System.Windows.Forms.TextBox();
            this.SecG = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SecR = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.PrimHex = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PrimB = new System.Windows.Forms.TextBox();
            this.PrimG = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Label();
            this.PrimR = new System.Windows.Forms.TextBox();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.panel1.Controls.Add(this.bunifuFlatButton1);
            this.panel1.Controls.Add(this.btnSwapped);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.fnPath);
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.SecHex);
            this.panel1.Controls.Add(this.textBox7);
            this.panel1.Controls.Add(this.textBox8);
            this.panel1.Controls.Add(this.textBox9);
            this.panel1.Controls.Add(this.SecB);
            this.panel1.Controls.Add(this.SecG);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.SecR);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.PrimHex);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.PrimB);
            this.panel1.Controls.Add(this.PrimG);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.PrimR);
            this.panel1.Location = new System.Drawing.Point(13, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 211);
            this.panel1.TabIndex = 1;
            // 
            // btnSwapped
            // 
            this.btnSwapped.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(250)))));
            this.btnSwapped.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(250)))));
            this.btnSwapped.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSwapped.BorderRadius = 7;
            this.btnSwapped.ButtonText = "Swapped Items";
            this.btnSwapped.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSwapped.DisabledColor = System.Drawing.Color.Gray;
            this.btnSwapped.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSwapped.Iconimage = null;
            this.btnSwapped.Iconimage_right = null;
            this.btnSwapped.Iconimage_right_Selected = null;
            this.btnSwapped.Iconimage_Selected = null;
            this.btnSwapped.IconMarginLeft = 0;
            this.btnSwapped.IconMarginRight = 0;
            this.btnSwapped.IconRightVisible = true;
            this.btnSwapped.IconRightZoom = 0D;
            this.btnSwapped.IconVisible = true;
            this.btnSwapped.IconZoom = 90D;
            this.btnSwapped.IsTab = false;
            this.btnSwapped.Location = new System.Drawing.Point(270, 37);
            this.btnSwapped.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnSwapped.Name = "btnSwapped";
            this.btnSwapped.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(250)))));
            this.btnSwapped.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(169)))), ((int)(((byte)(250)))));
            this.btnSwapped.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSwapped.selected = false;
            this.btnSwapped.Size = new System.Drawing.Size(156, 36);
            this.btnSwapped.TabIndex = 25;
            this.btnSwapped.Text = "Swapped Items";
            this.btnSwapped.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSwapped.Textcolor = System.Drawing.Color.White;
            this.btnSwapped.TextFont = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSwapped.Click += new System.EventHandler(this.btnSwapped_Click);
            // 
            // btnReset
            // 
            this.btnReset.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(250)))));
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(250)))));
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReset.BorderRadius = 7;
            this.btnReset.ButtonText = "Reset Swaps";
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.DisabledColor = System.Drawing.Color.Gray;
            this.btnReset.Iconcolor = System.Drawing.Color.Transparent;
            this.btnReset.Iconimage = null;
            this.btnReset.Iconimage_right = null;
            this.btnReset.Iconimage_right_Selected = null;
            this.btnReset.Iconimage_Selected = null;
            this.btnReset.IconMarginLeft = 0;
            this.btnReset.IconMarginRight = 0;
            this.btnReset.IconRightVisible = true;
            this.btnReset.IconRightZoom = 0D;
            this.btnReset.IconVisible = true;
            this.btnReset.IconZoom = 90D;
            this.btnReset.IsTab = false;
            this.btnReset.Location = new System.Drawing.Point(270, 79);
            this.btnReset.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(250)))));
            this.btnReset.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(169)))), ((int)(((byte)(250)))));
            this.btnReset.OnHoverTextColor = System.Drawing.Color.White;
            this.btnReset.selected = false;
            this.btnReset.Size = new System.Drawing.Size(156, 36);
            this.btnReset.TabIndex = 24;
            this.btnReset.Text = "Reset Swaps";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnReset.Textcolor = System.Drawing.Color.White;
            this.btnReset.TextFont = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // fnPath
            // 
            this.fnPath.AutoSize = true;
            this.fnPath.BackColor = System.Drawing.Color.Transparent;
            this.fnPath.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fnPath.ForeColor = System.Drawing.Color.White;
            this.fnPath.Location = new System.Drawing.Point(7, 176);
            this.fnPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fnPath.Name = "fnPath";
            this.fnPath.Size = new System.Drawing.Size(81, 17);
            this.fnPath.TabIndex = 23;
            this.fnPath.Text = "Fortnite Path:";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox5.Location = new System.Drawing.Point(18, 119);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(20, 16);
            this.textBox5.TabIndex = 22;
            this.textBox5.Text = "Hex";
            // 
            // SecHex
            // 
            this.SecHex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.SecHex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SecHex.ForeColor = System.Drawing.SystemColors.Window;
            this.SecHex.Location = new System.Drawing.Point(46, 119);
            this.SecHex.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SecHex.Name = "SecHex";
            this.SecHex.Size = new System.Drawing.Size(50, 16);
            this.SecHex.TabIndex = 21;
            this.SecHex.Text = "#27293d";
            this.SecHex.TextChanged += new System.EventHandler(this.SecHex_TextChanged);
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox7.Location = new System.Drawing.Point(20, 53);
            this.textBox7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(20, 16);
            this.textBox7.TabIndex = 20;
            this.textBox7.Text = "R";
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox8.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox8.Location = new System.Drawing.Point(20, 75);
            this.textBox8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(20, 16);
            this.textBox8.TabIndex = 19;
            this.textBox8.Text = "G";
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox9.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox9.Location = new System.Drawing.Point(20, 97);
            this.textBox9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(20, 16);
            this.textBox9.TabIndex = 18;
            this.textBox9.Text = "B";
            // 
            // SecB
            // 
            this.SecB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.SecB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SecB.ForeColor = System.Drawing.SystemColors.Window;
            this.SecB.Location = new System.Drawing.Point(41, 97);
            this.SecB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SecB.Name = "SecB";
            this.SecB.Size = new System.Drawing.Size(40, 16);
            this.SecB.TabIndex = 17;
            this.SecB.Text = "61";
            this.SecB.TextChanged += new System.EventHandler(this.SecB_TextChanged);
            // 
            // SecG
            // 
            this.SecG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.SecG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SecG.ForeColor = System.Drawing.SystemColors.Window;
            this.SecG.Location = new System.Drawing.Point(41, 75);
            this.SecG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SecG.Name = "SecG";
            this.SecG.Size = new System.Drawing.Size(40, 16);
            this.SecG.TabIndex = 16;
            this.SecG.Text = "41";
            this.SecG.TextChanged += new System.EventHandler(this.SecG_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(124, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Secondary Color";
            // 
            // SecR
            // 
            this.SecR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.SecR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SecR.ForeColor = System.Drawing.SystemColors.Window;
            this.SecR.Location = new System.Drawing.Point(41, 53);
            this.SecR.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SecR.Name = "SecR";
            this.SecR.Size = new System.Drawing.Size(40, 16);
            this.SecR.TabIndex = 14;
            this.SecR.Text = "39";
            this.SecR.TextChanged += new System.EventHandler(this.SecR_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox4.Location = new System.Drawing.Point(126, 119);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(20, 16);
            this.textBox4.TabIndex = 13;
            this.textBox4.Text = "Hex";
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // PrimHex
            // 
            this.PrimHex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.PrimHex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PrimHex.ForeColor = System.Drawing.SystemColors.Window;
            this.PrimHex.Location = new System.Drawing.Point(154, 119);
            this.PrimHex.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PrimHex.Name = "PrimHex";
            this.PrimHex.Size = new System.Drawing.Size(50, 16);
            this.PrimHex.TabIndex = 12;
            this.PrimHex.Text = "#1e1e29";
            this.PrimHex.TextChanged += new System.EventHandler(this.PrimHex_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox3.Location = new System.Drawing.Point(128, 53);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(20, 16);
            this.textBox3.TabIndex = 11;
            this.textBox3.Text = "R";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox2.Location = new System.Drawing.Point(128, 75);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(20, 16);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "G";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(128, 97);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(20, 16);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "B";
            // 
            // PrimB
            // 
            this.PrimB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.PrimB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PrimB.ForeColor = System.Drawing.SystemColors.Window;
            this.PrimB.Location = new System.Drawing.Point(149, 97);
            this.PrimB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PrimB.Name = "PrimB";
            this.PrimB.Size = new System.Drawing.Size(40, 16);
            this.PrimB.TabIndex = 6;
            this.PrimB.Text = "41";
            this.PrimB.TextChanged += new System.EventHandler(this.PrimB_TextChanged);
            // 
            // PrimG
            // 
            this.PrimG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.PrimG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PrimG.ForeColor = System.Drawing.SystemColors.Window;
            this.PrimG.Location = new System.Drawing.Point(149, 75);
            this.PrimG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PrimG.Name = "PrimG";
            this.PrimG.Size = new System.Drawing.Size(40, 16);
            this.PrimG.TabIndex = 5;
            this.PrimG.Text = "30";
            this.PrimG.TextChanged += new System.EventHandler(this.PrimG_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Primary Color";
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(406, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 21);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "X";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PrimR
            // 
            this.PrimR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.PrimR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PrimR.ForeColor = System.Drawing.SystemColors.Window;
            this.PrimR.Location = new System.Drawing.Point(149, 53);
            this.PrimR.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PrimR.Name = "PrimR";
            this.PrimR.Size = new System.Drawing.Size(40, 16);
            this.PrimR.TabIndex = 1;
            this.PrimR.Text = "30";
            this.PrimR.TextChanged += new System.EventHandler(this.PrimR_TextChanged);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(250)))));
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(250)))));
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 7;
            this.bunifuFlatButton1.ButtonText = "Add Plugin";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = null;
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 90D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(270, 121);
            this.bunifuFlatButton1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(250)))));
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(169)))), ((int)(((byte)(250)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(156, 36);
            this.bunifuFlatButton1.TabIndex = 26;
            this.bunifuFlatButton1.Text = "Add Plugin";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(463, 237);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private TextBox textBox4;
        private TextBox PrimHex;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private TextBox PrimB;
        private TextBox PrimG;
        private Label label2;
        private Label btnClose;
        private TextBox PrimR;
        private BunifuElipse bunifuElipse1;
        private BunifuDragControl bunifuDragControl1;
        private Label fnPath;
        private TextBox textBox5;
        private TextBox SecHex;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private TextBox SecB;
        private TextBox SecG;
        private Label label1;
        private TextBox SecR;
        private BunifuFlatButton btnSwapped;
        private BunifuFlatButton btnReset;
        private BunifuFlatButton bunifuFlatButton1;
    }
}