using Microsoft.AspNetCore.Mvc;
using Sobis.BLL.Abstract.Category;
using Sobis.Common.Dto;
using Sobis.Entities.Dto.Category;
using System.Threading.Tasks;

namespace Sobis.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService Service;

        public CategoryController(ICategoryService service)
        {
            Service = service;
        }

        [HttpPost("GetListAsync")]
        public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> GetList(CategoryDto entity)
        {
            return await Service.GetAllAsync(entity);
        }
        [HttpPost("GetListByIdAsync")]
        public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> GetListByIdAsync(GetDto entity)
        {
            return await Service.GetListByIdAsync(entity);
        }
        [HttpPost("GetAsync")]
        public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> Get(GetDto entity)
        {
            return await Service.GetAsync(entity);
        }

        [HttpPost("AddAsync")]
        public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> Add(CategoryAddDto entity)
        {
            return await Service.AddAsync(entity);
        }
        [HttpPost("UpdateAsync")]
        public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> Update(CategoryUpdateDto entity)
        {
            return await Service.UpdateAsync(entity);
        }
        [HttpPost("DeleteAsync")]
        public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> Delete(DeleteDto entity)
        {
            return await Service.DeleteAsync(entity);
        }
    }
}
