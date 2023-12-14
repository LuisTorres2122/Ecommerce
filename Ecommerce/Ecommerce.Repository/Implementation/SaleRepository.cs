using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Model;
using Ecommerce.Repository.DBConext;
using Ecommerce.Repository.Interfaces;

namespace Ecommerce.Repository.Implementation
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        private readonly EcommerceContext _context;
        public SaleRepository(EcommerceContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Sale> Register(Sale sale)
        {
            Sale generatedSale = new Sale();

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (DetailsSale ds in sale.DetailsSales) 
                    { 
                        Product productfound = _context.Products.Where(p => p.IdProduct == ds.IdProduct).First();
                        productfound.QuantityProduct -= ds.QuantityProduct;
                        _context.Products.Update(productfound);
                    }
                    await _context.SaveChangesAsync();
                    await _context.Sales.AddAsync(sale);
                    await _context.SaveChangesAsync();

                    generatedSale = sale;
                    transaction.Commit();
                    return generatedSale;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}
