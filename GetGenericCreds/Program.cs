using CredentialManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGenericCreds
{
    class Program
    {
        static void Main(string[] args)
        {
            CredentialUtil.GetCredential("CC_Details");
        }
    }

    public static class CredentialUtil
    {
        public static UserPass GetCredential(string target)
        {
            var cm = new Credential { Target = target };
            if (!cm.Load())
            {
                return null;
            }

            Console.WriteLine(cm.Username);
            Console.WriteLine(cm.Password);
            // UserPass is just a class with two string properties for user and pass
            return new UserPass(cm.Username, cm.Password);
        }

        public static bool SetCredentials(
             string target, string username, string password, PersistanceType persistenceType)
        {
            return new Credential
            {
                Target = target,
                Username = username,
                Password = password,
                PersistanceType = persistenceType
            }.Save();
        }

        public static bool RemoveCredentials(string target)
        {
            return new Credential { Target = target }.Delete();
        }
    }

    public class UserPass
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserPass(string user, string pass)
        {
            UserName = user;
            Password = pass;
        }
    }
}
