namespace RunGuard
{
	partial class VerifyPin
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
			this.txtPIN = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtPIN
			// 
			this.txtPIN.Location = new System.Drawing.Point(96, 15);
			this.txtPIN.MaxLength = 4;
			this.txtPIN.Name = "txtPIN";
			this.txtPIN.Size = new System.Drawing.Size(100, 20);
			this.txtPIN.TabIndex = 0;
			this.txtPIN.UseSystemPasswordChar = true;
			this.txtPIN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPIN_KeyUp);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(34, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Enter PIN:";
			// 
			// VerifyPin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(232, 47);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtPIN);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "VerifyPin";
			this.Text = "Verify PIN";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtPIN;
		private System.Windows.Forms.Label label1;
	}
}