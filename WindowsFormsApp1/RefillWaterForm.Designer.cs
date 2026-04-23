namespace WindowsFormsApp1
{
    partial class RefillWaterForm
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
            this.refillBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // refillBtn
            // 
            this.refillBtn.Location = new System.Drawing.Point(73, 125);
            this.refillBtn.Name = "refillBtn";
            this.refillBtn.Size = new System.Drawing.Size(127, 69);
            this.refillBtn.TabIndex = 0;
            this.refillBtn.Text = "ДОЛИТЬ";
            this.refillBtn.UseVisualStyleBackColor = true;
            this.refillBtn.Click += new System.EventHandler(this.refillBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(73, 277);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(127, 22);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 48);
            this.label1.TabIndex = 2;
            this.label1.Text = "На сколько % залить воды?\r\nМинимум: 1%\r\nМаксимум: 30%";
            // 
            // RefillWaterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 452);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.refillBtn);
            this.Name = "RefillWaterForm";
            this.Text = "RefillWaterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refillBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}