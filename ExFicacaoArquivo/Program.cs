using System;
using System.Globalization;
using System.IO;

namespace ExFicacaoArquivo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\yasmi\Documents\FATEC\arquivoTeste.csv";
            try
            {
                string[] lines = File.ReadAllLines(path);
                string targetFolderPath = (@"C:\Users\yasmi\Documents\FATEC\" + @"\out");
                string targetFilePath = targetFolderPath + @"\summary.csv";

                Directory.CreateDirectory(targetFolderPath);

                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(',');
                        string name = fields[0];
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(fields[2]);


                        sw.WriteLine(name + "," + price*quantity);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro.");
                Console.WriteLine(e.Message);
            }
        }
    }
}