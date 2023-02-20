using SQLitePCL;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
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
    internal class NEAFonts : NEAString
    {
        public string Font = "";
        public string GetFont()
        {
            return Font;
        }

        public void SetFont(string f)
        {
            Font = f;
        }

        public Font GetFontAsFont()
        {
            var Convert = new FontConverter();
            Font f = Convert.ConvertFromString(Font) as Font;
            return f;
        }
        public string MakeFontString(Font theFont)
        {
            var Convert = new FontConverter();
            String f = Convert.ConvertToString(theFont);
            return f;
        }
    }

    internal class NEASortSearch
    {
        public int[] ints;
        static bool ran = false;

        public void SetArray(int[] ar)
        {
            ints = ar;
        }

        public int[] GetArray()
        {
            //MessageBox.Show("Get array called of values:" + PrintArray(ints));
            int[] ar = new int[ints.Length];
            Array.Copy(ints, 0, ar, 0, ints.Length);
            return ar;
        }

        public void SetArrayFromString(string[] strar)
        {
            int[] ar = new int[strar.Length];
            for (int i = 0; i < ar.Length; i++)
            {
                char c = strar[i].ToUpper()[0];
                ar[i] = c;
            }
            ints = ar;
        }


        public int SearchArray(int keynum, int[] ar) //Binary Search
        {
            bool found = false;
            int fp = 0;
            int bp = ar.Length - 1;
            while (!found)
            {
                int mp = (fp + bp) / 2;
                if (fp == mp)
                {
                   // MessageBox.Show("didnt find FP: " + fp + " BP: " + bp + " MP: " + mp);
                    found = true;
                }

                if (keynum > ar[mp])
                {
                    //MessageBox.Show("bigger FP: " + fp + " BP: " + bp + " MP: " + mp);
                    fp = mp;
                    
                }
                if (keynum < ar[mp])
                {
                    //MessageBox.Show("smaller FP: " + fp + " BP: " + bp + " MP: " + mp);
                    bp = mp;
                }
                if (ar[mp] == keynum)
                {
                    //MessageBox.Show("FOUND FP: " + fp + " BP: " + bp + " MP: " + mp);
                    found = true;
                    return mp;
                    
                }
                
            }
           
            return -1;
        }






        public int[] RunMerge()
        {
            return MergeSort(ints);
        }

        private int[] MergeSort(int[] ar, int gs = 2)
        {
            PrintArray(ar);
            for (int i = 0; i < (ar.Length / gs); i++)
            {
                int[] range = (ar.Skip(i * gs).ToArray()).Take(gs).ToArray(); ;
                int mid = range.Length / 2;
                int[] LHS = range.Take(mid).ToArray();
                int[] RHS = range.Skip(mid).ToArray();

                int[] semi = MergeTwoArrays(LHS, RHS);

                PrintArray(semi);
                for (int j = 0; j < gs; j++)
                {
                    ar[gs * i + j] = semi[j];
                }

            }

            if (gs <= ar.Length)
            {
                gs = gs * 2;
                return MergeSort(ar, gs);
            }

            int r = gs - ar.Length;
            Console.WriteLine("GS = {0}   L = {2}    r = {1}", gs, r, ar.Length);
            Console.WriteLine();
            if (r > 0 && ran == false)
            {
                ran = true;
                gs = gs / 2;
                int[] LHS = ar.Take(gs).ToArray();
                int[] RHS = ar.Skip(gs).ToArray();
                Console.WriteLine("----- To Finish -----");
                PrintArray(LHS);
                PrintArray(RHS);
                Console.WriteLine();
                ar = MergeTwoArrays(LHS, RHS);
                PrintArray(ar);
                Console.WriteLine("---------------------");
                return ar;
            }
            else
            {
                if (ran)
                {
                    return ar;
                }
                else
                {
                    int[] fake = { 0, 0 };
                    return fake;
                }

            }

        }


        private int[] MergeTwoArrays(int[] ar1, int[] ar2)
        {
            int[] newar = new int[ar1.Length + ar2.Length];
            int lp = 0;
            int rp = 0;
            int i = 0;
            bool sorting = true;
            while (sorting)
            {
                if (lp == ar1.Length && rp == ar2.Length)
                {
                    sorting = false;
                }
                else if (lp == ar1.Length)
                {
                    while (rp < ar2.Length)
                    {
                        newar[i] = ar2[rp];
                        rp++;
                        i++;
                    }

                }

                else if (rp == ar2.Length)
                {
                    while (lp < ar1.Length)
                    {
                        newar[i] = ar1[lp];
                        lp++;
                        i++;
                    }

                }

                else if (ar1[lp] <= ar2[rp])
                {
                    newar[i] = ar1[lp];
                    ar1[lp] = 0;
                    lp++;
                }
                else
                {
                    newar[i] = ar2[rp];
                    ar2[rp] = 0;
                    rp++;
                }
                i++;
            }
            return newar;
        }


        public (int,string) multi_run_linear_string(string term, string[] ar)
        {
            int entreies = 0;
            string word = "";
            for (int i = 0; i < ar.Length; i++)
            {
                for (int j = 0; j < ar[i].Length; j++)
                {
                    if (ar[i].Substring(0,j) == term)
                    {
                        entreies++;
                        word = ar[i];
                    }
                    
                }
            }
            return (entreies,word);
        }

        public int average(int[] array)
        {
            double rounder;
            int avg;
            int s = 0;
            foreach(int t in array)
            {
                s += t;
            }
            
            rounder = Math.Ceiling((double)s / array.Length);
            avg = Convert.ToInt32(rounder);
            
            return avg;
        }




        public string PrintArray(int[] array)
        {
            string str = "";
            if (array.Length > 0)
            {
                foreach (int i in array) { str += (i + ", "); }
                str += "\n";
            }
            else { str += "Null"; }
            //MessageBox.Show(str);
            return str;

        }

    }

}
