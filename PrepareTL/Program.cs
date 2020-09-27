using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace PrepareTL
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            string WorkFolder = "abdata";
            Console.WriteLine("Making Master Files...");

            MakeMasters(WorkFolder);

            Console.Clear();

            //Console.WriteLine("Please write the characternumber you'd like to run.");
            //string chara = Console.ReadLine();

            MakeNewDirs("c30", WorkFolder);
        }

        public static void MakeMasters(string WorkFolder)
        {
            List<string> charactertypes = new List<string>();
            charactertypes.Add("c-1");
            charactertypes.Add("c-2");
            charactertypes.Add("c-4");
            charactertypes.Add("c-5");
            charactertypes.Add("c-8");
            charactertypes.Add("c-9");
            charactertypes.Add("c-10");
            charactertypes.Add("c00");
            charactertypes.Add("c01");
            charactertypes.Add("c02");
            charactertypes.Add("c03");
            charactertypes.Add("c04");
            charactertypes.Add("c05");
            charactertypes.Add("c06");
            charactertypes.Add("c07");
            charactertypes.Add("c08");
            charactertypes.Add("c09");
            charactertypes.Add("c10");
            charactertypes.Add("c11");
            charactertypes.Add("c12");
            charactertypes.Add("c13");
            charactertypes.Add("c14");
            charactertypes.Add("c15");
            charactertypes.Add("c16");
            charactertypes.Add("c17");
            charactertypes.Add("c18");
            charactertypes.Add("c19");
            charactertypes.Add("c20");
            charactertypes.Add("c21");
            charactertypes.Add("c22");
            charactertypes.Add("c23");
            charactertypes.Add("c24");
            charactertypes.Add("c25");
            charactertypes.Add("c26");
            charactertypes.Add("c27");
            charactertypes.Add("c28");
            charactertypes.Add("c29");
            charactertypes.Add("c30");
            charactertypes.Add("c31");
            charactertypes.Add("c32");
            charactertypes.Add("c33");
            charactertypes.Add("c34");
            charactertypes.Add("c35");
            charactertypes.Add("c36");
            charactertypes.Add("c37");
            charactertypes.Add("c38");
            charactertypes.Add("c39");

            foreach (string item in charactertypes)
            {
                if (!File.Exists("Master\\" + item + ".txt"))
                {
                    int LineNum = 0;
                    int DocNum = 0;
                    if (!Directory.Exists("Master"))
                        Directory.CreateDirectory("Master");

                    foreach (string HTransFile in Directory.EnumerateFiles(WorkFolder, "*.txt", SearchOption.AllDirectories))
                    {
                        string[] HTranslationFiles = File.ReadAllLines(HTransFile); // Filename obtained

                        StreamWriter file = new StreamWriter($"Master\\{item}.txt", true);
                        if (HTransFile.Contains(item))
                        {
                            DocNum++;
                            foreach (string line in HTranslationFiles)
                            {
                                LineNum++;
                                string[] TLLine = line.Split('=');
                                string TLLineSplit = TLLine[0].Replace(@"/", "");
                                file.Write(DocNum + "-" + LineNum + "=" + TLLine[0].Replace(@"/", "") + "\n");
                                Console.WriteLine(TLLine[0].Replace(@"/", "") + "\n");
                            }
                        }

                        file.Close();
                    }
                }
            }
        }

        public static void MakeNewDirs(string characterarchetype, string WorkFolder)
        {
            string WriteLine = "humbug";
            foreach (string HTransFile in Directory.EnumerateFiles(WorkFolder, "*.txt", SearchOption.AllDirectories))
            {
                string[] HTranslationFiles = File.ReadAllLines(HTransFile); // Filename obtained
                string outputdir = HTransFile.Remove(HTransFile.Length - 15, 15).Replace("abdata", "abdata (" + characterarchetype + ")");
                string outputfile = HTransFile.Replace("abdata", "abdata (" + characterarchetype + ")");
                string mastersource = $"Master\\{characterarchetype}.txt";
                string[] masterlines = File.ReadAllLines(mastersource);

                if (!Directory.Exists(outputdir))
                    Directory.CreateDirectory(outputdir);

                StreamWriter file = new StreamWriter(outputfile, true);

                foreach(string line in HTranslationFiles)
                {
                    string[] lineSplit = line.Split('=');
                    foreach(string MasterLine in masterlines)
                    {
                        string[] mineSplit = MasterLine.Split('=');
                        //Console.WriteLine(mineSplit[1]);
                        //Console.WriteLine(lineSplit[0]);
                        if (mineSplit[1].Replace(@"/", "") == lineSplit[0].Replace(@"/", ""))
                        {
                            WriteLine = mineSplit[0] + "=" + line;
                            file.WriteLine(WriteLine);
                        }
                        Console.WriteLine("ping");
                    }
                    //Console.WriteLine(WriteLine);
                }

                file.Close();
            }
        }
    }
}
