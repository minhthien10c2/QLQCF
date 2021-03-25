using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO_Ha;
using DAL_Ha;

namespace BUS_Ha
{
    public class Table_BUS
    {
        Table_DAL table_DAL = new Table_DAL();
        public DataTable GetAllTable()
        {
            return table_DAL.GetAllTable();
        }

        public DataTable GetTableByID(String id)
        {
            return table_DAL.GetTableByID(id);
        }

        public bool AddNewTable(Table_DTO table)
        {
            return table_DAL.AddNewTable(table);
        }

        public bool UpdateTable(Table_DTO table)
        {
            return table_DAL.UpdateTable(table);
        }

        public bool DeleteTable(String id)
        {
            return table_DAL.DeleteTable(id);
        }
    }
}
