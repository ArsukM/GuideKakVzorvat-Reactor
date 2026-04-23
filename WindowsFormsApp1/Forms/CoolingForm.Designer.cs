namespace WindowsFormsApp1
{
    partial class CoolingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.coolingBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 48);
            this.label1.TabIndex = 5;
            this.label1.Text = "На сколько сильно хочешь охладить?\r\nМинимум: 1\r\nМаксимум: 30\r\n";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(87, 243);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(127, 22);
            this.textBox1.TabIndex = 4;
            // 
            // coolingBtn
            // 
            this.coolingBtn.Location = new System.Drawing.Point(87, 91);
            this.coolingBtn.Name = "coolingBtn";
            this.coolingBtn.Size = new System.Drawing.Size(127, 69);
            this.coolingBtn.TabIndex = 3;
            this.coolingBtn.Text = "ОХЛАДИТЬ";
            this.coolingBtn.UseVisualStyleBackColor = true;
            this.coolingBtn.Click += new System.EventHandler(this.coolingBtn_Click);
            // 
            // CoolingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.coolingBtn);
            this.Name = "CoolingForm";
            this.Text = "CoolingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button coolingBtn;
    }
}