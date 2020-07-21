using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabTest3_CM_068
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating file......");
            string fileName = @"task1.txt";
            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                Console.WriteLine("Creating random numbers list....");
                using (FileStream fs = File.Create(fileName))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        string line = "";
                        for (int j = 0; j < 5; j++)
                            line += generateRandomNumber() + "\t";
                        Byte[] title = new UTF8Encoding(true).GetBytes(line);
                        fs.Write(title, 0, title.Length);
                        byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                        fs.Write(newline, 0, newline.Length);
                    }
                }
            }
            catch (IOException Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            catch (NullReferenceException Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }

            Console.WriteLine("Random Number saved successfully in file");
            Console.ReadKey();
        }
        static Random rnd = new Random();
        static int generateRandomNumber()
        {
            return rnd.Next(0, 1001);
        }
    }
}
