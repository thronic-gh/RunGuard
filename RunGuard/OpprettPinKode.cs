using System;
using System.IO;
using System.Windows.Forms;

namespace RunGuard
{
	public partial class OpprettPinKode : Form
	{
		private string TagFile = "";

		public OpprettPinKode(string TagFile)
		{
			InitializeComponent();
			this.TagFile = TagFile;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int PIN;
			if (
				txtPIN1.Text == "" || !Int32.TryParse(txtPIN1.Text, out PIN) || 
				txtPIN1.Text != txtPIN2.Text || txtPIN1.Text != txtPIN3.Text
			) {
				MessageBox.Show("Please verify your input.\nNot matching or not numeric.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			// Register PIN.
			Properties.Settings.Default.PIN = djEncrypt.Encrypt(txtPIN1.Text);
			Properties.Settings.Default.Save();

			// Tag the system that this has been done.
			try {
				using (File.Create(TagFile)) {}
				File.SetAttributes(TagFile, File.GetAttributes(TagFile) | FileAttributes.Hidden);
			
			} catch (Exception) {}

			this.DialogResult = DialogResult.OK;

			MessageBox.Show("PIN has been saved - REMEMBER IT.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			this.Close();
		}
	}
}
