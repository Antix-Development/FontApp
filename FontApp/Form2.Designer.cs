namespace FontApp
{
    partial class Form2
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
            AboutOkay_Button = new Button();
            linkLabel1 = new LinkLabel();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            linkLabel2 = new LinkLabel();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // AboutOkay_Button
            // 
            AboutOkay_Button.Location = new Point(325, 133);
            AboutOkay_Button.Name = "AboutOkay_Button";
            AboutOkay_Button.Size = new Size(127, 23);
            AboutOkay_Button.TabIndex = 0;
            AboutOkay_Button.Text = "Okay";
            AboutOkay_Button.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(146, 101);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(181, 15);
            linkLabel1.TabIndex = 3;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Visit FontApp GitHub  repository.";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.f128;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(128, 128);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(146, 71);
            label3.Name = "label3";
            label3.Size = new Size(245, 15);
            label3.TabIndex = 5;
            label3.Text = "Copyright 2023 Cliff Earl, Antix Development.";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(146, 131);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(100, 15);
            linkLabel2.TabIndex = 8;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Buy Cliff a coffee.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(146, 41);
            label4.Name = "label4";
            label4.Size = new Size(304, 15);
            label4.TabIndex = 10;
            label4.Text = "A simple bitmap font generator for 2D game developers.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(146, 11);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 11;
            label5.Text = "FontApp.";
            // 
            // Form2
            // 
            AcceptButton = AboutOkay_Button;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = AboutOkay_Button;
            ClientSize = new Size(464, 168);
            ControlBox = false;
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(linkLabel2);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(linkLabel1);
            Controls.Add(AboutOkay_Button);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form2";
            ShowIcon = false;
            Text = "About";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AboutOkay_Button;
        private LinkLabel linkLabel1;
        private PictureBox pictureBox1;
        private Label label3;
        private LinkLabel linkLabel2;
        private Label label4;
        private Label label5;
    }
}