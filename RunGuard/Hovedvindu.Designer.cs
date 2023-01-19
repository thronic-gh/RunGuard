namespace RunGuard
{
	partial class Hovedvindu
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hovedvindu));
			this.txtAddProgram = new System.Windows.Forms.TextBox();
			this.lstAllowedPrograms = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnRemove = new System.Windows.Forms.Button();
			this.picboxOnOff = new System.Windows.Forms.PictureBox();
			this.lblOnOffStatus = new System.Windows.Forms.Label();
			this.btnUninstall = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.picboxOnOff)).BeginInit();
			this.SuspendLayout();
			// 
			// txtAddProgram
			// 
			this.txtAddProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtAddProgram.BackColor = System.Drawing.Color.White;
			this.txtAddProgram.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtAddProgram.Location = new System.Drawing.Point(12, 246);
			this.txtAddProgram.Name = "txtAddProgram";
			this.txtAddProgram.Size = new System.Drawing.Size(207, 21);
			this.txtAddProgram.TabIndex = 6;
			this.txtAddProgram.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddProgram_KeyPress);
			// 
			// lstAllowedPrograms
			// 
			this.lstAllowedPrograms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.lstAllowedPrograms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstAllowedPrograms.FormattingEnabled = true;
			this.lstAllowedPrograms.Location = new System.Drawing.Point(12, 93);
			this.lstAllowedPrograms.Name = "lstAllowedPrograms";
			this.lstAllowedPrograms.ScrollAlwaysVisible = true;
			this.lstAllowedPrograms.Size = new System.Drawing.Size(207, 145);
			this.lstAllowedPrograms.Sorted = true;
			this.lstAllowedPrograms.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.DimGray;
			this.label1.Location = new System.Drawing.Point(22, 308);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(183, 13);
			this.label1.TabIndex = 1000;
			this.label1.Text = "© 2018 Dag J Nedrelid | Thronic.com";
			// 
			// btnRemove
			// 
			this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnRemove.BackColor = System.Drawing.Color.White;
			this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
			this.btnRemove.FlatAppearance.BorderSize = 0;
			this.btnRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Azure;
			this.btnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
			this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRemove.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRemove.ForeColor = System.Drawing.Color.DeepSkyBlue;
			this.btnRemove.Location = new System.Drawing.Point(12, 273);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(111, 22);
			this.btnRemove.TabIndex = 7;
			this.btnRemove.Text = "Remove selected";
			this.btnRemove.UseVisualStyleBackColor = false;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// picboxOnOff
			// 
			this.picboxOnOff.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picboxOnOff.Image = global::RunGuard.Properties.Resources.switch_off;
			this.picboxOnOff.Location = new System.Drawing.Point(12, 12);
			this.picboxOnOff.Name = "picboxOnOff";
			this.picboxOnOff.Size = new System.Drawing.Size(207, 59);
			this.picboxOnOff.TabIndex = 8;
			this.picboxOnOff.TabStop = false;
			this.picboxOnOff.Click += new System.EventHandler(this.picboxOnOff_Click);
			// 
			// lblOnOffStatus
			// 
			this.lblOnOffStatus.AutoSize = true;
			this.lblOnOffStatus.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblOnOffStatus.Location = new System.Drawing.Point(8, 74);
			this.lblOnOffStatus.Name = "lblOnOffStatus";
			this.lblOnOffStatus.Size = new System.Drawing.Size(46, 18);
			this.lblOnOffStatus.TabIndex = 1;
			this.lblOnOffStatus.Text = "Status";
			// 
			// btnUninstall
			// 
			this.btnUninstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnUninstall.BackColor = System.Drawing.Color.White;
			this.btnUninstall.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnUninstall.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
			this.btnUninstall.FlatAppearance.BorderSize = 0;
			this.btnUninstall.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Azure;
			this.btnUninstall.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
			this.btnUninstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUninstall.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUninstall.ForeColor = System.Drawing.Color.DeepSkyBlue;
			this.btnUninstall.Location = new System.Drawing.Point(140, 273);
			this.btnUninstall.Name = "btnUninstall";
			this.btnUninstall.Size = new System.Drawing.Size(79, 22);
			this.btnUninstall.TabIndex = 8;
			this.btnUninstall.Text = "Uninstall";
			this.btnUninstall.UseVisualStyleBackColor = false;
			this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
			// 
			// Hovedvindu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(231, 330);
			this.Controls.Add(this.btnUninstall);
			this.Controls.Add(this.lblOnOffStatus);
			this.Controls.Add(this.picboxOnOff);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lstAllowedPrograms);
			this.Controls.Add(this.txtAddProgram);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(247, 2000);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(247, 369);
			this.Name = "Hovedvindu";
			this.Text = "RunGuard";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Hovedvindu_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.picboxOnOff)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox txtAddProgram;
		private System.Windows.Forms.ListBox lstAllowedPrograms;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.PictureBox picboxOnOff;
		private System.Windows.Forms.Label lblOnOffStatus;
		private System.Windows.Forms.Button btnUninstall;
	}
}