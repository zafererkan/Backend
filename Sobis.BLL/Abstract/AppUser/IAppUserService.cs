using Sobis.Common.Dto;
using Sobis.Core.Entities.Concrete;
using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Entities.Dto.AppUser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sobis.BLL.Abstract.AppUser
{
    public interface IAppUserService : IServiceSample
    {
        Task<IDataResult<AppUserDto>> GetAsync(GetDto ID);
        Task<IDataResult<AppUserDto>> GetAppUserByEmailorPhone(AppUserLoginDto AppUserLoginDto);
        Task<IDataResult<IEnumerable<AppUserDto>>> GetAllAsync(AppUserDto entity = null);
        Task<IResult> AddAsync(AppUserAddDto entity);
        Task<IResult> AddBulkAsync(IEnumerable<AppUserAddDto> entity);
        Task<IResult> UpdateAsync(AppUserUpdateDto entity);
        Task<IDataResult<IEnumerable<AppClaimEntity>>> GetClaims(AppUserDto user);
        Task<IResult> UpdateDefaultCompanyAsync(AppUserUpdateDefaultCompanyDto AppUserUpdateDefaultCompanyDto);
    }
}
