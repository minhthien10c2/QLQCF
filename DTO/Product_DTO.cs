using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Product_DTO
    {
        private int id;
        private String productName;
        private float productPrice;
        private int idCategory;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public String ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        
        public float ProductPrice
        {
            get { return productPrice; }
            set { productPrice = value; }
        }       

        public int IdCategory
        {
            get { return idCategory; }
            set { idCategory = value; }
        }

        public Product_DTO()
        {

        }

        public Product_DTO(int id, String productname, float productprice, int idCategory)
        {
            this.id = id;
            this.productName = productname;
            this.productPrice = productprice;
            this.idCategory = idCategory;
        }
    }
}
