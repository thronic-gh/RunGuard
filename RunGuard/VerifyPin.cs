using System.Windows.Forms;

namespace RunGuard
{
	public partial class VerifyPin : Form
	{
		public VerifyPin()
		{
			InitializeComponent();
		}

		private bool Authenticate()
		{
			if (djEncrypt.Decrypt(Properties.Settings.Default.PIN) == txtPIN.Text) {
				this.DialogResult = DialogResult.OK;
				return true;
			} else {
				MessageBox.Show("Incorrect PIN.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtPIN.Text = "";
				return false;
			}
		}

		private void txtPIN_KeyUp(object sender, KeyEventArgs e)
		{
			if (txtPIN.Text.Length < 4)
				return;

			if (Authenticate()) {
				this.Close();
			}
		}
	}
}
