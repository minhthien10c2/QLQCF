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
            String query = "SELECT bill.*, table_cf.name FROM bill, table_cf where bill.id_table = table_cf.id";
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
            int parameterCount = 4;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = bill.Id;
            parameterName[1] = "@check_in"; parameterValue[1] = bill.CheckIn;
            parameterName[2] = "@total_price"; parameterValue[2] = bill.TotalPrice;
            parameterName[3] = "@id_table"; parameterValue[3] = bill.IdTable;

            String query = "INSERT INTO bill(id, check_in, total_price, id_table) VALUES (@id, @check_in, @total_price, @id_table)";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }

        public bool UpdateBill(Bill_DTO bill)
        {

            int parameterCount = 4;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = bill.Id;
            parameterName[1] = "@check_in"; parameterValue[1] = bill.CheckIn;
            parameterName[2] = "@total_price"; parameterValue[2] = bill.TotalPrice;
            parameterName[3] = "@id_table"; parameterValue[3] = bill.IdTable;

            String query = "UPDATE bill SET total_price = @total_price, id_table = @id_table WHERE id = @id";
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
