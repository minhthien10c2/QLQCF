using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Ha
{
    public class Bill_DTO
    {
        private String id;
        private double totalPrice;
        private DateTime checkIn;
        private String idTable;

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime CheckIn
        {
            get { return checkIn; }
            set { checkIn = value; }
        }

        public double TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        public String IdTable
        {
            get { return idTable; }
            set { idTable = value; }
        }

        public Bill_DTO()
        {

        }

        public Bill_DTO(String id, DateTime checkin, double totalprice, String idtable)
        {
            this.id = id;
            this.checkIn = checkin;
            this.totalPrice = totalprice;
            this.idTable = idtable;
        }
    }
}
