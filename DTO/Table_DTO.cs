using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class Table_DTO
    {
        private int id;
        private String tableName;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        public Table_DTO()
        {

        }

        public Table_DTO(int id, String tablename)
        {
            this.id = id;
            this.tableName = tablename;
        }
    }
}
