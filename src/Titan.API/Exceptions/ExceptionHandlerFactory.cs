using System.Data.Common;
using Titan.API.Exceptions.Base;
using Titan.API.Exceptions.Handlers;

namespace Titan.API.Exceptions
{
    public static class ExceptionHandlerFactory
    {
        private static Exception DefaultException
            => new("Unhandled exception");

        /// <summary>
        /// Create a handler for the specified exception.
        /// </summary>
        /// <param name="exception">Exception, if null, then the factory will use the default one <see cref="DefaultException"/></param>
        /// <returns>Exception handler</returns>
        public static IExceptionHandler CreateHandler(Exception? exception) => exception switch
        {
            DbException _ => new MySqlExceptionHandler(exception),
            
            _ => new DefaultExceptionHandler(DefaultException),
        };
    }
}
