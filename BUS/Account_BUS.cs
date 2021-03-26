using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data;
using DTO_Ha;
using DAL_Ha;

namespace BUS_Ha
{
    public class Account_BUS
    {
        Account_DAL account_dal = new Account_DAL();

        public DataTable CheckAccount(Account_DTO account)
        {
            Account_BUS account_bus = new Account_BUS();
            MD5 md5Hash = MD5.Create();
            account.Password1 = account_bus.GetMd5Hash(md5Hash, account.Password1);

            return account_dal.CheckAccount(account);
        }

        public bool AddNewAccount(Account_DTO account)
        {
            Account_BUS account_bus = new Account_BUS();
            MD5 md5Hash = MD5.Create();
            account.Password1 = account_bus.GetMd5Hash(md5Hash, account.Password1);

            return account_dal.AddNewAccount(account);
        }

        public bool UpdateAccount(Account_DTO account)
        {
            return account_dal.UpdateAccount(account);
        }

        public bool DeleteAccount(String id)
        {
            return account_dal.DeleteAccount(id);
        }

        public string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
