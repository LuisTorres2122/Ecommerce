using AutoMapper;
using ecommerce.Services.Interfaces;
using Ecommerce.DTO;
using Ecommerce.Model;
using Ecommerce.Repository.Implementation;
using Ecommerce.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Services.Implementation
{
    public class DashBoardService : IDashBoardService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly ISaleRepository _saleRepository;
        public DashBoardService
            (IRepository<User> userRepository, 
            IRepository<Product> productRepository,
            ISaleRepository saleRepository)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
            _saleRepository = saleRepository;   
        }
        private string Revenue()
        {
            var query = _saleRepository.get();
            return query.Sum(sale => sale.TotalSale).ToString();
        }

        private int TotalRevenue()
        {
            var query = _saleRepository.get();
            return query.Count();

        }

        private int TotalClients()
        {
            var query = _userRepository.get(u => u.RolUser.ToLower() =="cliente");
            return query.Count();
        }

        private int TotalProducts()
        {
            var query = _productRepository.get();
            return query.Count();
        }

        public async Task<DashBoardDTO> Resume()
        {
            try
            {
                DashBoardDTO dashboard = new DashBoardDTO()
                {
                    TotalClients = TotalClients(),
                    TotalRevenue = Revenue(),
                    TotalRegisteredProducts = TotalProducts(),
                    TotalSales = TotalRevenue()
                };
                return dashboard;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
