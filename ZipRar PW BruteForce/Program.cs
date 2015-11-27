using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
namespace ZipRar_PW_BruteForce
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Zip Rar BruteForcer v 0.1 by P4r54");
            bool done = false;
            Cracking("Initializing Cracker...",stop:done);
            Cracker Cracker = new Cracker();
            done = true;
            Console.Write("PLZ install 7-zip and Type in the Path :\t");
            var sevenZipPath= Console.ReadLine();
            if (!File.Exists(sevenZipPath + @"\7z.exe")) {
                Console.WriteLine("Error Wrong Path");
                Console.ReadKey();
                return;
            }
            Console.Write("Zip File path to be Cracked :\t");
            var ZipPath = Console.ReadLine();
            if (!File.Exists(ZipPath))
            {
                Console.WriteLine("Error Wrong Path");
                Console.ReadKey();
                return;
            }
            Console.Write("Max Password length :\t");
            var pwLength =int.Parse(Console.ReadLine());
            Console.Write("Password Charset (enter empty to use Default a-z A-Z 0-9 and . as charset):\t");
            List<char> charset = Console.ReadLine().ToList<char>();
            charset.RemoveAll(new Predicate<char>(q=>q=='\n'));
            if (charset.Count == 0)
                charset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ 1234567890.".ToList<char>();
            done = false;
            List<string> pwlist = new List<string>();
            Cracking("Generating Password Dictionary...",stop:done);
            Cracker.bruteForce(charset,pwlist,pwLength);
            done = true;
            done = false;
            Cracking("Cracking...!",stop:done);
            
            Cracker.Crack(sevenZipPath, ZipPath, pwlist);
            done = true;
            Console.ReadKey();
            
            
            
            
        }
        async static Task Cracking(string text,string DoneText="[OK]",bool stop=false) {
            
            //while (!stop)
            //{
            //    const int delay = 32;
            //    Console.Write("\t|\t"+text+"\r");
            //    Thread.Sleep(delay);
            //    Console.Write("\t/\r");
            //    Thread.Sleep(delay);
            //    Console.Write("\t-\r");
            //    Thread.Sleep(delay);
            //    Console.Write("\t\\\r");
            //    Thread.Sleep(delay);
            //}
            Console.Write("\t>\t" + text +"\t"+ DoneText + "\r");

        }
    }
}
