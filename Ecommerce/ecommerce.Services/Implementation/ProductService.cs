﻿using AutoMapper;
using ecommerce.Services.Interfaces;
using Ecommerce.DTO;
using Ecommerce.Model;
using Ecommerce.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<List<ProductDTO>> Catalog(string category, string? browse)
        {
            try
            {
                IQueryable<Product> query;
                if (category == "All" && browse == null)
                {
                    query = _productRepository
                       .get(p => p.IdCategoryNavigation.NameCategory != null);
                }
                else if (category == "All" && browse != null) 
                {
                    query = _productRepository
                      .get(p => p.IdCategoryNavigation.NameCategory != null &&
                      p.NameProduct.ToLower().Contains(browse.ToLower()));
                }
                else
                {
                    if (browse != null)
                    {
                        query = _productRepository
                        .get(p => p.IdCategoryNavigation.NameCategory.ToLower().Contains(category.ToLower()) &&
                        p.NameProduct.ToLower().Contains(browse.ToLower()));
                    }
                    else
                    {
                        query = _productRepository
                        .get(p => p.IdCategoryNavigation.NameCategory.ToLower().Contains(category.ToLower()));
                    }
                }

               
                    
                var list = await query.ToListAsync();
                return _mapper.Map<List<ProductDTO>>(list);
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductDTO> Create(ProductDTO product)
        {
             try
              {
                 var newProduct = _mapper.Map<Product>(product);
                 var savedProduct = await _productRepository.Create(newProduct);
                 if (savedProduct.IdCategory != 0)
                      return _mapper.Map<ProductDTO>(savedProduct);
                  else
                      throw new TaskCanceledException("No se pudo crear");

             }
             catch (Exception ex)
             {
                throw ex;
             }
               
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var query = _productRepository.get(p => p.IdProduct == id);
                var existingProduct = await query.FirstOrDefaultAsync();
                if (existingProduct != null)
                {
                    var deleteProduct = await _productRepository.Delete(existingProduct);

                    if (!deleteProduct)
                        throw new TaskCanceledException("No se pudo Eliminar");
                    return deleteProduct;
                }
                else
                {
                    throw new TaskCanceledException("No se encontro");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductDTO> GetProduct(int id)
        {
            try
            {
                var query = _productRepository.get(p => p.IdProduct == id);
                var existingUser = await query.FirstOrDefaultAsync();
                if (existingUser != null)
                    return _mapper.Map<ProductDTO>(existingUser);
                else
                    throw new TaskCanceledException("No se encontro");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductDTO>> ProductList(string? browse)
        {
            try
            {
                IQueryable<Product> query;
                if (browse != null)
                {
                    query = _productRepository.get(cat =>
                            cat.NameProduct.ToLower().Contains(browse));
                }
                else
                {
                    Console.WriteLine("Si llego");
                    query = _productRepository.get(cat =>
                            cat.NameProduct != "");
                }

                var existingProduct = await query.ToListAsync();
                if (existingProduct != null)
                    return _mapper.Map<List<ProductDTO>>(existingProduct);
                else
                    throw new TaskCanceledException("No se encontro");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(ProductDTO user)
        {
            try
            {
                var query = _productRepository.get(p => p.IdProduct == user.Id);
                var existingProduct = await query.FirstOrDefaultAsync();
                if (existingProduct != null)
                {
                    existingProduct.NameProduct = user.Name;
                    existingProduct.DescriptionProduct = user.Description;
                    existingProduct.PriceProduct = user.Price;
                    existingProduct.OfferPriceProduct = user.OfferPrice;
                    existingProduct.QuantityProduct = user.Quantity;
                    existingProduct.ImageProduct = user.Image;
                    var response = await _productRepository.Update(existingProduct);
                    if (!response)
                        throw new TaskCanceledException("No se pudo Editar");
                    return response;
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron Resultado");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    } 
}
