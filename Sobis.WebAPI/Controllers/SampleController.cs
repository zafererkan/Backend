using Microsoft.AspNetCore.Mvc;

namespace Sobis.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        //private readonly ITEntityService Service;

        //public SampleController(ITEntityService service)
        //{
        //    Service = service;
        //}

        //[HttpPost("GetList")]
        //public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> GetList(TEntityDto entity)
        //{
        //    return await Service.GetAllAsync(entity);
        //}
        //[HttpPost("GetListByIdAsync")]
        //public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> GetListByIdAsync(GetDto entity)
        //{
        //    return await Service.GetListByIdAsync(entity);
        //}
        //[HttpPost("Get")]
        //public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> Get(GetDto entity)
        //{
        //    return await Service.GetAsync(entity);
        //}

        //[HttpPost("Add")]
        //public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> Add(TEntityAddDto entity)
        //{
        //    return await Service.AddAsync(entity);
        //}
        //[HttpPost("Update")]
        //public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> Update(TEntityUpdateDto entity)
        //{
        //    return await Service.UpdateAsync(entity);
        //}
        //[HttpPost("Delete")]
        //public async Task<Sobis.Core.Utilities.Results.Abstract.IResult> Delete(DeleteDto entity)
        //{
        //    return await Service.DeleteAsync(entity);
        //}
    }
}
