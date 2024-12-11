using System.Data.Common;
using Titan.API.Exceptions.Base;

namespace Titan.API.Exceptions.Handlers
{
    public sealed class DbExceptionHandler(Exception exception) : BaseExceptionHandler(exception)
    {
        public override async Task HandleException(HttpContext context, ILogger? logger = null)
        {
            var databaseException = Error as DbException;

            switch (databaseException!.ErrorCode) 
            { 
         

            }

        }
    }
}
