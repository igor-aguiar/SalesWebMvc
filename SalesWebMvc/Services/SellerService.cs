using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Sellers.Include(seller => seller.Department).ToList();
        }

        public void Insert(Seller seller)
        {
            _context.Sellers.Add(seller);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Sellers.Include(seller => seller.Department).FirstOrDefault(seller => seller.Id == id);
        }

        public void Delete(int id)
        {
            var seller = _context.Sellers.Find(id);
            _context.Sellers.Remove(seller);
            _context.SalesRecords.RemoveRange(_context.SalesRecords.Where(sales => sales.Seller.Id == seller.Id));
            _context.SaveChanges();
        }

        public void Update(Seller seller)
        {
            if (!_context.Sellers.Any(x => x.Id == seller.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
