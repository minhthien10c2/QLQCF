using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Ha
{
    public class Account_DTO
    {
        private String UserName;
        private String Password;
        private int Auth;

        public String UserName1
        {
            get { return UserName; }
            set { UserName = value; }
        }

        public String Password1
        {
            get { return Password; }
            set { Password = value; }
        }

        public int Auth1
        {
            get { return Auth; }
            set { Auth = value; }
        }

        public Account_DTO()
        {

        }

        public Account_DTO(String username, String password, int auth)
        {
            this.UserName = username;
            this.Password = password;
            this.Auth = auth;
        }
    }
}
