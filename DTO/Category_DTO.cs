using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class Category_DTO
    {
        private int id;
        private String categoryName;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }

        public Category_DTO()
        { }

        public Category_DTO(int id, String categoryname)
        {
            this.id = id;
            this.categoryName = categoryname;
        }
    }
}
