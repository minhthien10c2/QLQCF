using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO_Ha;

namespace DAL_Ha
{
    public class Table_DAL
    {
        public DataTable GetAllTable()
        {
            String query = "SELECT * FROM table_cf";
            return DBConfig.ExecuteGetData(query);
        }

        public DataTable GetTableByID(String id)
        {
            int parameterCount = 1;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = id;

            String query = "SELECT * FROM table_cf WHERE id = @id";
            return DBConfig.ExecuteGetData(query, parameterName, parameterValue, parameterCount);
        }

        public bool AddNewTable(Table_DTO table)
        {
            int parameterCount = 2;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = table.Id;
            parameterName[1] = "@name"; parameterValue[1] = table.TableName;

            String query = "INSERT INTO table_cf(id, name) VALUES(@id, @name)";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }

        public bool UpdateTable(Table_DTO table)
        {

            int parameterCount = 2;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = table.Id;
            parameterName[1] = "@name"; parameterValue[1] = table.TableName;

            String query = "UPDATE table_cf SET name = @name WHERE id = @id";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }

        public bool DeleteTable(String id)
        {
            int parameterCount = 1;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = id;

            String query = "DELETE table_cf WHERE id = @id";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }
    }
}
