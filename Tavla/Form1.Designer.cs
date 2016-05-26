namespace Tavla
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
            this.zemin = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.zemin.SuspendLayout();
            this.SuspendLayout();
            // 
            // zemin
            // 
            this.zemin.BackgroundImage = global::Tavla.Properties.Resources.tavla_zemin;
            this.zemin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zemin.Controls.Add(this.label2);
            this.zemin.Controls.Add(this.label1);
            this.zemin.Controls.Add(this.button2);
            this.zemin.Controls.Add(this.button1);
            this.zemin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zemin.Location = new System.Drawing.Point(0, 0);
            this.zemin.Name = "zemin";
            this.zemin.Size = new System.Drawing.Size(933, 547);
            this.zemin.TabIndex = 0;
            this.zemin.Paint += new System.Windows.Forms.PaintEventHandler(this.zemin_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(663, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Siyah Zarı:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(196, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Beyaz Zarı:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(452, 277);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 24);
            this.button2.TabIndex = 1;
            this.button2.Text = "Tur";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(452, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "zar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Tavla.Properties.Resources.tavla_zemin;
            this.ClientSize = new System.Drawing.Size(933, 547);
            this.Controls.Add(this.zemin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.zemin.ResumeLayout(false);
            this.zemin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel zemin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

