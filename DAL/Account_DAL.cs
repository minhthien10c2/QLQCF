using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO_Ha;

namespace DAL_Ha
{
    public class Account_DAL
    {
        public DataTable CheckAccount(Account_DTO account)
        {
            int parameterCount = 2;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@user_name"; parameterValue[0] = account.UserName1;
            parameterName[1] = "@password"; parameterValue[1] = account.Password1;

            String query = "SELECT * FROM account WHERE user_name = @user_name and password = @password";
            return DBConfig.ExecuteGetData(query, parameterName, parameterValue, parameterCount);
        }

        public bool AddNewAccount(Account_DTO account)
        {
            int parameterCount = 6;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@user_name"; parameterValue[0] = account.UserName1;
            parameterName[1] = "@password"; parameterValue[1] = account.Password1;
            parameterName[2] = "@name"; parameterValue[2] = account.Name1;
            parameterName[3] = "@gender"; parameterValue[3] = account.Gender1;
            parameterName[4] = "@phone"; parameterValue[4] = account.Phone1;
            parameterName[5] = "@address"; parameterValue[5] = account.Address1;

            String query = "INSERT INTO account(user_name, password, name, gender, phone, address) VALUES(@user_name, @password, @name, @gender, @phone, @address)";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }

        public bool UpdateAccount(Account_DTO account)
        {

            int parameterCount = 6;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@user_name"; parameterValue[0] = account.UserName1;
            parameterName[1] = "@password"; parameterValue[1] = account.Password1;
            parameterName[2] = "@name"; parameterValue[2] = account.Name1;
            parameterName[3] = "@gender"; parameterValue[3] = account.Gender1;
            parameterName[4] = "@phone"; parameterValue[4] = account.Phone1;
            parameterName[5] = "@address"; parameterValue[5] = account.Address1;

            String query = "UPDATE account SET password = @password, name = @name, gender = @gender, phone = @phone, address = @address WHERE user_name = @user_name";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }

        public bool DeleteAccount(String id)
        {
            int parameterCount = 1;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = id;

            String query = "DELETE account WHERE id = @id";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }
    }
}
