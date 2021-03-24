using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class Bill_DTO
    {
        private int id;
        private double totalPrice;
        private DateTime checkIn;
        private DateTime checkOut;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime CheckIn
        {
            get { return checkIn; }
            set { checkIn = value; }
        }

        public DateTime CheckOut
        {
            get { return checkOut; }
            set { checkOut = value; }
        }

        public double TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        public Bill_DTO()
        {

        }

        public Bill_DTO(int id, DateTime checkin, DateTime checkout, double totalprice)
        {
            this.id = id;
            this.checkIn = checkin;
            this.checkOut = checkout;
            this.totalPrice = totalprice;
        }
    }
}
