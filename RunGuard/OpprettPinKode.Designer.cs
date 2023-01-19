namespace RunGuard
{
	partial class OpprettPinKode
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
			this.lblRemember = new System.Windows.Forms.Label();
			this.txtPIN1 = new System.Windows.Forms.TextBox();
			this.txtPIN2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPIN3 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblRemember
			// 
			this.lblRemember.AutoSize = true;
			this.lblRemember.BackColor = System.Drawing.Color.Transparent;
			this.lblRemember.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblRemember.Location = new System.Drawing.Point(12, 22);
			this.lblRemember.Name = "lblRemember";
			this.lblRemember.Size = new System.Drawing.Size(357, 13);
			this.lblRemember.TabIndex = 0;
			this.lblRemember.Text = "YOU CAN ONLY DO THIS ONCE - REMEMBER YOUR CODE.";
			// 
			// txtPIN1
			// 
			this.txtPIN1.Location = new System.Drawing.Point(14, 70);
			this.txtPIN1.MaxLength = 4;
			this.txtPIN1.Name = "txtPIN1";
			this.txtPIN1.Size = new System.Drawing.Size(48, 20);
			this.txtPIN1.TabIndex = 1;
			this.txtPIN1.UseSystemPasswordChar = true;
			// 
			// txtPIN2
			// 
			this.txtPIN2.Location = new System.Drawing.Point(84, 70);
			this.txtPIN2.MaxLength = 4;
			this.txtPIN2.Name = "txtPIN2";
			this.txtPIN2.Size = new System.Drawing.Size(48, 20);
			this.txtPIN2.TabIndex = 2;
			this.txtPIN2.UseSystemPasswordChar = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(68, 73);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(10, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "-";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(138, 73);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(10, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "-";
			// 
			// txtPIN3
			// 
			this.txtPIN3.Location = new System.Drawing.Point(154, 70);
			this.txtPIN3.MaxLength = 4;
			this.txtPIN3.Name = "txtPIN3";
			this.txtPIN3.Size = new System.Drawing.Size(48, 20);
			this.txtPIN3.TabIndex = 3;
			this.txtPIN3.UseSystemPasswordChar = true;
			// 
			// button1
			// 
			this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(220, 63);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(142, 33);
			this.button1.TabIndex = 4;
			this.button1.Text = "Create Admin PIN";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(18, 52);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(181, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "REPEAT IT IN ALL 3 BOXES.";
			// 
			// OpprettPinKode
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(375, 108);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtPIN3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtPIN2);
			this.Controls.Add(this.txtPIN1);
			this.Controls.Add(this.lblRemember);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "OpprettPinKode";
			this.Text = "Create a PIN code";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblRemember;
		private System.Windows.Forms.TextBox txtPIN1;
		private System.Windows.Forms.TextBox txtPIN2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPIN3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label3;
	}
}