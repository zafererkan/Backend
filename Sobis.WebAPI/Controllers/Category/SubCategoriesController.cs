using Microsoft.AspNetCore.Mvc;
using Sobis.BLL.Abstract.Category;
using Sobis.Common.Dto;
using Sobis.Entities.Dto.Category;
using System.Threading.Tasks;

namespace Sobis.WebAPI.Controllers.Category
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ISubCategoryService Service;

        public SubCategoriesController(ISubCategoryService service)
        {
            Service = service;
        }

        [HttpPost("GetListAsync")]
        public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> GetListAsync(SubCategoryDto entity)
        {
            return await Service.GetAllAsync(entity);
        }
        [HttpPost("GetListByIdAsync")]
        public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> GetListByIdAsync(GetDto entity)
        {
            return await Service.GetListByIdAsync(entity);
        }
        [HttpPost("GetAsync")]
        public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> GetAsync(GetDto entity)
        {
            return await Service.GetAsync(entity);
        }

        [HttpPost("AddAsync")]
        public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> AddAsync(SubCategoryAddDto entity)
        {
            return await Service.AddAsync(entity);
        }
        [HttpPost("UpdateAsync")]
        public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> UpdateAsync(SubCategoryUpdateDto entity)
        {
            return await Service.UpdateAsync(entity);
        }
        [HttpPost("DeleteAsync")]
        public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> DeleteAsync(DeleteDto entity)
        {
            return await Service.DeleteAsync(entity);
        }
    }
}
