namespace FixItApp.ApplicationCore.Interfaces;

public interface IPasswordHashing
{
    public string GetHashString(string pwd);
}