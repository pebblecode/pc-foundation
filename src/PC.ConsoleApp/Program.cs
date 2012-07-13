using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PC.Framework.Utilities;

namespace PC.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SaltedHash sh = new SaltedHash(new System.Security.Cryptography.SHA256Managed(), 1);
            byte[] binData = new byte[] { 1, 2, 3, 4, 5 };
            byte[] binHash, binSalt;
            sh.GetHashAndSalt(binData, out binHash, out binSalt);
            Console.WriteLine();
        }
    }
}
