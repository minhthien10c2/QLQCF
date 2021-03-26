﻿using System;
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
        private String Name;
        private int Gender;
        private int Phone;
        private String Address;

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

        public String Name1
        {
            get { return Name; }
            set { Name = value; }
        }

        public int Gender1
        {
            get { return Gender; }
            set { Gender = value; }
        }

        public int Phone1
        {
            get { return Phone; }
            set { Phone = value; }
        }

        public String Address1
        {
            get { return Address; }
            set { Address = value; }
        }

        public Account_DTO()
        {
        }

        public Account_DTO(String username, String password, int auth, String name, int gender, int phone, String address)
        {
            this.UserName = username;
            this.Password = password;
            this.Auth = auth;
            this.Name = name;
            this.Gender = gender;
            this.Phone = phone;
            this.Address = address;
        }
    }
}
