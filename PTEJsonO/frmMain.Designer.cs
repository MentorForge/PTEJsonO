namespace PTEJsonO
{
    partial class frmMain
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
            this.cmdConvert = new System.Windows.Forms.Button();
            this.cmdConvert2 = new System.Windows.Forms.Button();
            this.cmdConvert3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdConvert
            // 
            this.cmdConvert.Location = new System.Drawing.Point(144, 241);
            this.cmdConvert.Name = "cmdConvert";
            this.cmdConvert.Size = new System.Drawing.Size(75, 23);
            this.cmdConvert.TabIndex = 0;
            this.cmdConvert.Text = "FIBConvert";
            this.cmdConvert.UseVisualStyleBackColor = true;
            this.cmdConvert.Click += new System.EventHandler(this.cmdConvert_Click);
            // 
            // cmdConvert2
            // 
            this.cmdConvert2.Location = new System.Drawing.Point(355, 241);
            this.cmdConvert2.Name = "cmdConvert2";
            this.cmdConvert2.Size = new System.Drawing.Size(75, 23);
            this.cmdConvert2.TabIndex = 1;
            this.cmdConvert2.Text = "RWFIBConvert";
            this.cmdConvert2.UseVisualStyleBackColor = true;
            this.cmdConvert2.Click += new System.EventHandler(this.cmdConvert2_Click);
            // 
            // cmdConvert3
            // 
            this.cmdConvert3.Location = new System.Drawing.Point(513, 241);
            this.cmdConvert3.Name = "cmdConvert3";
            this.cmdConvert3.Size = new System.Drawing.Size(75, 23);
            this.cmdConvert3.TabIndex = 2;
            this.cmdConvert3.Text = "105";
            this.cmdConvert3.UseVisualStyleBackColor = true;
            this.cmdConvert3.Click += new System.EventHandler(this.cmdConvert3_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 326);
            this.Controls.Add(this.cmdConvert3);
            this.Controls.Add(this.cmdConvert2);
            this.Controls.Add(this.cmdConvert);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdConvert;
        private System.Windows.Forms.Button cmdConvert2;
        private System.Windows.Forms.Button cmdConvert3;
    }
}