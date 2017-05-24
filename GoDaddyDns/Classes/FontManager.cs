//**********************************************************************************************************
// The code below is a modified version of the code available at http://stackoverflow.com/a/23519499/1180928
//
//**********************************************************************************************************

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDaddyDns
{
    public class FontLoader
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection _fonts = new PrivateFontCollection();

        public FontLoader() { }

        public Font Load(string familyName, float emSize, FontStyle style)
        {
            if (String.IsNullOrWhiteSpace(familyName))
                return null;

            if (!_fonts.Families.Any(f => f.Name.ToLower() == familyName.ToLower()))
            {
                byte[] fontData = (byte[])Properties.Resources.ResourceManager.GetObject(familyName);

                IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);

                try
                {
                    System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);

                    uint dummy = 0;

                    _fonts.AddMemoryFont(fontPtr, Properties.Resources.FontAwesome.Length);

                    AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.FontAwesome.Length, IntPtr.Zero, ref dummy);
                }
                finally
                {
                    System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
                }
            }

            var fontFamily = _fonts.Families.Where(f => f.Name == familyName).First();

            return new Font(fontFamily, emSize, style);
        }
    }
}
