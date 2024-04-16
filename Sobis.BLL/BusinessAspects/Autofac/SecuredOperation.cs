using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Sobis.Core.Extensions;
using Sobis.Core.Utilities.Interceptors;
using Sobis.Core.Utilities.IoC;
using System;

namespace Sobis.BLL.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles = null)
        {
            if (!roles.IsNullOrEmpty())
            {
                _roles = roles.Split(',');
            }
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            if (_roles.IsNullOrEmpty())
            {
                if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                {
                    throw new UnauthorizedAccessException("Yetkisiz bir işlem gerçekleştirmeye çalışıldı!");
                }
            }
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            if (roleClaims.Contains("admin"))
            {
                return;
            }
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated && _roles.IsNullOrEmpty())
            {
                return;
            }
            throw new Exception("Yetkisiz Erişim. Lütfen Sistem Yöneticisine başvurunuz.");
        }
    }
}
