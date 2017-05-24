//**********************************************************************************************************
// The code below is a modified version of the code available at http://stackoverflow.com/a/23519499/1180928
//
//**********************************************************************************************************

using System;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;

namespace GoDaddyDns
{
    /// <summary>
    /// This class is used to load fonts stored inside the application's resource file
    /// so they can be used as if they were installed in the user's machine.
    /// </summary>
    public class FontLoader
    {
        #region Fields
        /// <summary>
        /// Stores the fonts loaded using <see cref="Load(string, float, FontStyle)" />.
        /// </summary>
        private PrivateFontCollection _fonts = new PrivateFontCollection(); 
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of the FontLoader class.
        /// </summary>
        public FontLoader() { } 
        #endregion

        #region Methods
        /// <summary>
        /// Loads the specified font from the application's resource file and creates a new instance
        /// of it.
        /// </summary>
        /// <param name="familyName">The family of the font to be loaded.</param>
        /// <param name="emSize">The size of the font to be created.</param>
        /// <param name="style">The style of the font to be created.</param>
        /// <returns>Returns a <see cref="Font"/> with its <see cref="Font.Size"/> and
        /// <see cref="Font.Style"/> defined using the paramters informed. Returns null if the font can't be instantied.</returns>
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
                catch
                {
                    return null;
                }
                finally
                {
                    System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
                }
            }

            var fontFamily = _fonts.Families.Where(f => f.Name == familyName).First();

            return new Font(fontFamily, emSize, style);
        }

        /// <summary>
        /// The AddFontMemResourceEx function adds the font resource from a memory image to the system.
        /// </summary>
        /// <param name="pbFont">A pointer to a font resource.</param>
        /// <param name="cbFont">The number of bytes in the font resource that is pointed to by pbFont.</param>
        /// <param name="pdv">Reserved. Must be 0.</param>
        /// <param name="pcFonts">A pointer to a variable that specifies the number of fonts installed.</param>
        /// <returns>If the function succeeds, the return value specifies the handle to the font added. 
        /// This handle uniquely identifies the fonts that were installed on the system. If the function fails, 
        /// the return value is zero. No extended error information is available.</returns>
        /// <remarks>This function allows an application to get a font that is embedded in a document or a 
        /// webpage. A font that is added by AddFontMemResourceEx is always private to the process that made the 
        /// call and is not enumerable. A memory image can contain more than one font.When this function succeeds, 
        /// pcFonts is a pointer to a DWORD whose value is the number of fonts added to the system as a result of 
        /// this call.For example, this number could be 2 for the vertical and horizontal faces of an Asian font. 
        /// When the function succeeds, the caller of this function can free the memory pointed to by pbFont 
        /// because the system has made its own copy of the memory. To remove the fonts that were installed, call 
        /// RemoveFontMemResourceEx. However, when the process goes away, the system will unload the fonts even 
        /// if the process did not call RemoveFontMemResource.</remarks>
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        #endregion
    }
}
