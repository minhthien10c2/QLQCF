using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO_Ha;

namespace DAL_Ha
{
    public class Bill_DAL
    {
        public DataTable GetAllBill()
        {
            String query = "SELECT * FROM bill";
            return DBConfig.ExecuteGetData(query);
        }

        public DataTable GetBillByID(String id)
        {
            int parameterCount = 1;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = id;

            String query = "SELECT * FROM bill WHERE id = @id";
            return DBConfig.ExecuteGetData(query, parameterName, parameterValue, parameterCount);
        }

        public bool AddNewBill(Bill_DTO bill)
        {
            int parameterCount = 5;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = bill.Id;
            parameterName[1] = "@check_in"; parameterValue[1] = bill.CheckIn;
            parameterName[2] = "@check_out"; parameterValue[2] = bill.CheckOut;
            parameterName[3] = "@total_price"; parameterValue[3] = bill.TotalPrice;
            parameterName[4] = "@id_table"; parameterValue[4] = bill.IdTable;

            String query = "INSERT INTO bill(id, check_in, check_out, total_price, id_table) VALUES (@id, @check_in, @check_out, @total_price, @id_table)";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }

        public bool UpdateBill(Bill_DTO bill)
        {

            int parameterCount = 5;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = bill.Id;
            parameterName[1] = "@check_in"; parameterValue[1] = bill.CheckIn;
            parameterName[2] = "@check_out"; parameterValue[2] = bill.CheckOut;
            parameterName[3] = "@total_price"; parameterValue[3] = bill.TotalPrice;
            parameterName[4] = "@id_table"; parameterValue[4] = bill.IdTable;

            String query = "UPDATE bill SET check_in = @check_in, check_out = @check_out, total_price = @total_price, id_table = @id_table WHERE id = @id";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }

        public bool DeleteBill(String id)
        {
            int parameterCount = 1;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = id;

            String query = "DELETE bill WHERE id = @id";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }
    }
}
