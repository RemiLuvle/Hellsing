using System;
using System.Windows.Forms;

namespace HellsingPc.Patches
{
    internal class SendToClip
    {
        public static string RandomString(int length)
        {
            string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!§$%&/()=?";
            string text2 = "";
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                text2 += text[random.Next(text.Length - 1)].ToString();
            }
            return text2;
        }

        internal static string GetClipboard()
        {
            if (Clipboard.ContainsText())
            {
                return Clipboard.GetText();
            }
            return "";
        }

        internal static void SetClipboard(string Set)
        {
            if (Clipboard.ContainsText())
            {
                Clipboard.Clear();
                Clipboard.SetText(Set);
            }
            Clipboard.SetText(Set);
        }
    }
}

