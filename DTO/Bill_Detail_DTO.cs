using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class Bill_Detail_DTO
    {
        private int idProduct;
        private int idBill;

        public int IdProduct
        {
            get { return idProduct; }
            set { idProduct = value; }
        }

        public int IdBill
        {
            get { return idBill; }
            set { idBill = value; }
        }

        public Bill_Detail_DTO(int idproduct, int idbill)
        {
            this.idProduct = idproduct;
            this.idBill = idbill;
        }
    }
}
