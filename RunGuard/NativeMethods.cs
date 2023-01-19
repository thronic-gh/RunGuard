using System;
using System.Runtime.InteropServices;

namespace RunGuard
{
	class NativeMethods
	{
		[DllImport("user32.dll")]
		private static extern IntPtr SendMessageTimeout(
			IntPtr hWnd,
			uint Msg,
			IntPtr wParam,
			UIntPtr lParam,
			uint fuFlags,
			uint uTimeout,
			out UIntPtr lpdwResult
		);

		public static IntPtr SendMessageTimeoutWrapper() 
		{
			IntPtr HWND_BROADCAST = (IntPtr)0xFFFF;
			uint WM_SETTINGCHANGE = 0x001A;
			uint SMTO_NORMAL = 0x0000;
			uint SMTO_NOTIMEOUTIFNOTHUNG = 0x0008;
			uint uTimeout = 2000;
			UIntPtr lpdwResult;

			//
			//	Broadcast changes to the system.
			//
			return SendMessageTimeout(
				HWND_BROADCAST, 
				WM_SETTINGCHANGE, 
				IntPtr.Zero, 
				UIntPtr.Zero, 
				SMTO_NORMAL | SMTO_NOTIMEOUTIFNOTHUNG, 
				uTimeout, 
				out lpdwResult
			);
		}
	}
}
