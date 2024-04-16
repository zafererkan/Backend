using Microsoft.AspNetCore.Mvc;
using Sobis.BLL.Abstract;
using Sobis.Common.Dto;
using Sobis.Entities.Dto.Product;
using System.Threading.Tasks;

namespace Sobis.WebAPI.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService Service;

        public ProductsController(IProductService service)
        {
            Service = service;
        }

        [HttpPost("GetList")]
        public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> GetList(ProductDto entity)
        {
            return await Service.GetAllAsync(entity);
        }
        [HttpPost("GetListByIdAsync")]
        public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> GetListByIdAsync(GetDto entity)
        {
            return await Service.GetListByIdAsync(entity);
        }
        [HttpPost("Get")]
        public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> Get(GetDto entity)
        {
            return await Service.GetAsync(entity);
        }

        [HttpPost("Add")]
        public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> Add(ProductAddDto entity)
        {
            return await Service.AddAsync(entity);
        }
        [HttpPost("Update")]
        public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> Update(ProductUpdateDto entity)
        {
            return await Service.UpdateAsync(entity);
        }
        [HttpPost("Delete")]
        public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> Delete(DeleteDto entity)
        {
            return await Service.DeleteAsync(entity);
        }
    }
}
