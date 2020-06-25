namespace NetworkManager
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
            this.resultBox = new System.Windows.Forms.RichTextBox();
            this.startAndStop = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // resultBox
            // 
            this.resultBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultBox.Location = new System.Drawing.Point(40, 69);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(438, 356);
            this.resultBox.TabIndex = 0;
            this.resultBox.Text = "";
            // 
            // startAndStop
            // 
            this.startAndStop.Location = new System.Drawing.Point(221, 22);
            this.startAndStop.Name = "startAndStop";
            this.startAndStop.Size = new System.Drawing.Size(88, 32);
            this.startAndStop.TabIndex = 1;
            this.startAndStop.Text = "Start";
            this.startAndStop.UseVisualStyleBackColor = true;
            this.startAndStop.Click += new System.EventHandler(this.Start_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(365, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Clear);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.startAndStop);
            this.Controls.Add(this.resultBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox resultBox;
        private System.Windows.Forms.Button startAndStop;
        private System.Windows.Forms.Button button1;
    }
}

