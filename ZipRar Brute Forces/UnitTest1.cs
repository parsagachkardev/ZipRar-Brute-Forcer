using System;
using System.Collections;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ZipRar_Brute_Forces
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod2()
        {
            var sevenZipPath = @"C:\Program Files\7-Zip";
            var zipFilePath= @"C:\Users\Parsa Gachkar\Desktop\sadasd.7z";
            var extractionPath = @"C:\Users\Parsa Gachkar\Desktop\";
            var pwlist = new List<String>();
            var charset = "0123456789".ToList();
            bruteForce(charset, pwlist, 4);
            Console.WriteLine(String.Format("{0} Passwords Generated!",pwlist.Count));
            pwlist.ForEach(q => {
                new Task(()=> {
                   Process.Start(sevenZipPath + @"\7z.exe","e \""+zipFilePath  );
                   Console.WriteLine("ok");
                }).Start();
            });
            
            Assert.IsTrue(true);

        }
        [TestMethod]
        public void TestMethod1()
        {
            var pwlist = new List<String>();
            var charset = "0123456789".ToList();
            bruteForce(charset,pwlist, 1);
            Assert.IsTrue(true);
        }
        private void bruteForce(List<char> charset, List<String> pwlist, int digitCount,string prev="")
        {
            if (digitCount > 0)
            charset.ForEach(q=> {
                bruteForce(charset, pwlist, digitCount - 1, prev + q.ToString());
                pwlist.Add(prev + q.ToString());
            });
        }
    }
}
