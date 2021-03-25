using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Ha
{
    public class Table_DTO
    {
        private String id;
        private String tableName;

        public String Id
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

        public Table_DTO(String id, String tablename)
        {
            this.id = id;
            this.tableName = tablename;
        }
    }
}
