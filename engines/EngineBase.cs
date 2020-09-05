using System;
using System.Threading.Tasks;
using NLog;

namespace SmartBulkCopy 
{
    public abstract class EngineBase {
        protected readonly ILogger _logger;

        public EngineBase(ILogger logger)
        {
            _logger = logger;
        }

        public abstract Task<int> Copy();
   }
}