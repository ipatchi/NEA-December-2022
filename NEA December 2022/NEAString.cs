using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_December_2022
{
    internal class NEAString
    {
        public Color TranslateColour(string colour)
        {
            if (colour != "DEFAULT")
            {
                bool argbformat = false;
                foreach (char character in colour)
                {
                    if (character == ',')
                    {
                        argbformat = true;
                    }
                }
                if (argbformat)
                {
                    string colourstring = colour;

                    colourstring = colourstring.Substring(7, colourstring.Length - 8);
                    

                    string[] parts = new string[4];
                    parts = colourstring.Split(',');

                    for (int i = 0; i < parts.Length; i++)
                    {
                        parts[i] = parts[i].Substring(3, parts[i].Length - 3);
                    }

                    return Color.FromArgb(255, Convert.ToInt32(parts[1]),
                        Convert.ToInt32(parts[2]), Convert.ToInt32(parts[3]));
                }
                else
                {
                    string colourstring = colour;

                    colourstring = colourstring.Substring(7, colourstring.Length - 8);
                    return ColorTranslator.FromHtml(colourstring);
                }
            }

            return Color.AliceBlue;
        }
    }
}
