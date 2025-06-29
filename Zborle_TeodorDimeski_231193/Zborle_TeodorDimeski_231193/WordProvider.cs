using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zborle_TeodorDimeski_231193
{
    public class WordProvider
    {
       
        public static List<string> Words { get; set; }
        public static  Random Random { get; set; }
        
        public  WordProvider()
        {
           
           LoadWords();
           Random = new Random();
           
        }


        private static void LoadWords()
        {
            Words = new List<string>();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "zborovi.txt");
            if (File.Exists(path))
            {
                try
                {
                   
                    string[] lines = File.ReadAllLines(path);
                    foreach (string line in lines)
                    {
                        String s =line.Trim().ToLower();
                        if (s.Length == 5 && s!="" && s !=null)
                        {
                            Words.Add(s);
                        }
                    }
                }
                catch
                {
                    Words = new List<string>();
                    MessageBox.Show("Грешка при читање на зборовите од фајл.");
                }
            }
            else
            {
                throw new FileNotFoundException("Фајлот со зборови не е најден");
            }
        }

        public string GetRandwomWord()
        {
           if(Words==null || Words.Count == 0)
            {
                return "false";
            }
            return Words[Random.Next(Words.Count)];

        }



        public bool IsValidWord(string word)
        {
            return Words.Contains(word);
        }
    }
}
