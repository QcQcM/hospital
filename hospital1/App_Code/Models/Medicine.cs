using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class Medicine
    {
        public String Number { set; get; }
        public String Name { set; get; }
        public String Manufacter { set; get; }
        public Decimal Price { set; get; }
        public Int32 Amount { set; get; }
        public String Type { set; get; }

        public static Medicine createMedicine(Dictionary<String, Object> dic)
        {
            Medicine medicine = new Medicine();
            medicine.Number = (String)dic["m_num"];
            medicine.Name = (String)dic["m_name"];
            medicine.Manufacter = (String)dic["manufactor"];
            medicine.Price = (Decimal)dic["price"];
            medicine.Amount = (Int32)dic["amount"];
            medicine.Type = (String)dic["type"];
            return medicine;
        }
    }