using AutoMapper;
using ecommerce.Services.Interfaces;
using Ecommerce.DTO;
using Ecommerce.Model;
using Ecommerce.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Services.Implementation
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        public SaleService(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;   
        }
        public async Task<SaleDTO> Register(SaleDTO sale)
        {
            try
            {
                var newSale = _mapper.Map<Sale>(sale);
                var createdSale = _saleRepository.Register(newSale);

                if (createdSale.Id != 0)
                    return _mapper.Map<SaleDTO>(createdSale);
                else
                    throw new TaskCanceledException("No se pudo registrar");


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
