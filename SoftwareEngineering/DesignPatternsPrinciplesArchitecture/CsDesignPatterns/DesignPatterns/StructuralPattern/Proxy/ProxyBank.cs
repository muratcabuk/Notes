using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Proxy
{
    public class ProxyBank : IBank
    {
        Bank bank;
        bool isLogin;

        string _username, _password;


        public ProxyBank(string username, string password)
        {
            _username = username;
            _password = password;


        }


        bool Login()
        {


            if (_username == "murat" && _password == "1234")
            {

                bank = new Bank();
                isLogin = true;
                Console.WriteLine("Giriş Yapıldı");

                return true;


            }
            else
                Console.WriteLine("Lütfen kullanıcı adı ve şifrenizi doğru giriniz.");
            isLogin = false;
            return false;

        }



        public bool MakeDeposite(double amount)
        {

            Login();

            if(!isLogin)
            {
                Console.WriteLine("sisteme giriş yapmadınız");

            }

            bank.MakeDeposite(amount);

            return true;


        }
    }
}
