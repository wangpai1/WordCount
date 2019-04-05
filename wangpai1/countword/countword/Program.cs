using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp1
{
    class Words
    {
        public int num;
        public int countword(string s)
        {
            string[] st = s.Split(' ');
            Word word = new Word();
            Dictionary<string, int> open = new Dictionary<string, int>();
            List<string> list = new List<string>();
            for (int i = 0; i < st.Length; i++)
            {
                if (word.Yes(st[i]))
                {
                    list.Add(st[i]);
                }
            }
            foreach (string h in list)
            {
                int key = 1;
                if (open.ContainsKey(h))
                {
                    foreach (KeyValuePair<string, int> kvp in open)
                    {
                        if (kvp.Key.Equals(h))
                        {
                            key = kvp.Value + 1;
                            open.Add(h, key);
                            num++;
                        }
                    }
                }
                else
                {
                    open.Add(h, key);
                    num++;
                }
            }
            return num;
        }
        public void Sort(Dictionary<string, int> open)
        {
            var dicSort = from objDic in open orderby objDic.Value descending select objDic;
            Words words = new Words();
            if (open.Count < 10)
            {
                foreach (KeyValuePair<string, int> kvp in dicSort)
                {
                    Console.WriteLine(kvp.Key + ":" + kvp.Value);
                    Console.ReadKey();
                }
            }
            else
            {
                foreach (KeyValuePair<string, int> kvp in dicSort)
                {
                    int y = 0;
                    do
                    {
                        Console.WriteLine(kvp.Value + ":" + kvp.Key);
                        Console.ReadKey();
                        y++;
                    } while (y > 10);

                }
            }
        }
    }
    class Word
    {
        public int charnum;
        public bool Yes(string s)
        {
            bool flag = true;
            char[] a = s.ToArray();
            while (a.Length > 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (a[i] >= 0 && a[i] <= 9)
                    {
                        flag = false;
                    }
                    else
                    {
                        if (a[a.Length - 1] > 'a' && a[a.Length - 1] < 'z')
                        {
                            flag = true;
                        }
                    }
                }
            }
            return flag;
        }
        public string solve(string s)
        {
            char[] a = s.ToArray();
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > 'A' && a[i] < 'Z')
                {
                    a[i] = (char)(a[i] + 32);
                    charnum = charnum + 1;
                }
                else if (a[i] >= 0 && a[i] <= 9)
                {
                    charnum = charnum + 1;
                }
                else
                {
                    a[i] = ' ';
                }
            }
            return s;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string f = @"D:\wangpai.txt";
            FileStream file = new FileStream(f, FileMode.Open);
            StreamReader reader = new StreamReader(file);
            string s = reader.ReadToEnd();
            Word word = new Word();
            word.solve(s);
            Words words = new Words();
            int num = words.countword(s);
            Console.WriteLine("charactors:" + word.charnum);
            string sr = reader.ReadLine();
            reader.Close();
            int c = 0;
            while (s != null)
            {
                c++;
            }
            Console.WriteLine("Lines:" + c);
            Console.WriteLine("words:" + num);
            string[] st = s.Split(' ');
            Dictionary<string, int> open = new Dictionary<string, int>();
            List<string> list = new List<string>();
            for (int i = 0; i < st.Length; i++)
            {
                bool flag = word.Yes(st[i]);
                if (flag == true)
                {
                    list.Add(st[i]);
                }
            }
            foreach (string h in list)
            {
                int key = 1;
                if (open.ContainsKey(h))
                {
                    foreach (KeyValuePair<string, int> kvp in open)
                    {
                        if (kvp.Key.Equals(h))
                        {
                            key = kvp.Value + 1;
                            open.Add(h, key);
                        }
                    }
                }
                else
                {
                    open.Add(h, key);
                }
            }
            words.Sort(open);
        }
    }
}


