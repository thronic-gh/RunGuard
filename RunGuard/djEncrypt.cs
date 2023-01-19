using System;

namespace RunGuard
{
	class djEncrypt
	{
		public static string PassDecryptKey = "dUFt8.VX2YGSzK jhL9cTBs5P4wpgAZJMl1E6kr;ICNimDOuHeqvyonaRbWQx70f3_!-";

		public static string Encrypt(string s)
		{
			//
			// s is a random string to be encrypted.
			// key is a randomized string that must contain all
			// the characters found in s as an absolute minimum.
			//

			try {
				if (s == "")
					return "";

				char[] key_chars = PassDecryptKey.ToCharArray();
				char[] string_chars = s.ToCharArray();
				string key_coords = "";
				string key_coords_lengths = "";

				foreach (char c in string_chars) {
					for (int n=0; n<key_chars.Length; n++) {
						if (c == key_chars[n]) {
							key_coords += n.ToString();
							key_coords_lengths += n.ToString().Length.ToString();
						}
					}
				}

				return key_coords +"-"+ key_coords_lengths;
			
			} catch (Exception) {
				
				// Perhaps we got a bad string, could happen. Politely just say no.
				return "";
			}
		}

		public static string Decrypt(string s)
		{
			//
			// s is the output from djEncryptString().
			// key is the same key as used to encrypt with.
			//

			try {
				if (s == "")
					return "";

				char[] key_chars = PassDecryptKey.ToCharArray();
				string key_coords = s.Split('-')[0];
				char[] key_coords_lengths = s.Split('-')[1].ToCharArray();
				string DecryptedString = "";

				foreach (char c in key_coords_lengths) {
					DecryptedString += key_chars[
						Int32.Parse(key_coords.Substring(0,(int)Char.GetNumericValue(c)))
					];
					key_coords = key_coords.Substring((int)Char.GetNumericValue(c));
				}
			
				return DecryptedString;
			
			} catch (Exception) {

				// Perhaps we got a bad string, could happen. Politely just say no.
				return "";
			}
		}
	}
}
