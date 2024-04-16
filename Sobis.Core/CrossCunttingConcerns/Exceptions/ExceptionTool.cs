using FluentValidation;
using Sobis.Core.Entities.Abstract;
using Sobis.Core.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.Core.CrossCunttingConcerns.Exceptions
{
    public static class ExceptionTool
    {
        public static void LogException(ILoggerService LoggerService, Exception ex)
        {

            LoggerService.LogError(ex);
        }
    }
}
