using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "{0} can't be empty")]
        [StringLength(50, ErrorMessage = "{0} Must be between {2} and {1} characters", MinimumLength = 3)]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "{0} must be filled")]
        public DateTime BirthDate { get; set; }
        [DisplayName("Base Salary")]
        [DataType(DataType.Currency)]
        [Range(100, 3000, ErrorMessage = "{0} Must be between {1} and {2}")]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();


        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initialDate, DateTime finalDate)
        {
            return Sales.Where(sale => sale.Date >= initialDate && sale.Date <= finalDate).Sum(sale => sale.Amount);
        }
    }
}
