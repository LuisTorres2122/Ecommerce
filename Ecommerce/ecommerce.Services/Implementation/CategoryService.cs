using AutoMapper;
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
    public class CategoryService : ICategorySevice
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategotyDTO>> CategoryList(string? browse)
        {
            try
            {
                IQueryable<Category> query;
                if(browse != null)
                {
                    query = _categoryRepository.get(cat =>
                            cat.NameCategory.ToLower().Contains(browse));
                }
                else
                {
                    Console.WriteLine("Si llego");
                    query = _categoryRepository.get(cat =>
                            cat.NameCategory != "");
                }
               
                var existingCategory = await query.ToListAsync();
                if (existingCategory != null)
                    return _mapper.Map<List<CategotyDTO>>(existingCategory);
                else
                    throw new TaskCanceledException("No se encontro");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategotyDTO> Create(CategotyDTO category)
        {
            try
            {
                var newCategory = _mapper.Map<Category>(category);
                var savedCategory = await _categoryRepository.Create(newCategory);
                if (savedCategory.IdCategory != 0)
                    return _mapper.Map<CategotyDTO>(savedCategory);
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
                var query = _categoryRepository.get(cat => cat.IdCategory == id);
                var existingCategory = await query.FirstOrDefaultAsync();
                if (existingCategory != null)
                {
                    var deleteCategory = await _categoryRepository.Delete(existingCategory);
                    if (!deleteCategory)
                        throw new TaskCanceledException("No se pudo eliminar");
                    return deleteCategory;
                }
                    
                else
                    throw new TaskCanceledException("No se encontro");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategotyDTO> GetCategory(int id)
        {
            try
            {
                var query = _categoryRepository.get(cat => cat.IdCategory == id);
                var existingCategory = await query.FirstOrDefaultAsync();
                if (existingCategory != null)
                    return _mapper.Map<CategotyDTO>(existingCategory);
                else
                    throw new TaskCanceledException("No se encontro");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(CategotyDTO category)
        {
            try
            {
                var query = _categoryRepository.get(cat => cat.IdCategory == category.Id);
                var existingCategory = await query.FirstOrDefaultAsync();
                if (existingCategory != null)
                {
                    existingCategory.NameCategory = category.Name;
                   var updateCategory = await _categoryRepository.Update(existingCategory);
                    if (!updateCategory)
                        throw new TaskCanceledException("No se pudo actulizar");
                    return updateCategory;
                }
                else
                    throw new TaskCanceledException("No se encontro");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
