using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Text;

namespace RestaurantReview
{
    class FontManager
    {
        private static FontManager instance = new FontManager();
        public PrivateFontCollection privateFont = new PrivateFontCollection();
        public static FontFamily[] fontFamilys
        {
            get
            {
                return instance.privateFont.Families;
            }
        }

        public FontManager()
        {
            AddFontFromMemory();
        }

        private void AddFontFromMemory()
        {
            List<byte[]> fonts = new List<byte[]>();

            fonts.Add(Properties.Resources.SCDream2); //SCDream2
            fonts.Add(Properties.Resources.SCDream3); //SCDream3
            fonts.Add(Properties.Resources.SCDream4); //SCDream4

            foreach (byte[] font in fonts)
            {
                IntPtr fontBuf = Marshal.AllocCoTaskMem(font.Length);
                Marshal.Copy(font, 0, fontBuf, font.Length);
                privateFont.AddMemoryFont(fontBuf, font.Length);

                Marshal.FreeHGlobal(fontBuf); //메모리 해제
            }
        }
    }
}
