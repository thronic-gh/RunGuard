using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace RunGuard
{
	public partial class Hovedvindu : Form
	{
		private bool IsOnOff = false;
		private bool LoggedInAlready = false;
		private bool FirstRun = false;
		private static string TagFile = @"C:\ProgramData\RgPrevInst.tag";
		private static string InstallDirectory = @"C:\RunGuard\";
		private static string CurrentFullFilePath = Assembly.GetExecutingAssembly().Location;
		private static string CurrentExeDir = Path.GetDirectoryName(CurrentFullFilePath);
		private static string CurrentExeName = Path.GetFileName(CurrentFullFilePath);
		private static string RandomFilenameSeed = "abcdefghijklmnopqrstuvwxyz0123456789";
		private static char[] RandomFilenameChars = RandomFilenameSeed.ToCharArray();

		public Hovedvindu(string[] args)
		{
			InitializeComponent();

			//
			//	Check if we are running from the proper location.
			//
			try {
			FirstRunCheck();

			if (CurrentExeDir +@"\" != InstallDirectory || CurrentExeName != InstalledFilename()) {
				
				// Copy ourself onto the system.
				Directory.CreateDirectory(InstallDirectory);
				File.Copy(CurrentFullFilePath, InstallDirectory + InstalledFilename(), true);

				// Execute ourselves.
				MasterRunnerExecutables(InstallDirectory + InstalledFilename(), "", false);

				// Exit this instance.
				Environment.Exit(0);
			
			}} catch (Exception e) {
				MessageBox.Show("A filing problem occurred while starting up.\n"+ e.Message, "Unexpected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			this.Text = "RunGuard v" +
				Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." +
				Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString() + "." +
				Assembly.GetExecutingAssembly().GetName().Version.Build.ToString();
			
			txtAddProgram.Select();
			LoadAndCheckSettings();
			LoadAllowedList();

			if (CheckOnOff()) {
				picboxOnOff.Image = Properties.Resources.switch_on;
				IsOnOff = true;
				lblOnOffStatus.Text = "Allow only listed programs to run.";
			} else {
				picboxOnOff.Image = Properties.Resources.switch_off;
				IsOnOff = false;
				lblOnOffStatus.Text = "     Allows ALL programs to run.";
			}
		}

		//
		//	Figure out if it's the first time we ever run, to avoid 
		//	self-destruct and give user a chance to copy the admin file.
		//
		private void FirstRunCheck()
		{
			string RunKey = @"Software\Thronic.com\RunGuard";
			if (Registry.CurrentUser.OpenSubKey(RunKey, false) != null) {
				using (RegistryKey RK = Registry.CurrentUser.OpenSubKey(RunKey, true))
				{
					if (RK.GetValue("FirstRunEver") != null) {
						FirstRun = true;
						RK.DeleteValue("FirstRunEver");
						return;
					}
				}
			}

			FirstRun = false;
		}

		//
		//	Retrieves the installed filename from registry.
		//	Or registers a new one if one does not exist.
		//
		private string InstalledFilename()
		{
			string fn = "RunGuardPatrol.exe";
			Random rnd = new Random();

			// Use an existing if it exists.
			string RunKey = @"Software\Thronic.com\RunGuard";
			if (Registry.CurrentUser.OpenSubKey(RunKey, false) != null) {
				using (RegistryKey RK = Registry.CurrentUser.OpenSubKey(RunKey, false))
				{
					if ((fn = RK.GetValue("InstalledFilename").ToString()) != null)
						return fn;
				}
			}

			// Create, register and return a new one.
			fn = "";
			for (int n=1; n<=10; n++)
				fn += RandomFilenameChars[rnd.Next(RandomFilenameChars.Length)].ToString();

			fn += ".exe";
			
			RunKey = @"Software";
			using (RegistryKey RK = Registry.CurrentUser.OpenSubKey(RunKey, true))
			{
				RK.CreateSubKey("Thronic.com");
				RK.CreateSubKey(@"Thronic.com\RunGuard");
				RK.Close();
			}
			using (RegistryKey RK = Registry.CurrentUser.OpenSubKey(RunKey +@"\Thronic.com\RunGuard", true))
			{
				RK.SetValue("InstalledFilename", fn, RegistryValueKind.String);
				RK.SetValue("FirstRunEver", 1, RegistryValueKind.DWord);
				RK.Close();
			}

			return fn;
		}

		private void LoadAndCheckSettings()
		{
			if (Properties.Settings.Default.NeedUpgrade) {
				Properties.Settings.Default.Upgrade();
				Properties.Settings.Default.NeedUpgrade = false;
				Properties.Settings.Default.Save();
			}
		}

		private void LoadAllowedList()
		{
			lstAllowedPrograms.Items.Clear();
			string[] AddedPrograms = djEncrypt.Decrypt(Properties.Settings.Default.AddedPrograms).Split(';');
			foreach (string s in AddedPrograms)
				if (s != "")
					lstAllowedPrograms.Items.Add(s);
		}

		private bool CheckOnOff()
		{
			try {
				string RunKey = @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\RestrictRun";
				if (Registry.CurrentUser.OpenSubKey(RunKey, false) == null)
					return false;
				else
					return true;
			
			} catch (Exception) {
				MessageBox.Show("Could not check registry for status.", "Unexpected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
		}

		private bool AllowListed()
		{
			//
			//	Configure GPO in Registry to allow only listed programs to run.
			//
			//	RestrictRun = Allow only these apps to run (we'll use this).
			//	DisallowRun = Disallow only these apps to run.
			//	

			if (!LoggedInAlready)
				if (!CheckOrCreatePinCode())
					return false;

			// Make registry changes.
			try
			{
				string RunKey = @"Software\Microsoft\Windows\CurrentVersion\Policies";
				using (RegistryKey RK = Registry.CurrentUser.OpenSubKey(RunKey, true))
				{
					RK.CreateSubKey("Explorer");
					RK.CreateSubKey(@"Explorer\RestrictRun");
					RK.Close();
				}

				using (RegistryKey RK = Registry.CurrentUser.OpenSubKey(RunKey +@"\Explorer", true))
				{
					RK.SetValue("RestrictRun", 1, RegistryValueKind.DWord);
					RK.Close();
				}

				using (RegistryKey RK = Registry.CurrentUser.OpenSubKey(RunKey +@"\Explorer\RestrictRun", true))
				{
					int n = 0;

					// Set values from list.
					for (n = 0; n < lstAllowedPrograms.Items.Count; n++) {
						RK.SetValue((n+1).ToString(), lstAllowedPrograms.Items[n].ToString(), RegistryValueKind.String);
					}

					// Always add ourselves.
					RK.SetValue((n+1).ToString(), InstalledFilename(), RegistryValueKind.String);
					//RK.SetValue((n+2).ToString(), "rmdir.exe", RegistryValueKind.String);
					//RK.SetValue((n+3).ToString(), "cmd.exe", RegistryValueKind.String);

					RK.Close();
				}

				if (NativeMethods.SendMessageTimeoutWrapper() == IntPtr.Zero) {
					MessageBox.Show("System could not be made aware of new changes.\nYou should do a reboot.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				} else {
					picboxOnOff.Image = Properties.Resources.switch_on;
					lblOnOffStatus.Text = "Allow only listed programs to run.";
					IsOnOff = true;
				}

				// Assume all went well.
				//MessageBox.Show("OK.", "FYI", MessageBoxButtons.OK, MessageBoxIcon.Information);

			} catch (Exception ee) {
				MessageBox.Show(ee.Message, "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			this.ActiveControl = null;

			return true;
		}

		private bool AllowAll()
		{
			//
			//	Configure GPO in Registry to allow all programs to run.
			//
			//	RestrictRun = Allow only these apps to run (we'll use this).
			//	DisallowRun = Disallow only these apps to run.
			//

			if (!LoggedInAlready)
				if (!CheckOrCreatePinCode())
					return false;

			// Make registry changes.
			try
			{
				string RunKey = @"Software\Microsoft\Windows\CurrentVersion\Policies";
				using (RegistryKey RK = Registry.CurrentUser.OpenSubKey(RunKey, true))
				{
					RK.DeleteSubKey(@"Explorer\RestrictRun", false);
					RK.DeleteSubKey(@"Explorer", false);
					RK.Close();
				}

				// Make system aware of new changes.
				if (NativeMethods.SendMessageTimeoutWrapper() == IntPtr.Zero) {
					MessageBox.Show("System could not be made aware of new changes.\nYou should do a reboot.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				} else {
					picboxOnOff.Image = Properties.Resources.switch_off;
					lblOnOffStatus.Text = "     Allows ALL programs to run.";
					IsOnOff = false;
				}

				// Assume all went well.
				//MessageBox.Show("OK.", "FYI", MessageBoxButtons.OK, MessageBoxIcon.Information);

			} catch (Exception ee) {
				MessageBox.Show(ee.Message,"Oops",MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			this.ActiveControl = null;

			return true;
		}

		private void AddProgramToList()
		{
			foreach (char c in txtAddProgram.Text.ToCharArray()) {
				if (!djEncrypt.PassDecryptKey.Contains(c.ToString()) || c == ';') {
					MessageBox.Show("Program has illegal characters.\nKeep it alphanumerical.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}

			if (lstAllowedPrograms.Items.Contains(txtAddProgram.Text)) {
				MessageBox.Show("That program is already listed.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

			} else if (txtAddProgram.Text != "") {
				
				// Check PIN
				if (!LoggedInAlready)
					if (!CheckOrCreatePinCode())
						return;
			
				lstAllowedPrograms.Items.Add(txtAddProgram.Text);

				// Save it in the system.
				string tmpPrograms = djEncrypt.Decrypt(Properties.Settings.Default.AddedPrograms);
				tmpPrograms += txtAddProgram.Text +";";
				Properties.Settings.Default.AddedPrograms = djEncrypt.Encrypt(tmpPrograms);
				Properties.Settings.Default.Save();

				// Update system.
				AllowListed();

				txtAddProgram.Text = "";
				txtAddProgram.Focus();
			}
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			if (lstAllowedPrograms.SelectedIndices.Count > 0) {
				
				if (!LoggedInAlready)
					if (!CheckOrCreatePinCode())
						return;

				// Save it in the system.
				string UpdatedAddedPrograms = "";
				string[] AddedPrograms = djEncrypt.Decrypt(Properties.Settings.Default.AddedPrograms).Split(';');
				foreach (string s in AddedPrograms)
					if (s != lstAllowedPrograms.Items[lstAllowedPrograms.SelectedIndex].ToString() && s != "")
						UpdatedAddedPrograms += s +";";

				Properties.Settings.Default.AddedPrograms = djEncrypt.Encrypt(UpdatedAddedPrograms);
				Properties.Settings.Default.Save();
				lstAllowedPrograms.Items.RemoveAt(lstAllowedPrograms.SelectedIndex);

				// Update system.
				AllowListed();
			}
		}

		private bool CheckOrCreatePinCode()
		{
			//
			//	Check first if PIN exists, if not - create one.
			//
			if (Properties.Settings.Default.PIN == "") {

				//
				//	Check if this has been done before.
				//
				if (File.Exists(TagFile)) {
					MessageBox.Show("Weird, setup seems tampered with.\nContact your administrator.", "Suspicious", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						return false;
				}

				OpprettPinKode f = new OpprettPinKode(TagFile);
				if (f.ShowDialog() != DialogResult.OK)
					return false;
			}

			//
			// A custom PIN code is already set or was just set above.
			//
			VerifyPin vf = new VerifyPin();
			if (vf.ShowDialog() == DialogResult.OK) {
				LoggedInAlready = true;
				return true;
			} else {
				return false;
			}

		}

		private void txtAddProgram_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter) {
				AddProgramToList();

			} else if (Char.IsLetterOrDigit(e.KeyChar)) {
				txtAddProgram.Text += e.KeyChar;
				txtAddProgram.SelectionStart = txtAddProgram.Text.Length;
			
			} else {
				return;
			}

			e.Handled = true;
		}

		private void picboxOnOff_Click(object sender, EventArgs e)
		{
			if (IsOnOff) {

				// Allow ALL programs to run.
				if (!AllowAll())
					return;

				// Update picture.
				picboxOnOff.Image = Properties.Resources.switch_off;

				// Update status text.
				lblOnOffStatus.Text = "     Allows ALL programs to run.";
				
				IsOnOff = false;

			} else {

				// Allow only listed programs to run.
				if (!AllowListed())
					return;

				// Update picture.
				picboxOnOff.Image = Properties.Resources.switch_on;

				// Update status text.
				lblOnOffStatus.Text = "Allow only listed programs to run.";

				IsOnOff = true;
			}
		}

		private void btnUninstall_Click(object sender, EventArgs e)
		{
			if (!LoggedInAlready)
				if (!CheckOrCreatePinCode())
					return;

			// Remove registry settings and make system aware.
			AllowAll();
			string RunKey = @"Software";
			using (RegistryKey RK = Registry.CurrentUser.OpenSubKey(RunKey, true))
			{
				RK.DeleteSubKey(@"Thronic.com\RunGuard", false);
				RK.Close();
			}

			// Remove system files.
			File.Delete(TagFile);

			// Reset settings.
			Properties.Settings.Default.Reset();
			Properties.Settings.Default.NeedUpgrade = false;
			Properties.Settings.Default.Save();

			// Reload list.
			LoadAllowedList();

			// Make current PIN invalid.
			LoggedInAlready = false;

			MessageBox.Show("Done. It's almost like I was never here.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

			SelfDestruct();
			Environment.Exit(0);
		}

		//
		//	Will fire off a 3 second timer to attempt self-destruction for security reasons.
		//
		private void SelfDestruct()
		{
			try {
				Process p = new Process();
				p.StartInfo.UseShellExecute = true;
				p.StartInfo.FileName = "cmd.exe";
				p.StartInfo.Arguments = "/C choice /C Y /N /D Y /T 3 & RMDIR /S /Q \""+ InstallDirectory +"\"";
				p.StartInfo.RedirectStandardOutput = false;
				p.StartInfo.RedirectStandardError = false;
				p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				p.StartInfo.CreateNoWindow = true;
				p.Start();

			} catch (Exception) {}
		}

		private void OpenInstallDir()
		{
			MasterRunnerExecutables("explorer.exe", InstallDirectory, false);
		}

		//
		//	Mesterfunksjon for kjøring av eksekverbare filer.
		//
		private void MasterRunnerExecutables(string s, string args, bool WaitForExit)
		{
			try {
			Process p = new Process();
			p.StartInfo.UseShellExecute = false;
			p.StartInfo.FileName = s;
			p.StartInfo.Arguments = args;
			p.StartInfo.RedirectStandardOutput = true;
			p.StartInfo.RedirectStandardError = true;
			p.StartInfo.StandardOutputEncoding = Encoding.ASCII;
			p.StartInfo.StandardErrorEncoding = Encoding.ASCII;
			p.Start();

			if (WaitForExit)
				p.WaitForExit();

			} catch (Exception ee) {
				MessageBox.Show("Oops? "+ ee.Message);
			}
		}

		private void Hovedvindu_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (CurrentExeDir +@"\" == InstallDirectory && LoggedInAlready && FirstRun) {
				OpenInstallDir();
				MessageBox.Show("Make an external copy of "+ InstallDirectory + InstalledFilename() +" for redundant future access to this system!\n\nSystem is PIN protected, but you can also delete it from the computer for security reasons if PIN is not enough.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
			} else if (IsOnOff) {
				//OpenInstallDir();
				//MessageBox.Show("Done? Remember to DELETE THE LOCAL RunGuard EXECUTABLE for security reasons.\n\nKeep your own copy safe on a USB drive or somewhere external.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			} else {
				// SelfDestruct();
			}
		}
	}
}
