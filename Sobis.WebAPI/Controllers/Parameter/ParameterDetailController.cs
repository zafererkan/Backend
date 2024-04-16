using Microsoft.AspNetCore.Mvc;
using Sobis.BLL.Abstract.Parameter;
using Sobis.Common.Dto;
using Sobis.Entities.Dto.Parameter;
using System.Threading.Tasks;

namespace Sobis.WebAPI.Controllers.Parameter
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterDetailController : ControllerBase
    {
        private readonly IParameterDetailService Service;

        public ParameterDetailController(IParameterDetailService parameterDetailService)
        {
            Service = parameterDetailService;
        }

        [HttpPost("GetListByIdAsync")]
        public async Task<Core.Utilities.Results.Abstract.IResult> GetListByIdAsync(ParameterDetailDto entity)
        {
            return await Service.GetListByParameterIdAsync(entity);
        }

        [HttpPost("GetList")]
        public async Task<Core.Utilities.Results.Abstract.IResult> GetList(ParameterDetailDto entity)
        {
            return await Service.GetAllAsync(entity);
        }

        [HttpPost("Get")]
        public async Task<Core.Utilities.Results.Abstract.IResult> Get(GetDto entity)
        {
            return await Service.GetAsync(entity);
        }

        [HttpPost("Add")]
        public async Task<Core.Utilities.Results.Abstract.IResult> Add(ParameterDetailAddDto entity)
        {
            return await Service.AddAsync(entity);
        }
        [HttpPost("Update")]
        public async Task<Core.Utilities.Results.Abstract.IResult> Update(ParameterDetailAddDto entity)
        {
            return await Service.UpdateAsync(entity);
        }
        [HttpPost("Delete")]
        public async Task<Core.Utilities.Results.Abstract.IResult> Delete(DeleteDto entity)
        {
            return await Service.DeleteAsync(entity);
        }
    }
}
