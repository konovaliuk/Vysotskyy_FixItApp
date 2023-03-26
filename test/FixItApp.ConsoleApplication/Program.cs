using System.Security.Cryptography;
using System.Text;

namespace FixItAppConsoleTest 
{
    internal class Program
    { 
        private static string GetHashString(string s)  
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            
            var CSP = new MD5CryptoServiceProvider();  
            
            byte[] byteHash = CSP.ComputeHash(bytes);  
  
            string hash = string.Empty;  
            
            foreach (byte b in byteHash)  
                hash += string.Format("{0:x2}", b);  
  
            return hash;  
        }  
        
        static void Main(string[] args)
        {
            string password = "MyPassword123";
            
            Console.WriteLine($"Password: {password}");
            
            Console.WriteLine("Hashed password: {0}", GetHashString(password));
            
            Console.WriteLine("Hashed password check: {0}", GetHashString(password));
            
            Console.WriteLine("Hashed password 1111: {0}", GetHashString("111"));

            Console.ReadLine();
        }
    }
}