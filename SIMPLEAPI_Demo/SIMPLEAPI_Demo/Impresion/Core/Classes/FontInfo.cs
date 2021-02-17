using System;
using System.Drawing;

namespace SIMPLEAPI_Demo.Impresion.Core.Classes
{
    public static class FontInfo
    {
        public const string FontName = "Consolas"; // if changed, change max chars per font size table in method GetMaxChars(font)

        public static int GetMaxChars(int fontSize, FontStyle fontStyle, bool testing = false)
        {
            return GetMaxChars(new Font(FontName, fontSize, fontStyle), testing);
        }
        public static int GetMaxChars(Font font, bool testing = false)
        {
            if (testing)
                return 100;

            if (font.FontFamily.Name != FontName)
                throw new Exception("Font not supported");

            int fontSize = (int)font.Size;

            if (font.Style == FontStyle.Bold)
            {
                if (fontSize == 7) return 52;
                else if (fontSize == 8) return 45;
                else if (fontSize == 10) return 36;
                else if (fontSize == 12) return 15;
                else
                    throw new Exception("fontSize not permitted");
            }
            else if (font.Style == FontStyle.Italic)
            {
                if (fontSize == 7) return 52;
                else if (fontSize == 8) return 45;
                else if (fontSize == 10) return 36;
                else if (fontSize == 12) return 15;
                else
                    throw new Exception("fontSize not permitted");
            }
            else
            {
                if (fontSize == 7) return 52;
                else if (fontSize == 8) return 45;
                else if (fontSize == 10) return 36;
                else if (fontSize == 12) return 15;
                else
                    throw new Exception("fontSize not permitted");
            }
        }
    }
}
