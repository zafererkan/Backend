using Autofac.Core;
using Microsoft.AspNetCore.Mvc;
using Sobis.BLL.Abstract.AppUser;
using Sobis.Common.Dto;
using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Entities.Dto.AppUser;
using Sobis.Entities.Dto.AppUser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sobis.WebAPI.Controllers.AppUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IAppUserService Service;

        public AppUsersController(IAppUserService userservice)
        {
            Service = userservice;
        }

        //[HttpGet("GetAppUser")]
        //public async Task<IDataResult<AppUserDto>> GetAppUser(int? Id)
        //{
        //    var result = await userservice.GetAsync(Id);
        //    return result;
        //}

        //[HttpPost("AddAppUser")]
        //public async Task<IResult> AddAppUser(AppUserAddDto entity)
        //{
        //    return await userservice.AddAsync(entity);
        //}
        //[HttpPost("AddBulkAppUser")]
        //public async Task<IResult> AddBulkAppUser(IEnumerable<AppUserAddDto> entity)
        //{
        //    return await userservice.AddBulkAsync(entity);
        //}
        [HttpPost("UpdateDefaultCompany")]
        public async Task<IResult> UpdateDefaultCompany(AppUserUpdateDefaultCompanyDto AppUserUpdateDefaultCompanyDto)
        {
            return await Service.UpdateDefaultCompanyAsync(AppUserUpdateDefaultCompanyDto);
        }

        [HttpPost("GetList")]
        public async Task<IResult> GetList(AppUserDto entity)
        {
            return await Service.GetAllAsync(entity);
        }
        [HttpPost("Get")]
        public async Task<IResult> Get(GetDto entity)
        {
            return await Service.GetAsync(entity);
        }

        [HttpPost("Add")]
        public async Task<IResult> Add(AppUserAddDto entity)
        {
            return await Service.AddAsync(entity);
        }
        [HttpPost("Update")]
        public async Task<IResult> Update(AppUserUpdateDto entity)
        {
            return await Service.UpdateAsync(entity);
        }
        [HttpPost("Delete")]
        public async Task<IResult> Delete(DeleteDto entity)
        {
            return await Service.DeleteAsync(entity);
        }

    }
}