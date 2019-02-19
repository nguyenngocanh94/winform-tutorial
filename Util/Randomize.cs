using System;
using System.Linq;

namespace WindowsFormsApp1.Util
{
    public class Randomize
    {
        private static Random random = new Random();
        
        public static string get()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 5)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}