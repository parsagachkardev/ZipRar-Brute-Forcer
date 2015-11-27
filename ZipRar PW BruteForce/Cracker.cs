using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace ZipRar_PW_BruteForce
{
    class Cracker
    {
        public async Task bruteForce(List<char> charset, List<String> pwlist, int digitCount, string prev = "")
        {
            if (digitCount > 0)
                charset.ForEach(q => {
                    bruteForce(charset, pwlist, digitCount - 1, prev + q.ToString());
                    pwlist.Add(prev + q.ToString());
                });
        }
        public  void Crack(string sevenZipPath,string zipFilePath,List<string> pwlist) {
            //var a = sevenZipPath + "\\7z.exe y x \"" + zipFilePath + "\" p" + "1";
            //var a = sevenZipPath + @"\7z.exe","y x \"" + zipFilePath + "\" p" + "1";
            //Process.Start(a);
            pwlist.ForEach(q =>
            {
                new Task(() =>
                {
                    Console.WriteLine("\nTesting password : \t"+q);
                    
                    var a =Process.Start(sevenZipPath + @"\7z.exe", " e \"" + zipFilePath + "\" -y -p" + q);
                    
                }).Start();
            });
        }
    }
}
