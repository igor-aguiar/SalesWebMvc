using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Department
    {
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Department()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public void addSeller(Seller seller)
        {
            Sellers.Add(seller);
        }
        
        public double TotalSales(DateTime initalDate, DateTime finalDate)
        {
            return Sellers.Sum(seller => seller.TotalSales(initalDate, finalDate));
        }
    }
}
