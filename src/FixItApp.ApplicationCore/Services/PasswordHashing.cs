using System.Security.Cryptography;
using System.Text;
using FixItApp.ApplicationCore.Interfaces;

namespace FixItApp.ApplicationCore.Services;

public class PasswordHashing : IPasswordHashing
{
    public string GetHashString(string s)  
    {
        byte[] bytes = Encoding.Unicode.GetBytes(s);
            
        var CSP = new MD5CryptoServiceProvider();  
            
        byte[] byteHash = CSP.ComputeHash(bytes);  
  
        string hash = string.Empty;  
            
        foreach (byte b in byteHash)  
            hash += string.Format("{0:x2}", b);  
  
        return hash;  
    }  
}