using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;

namespace SmartBulkCopy
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            int result = 0;
            var logger = LogManager.GetCurrentClassLogger();
            try
            {                
                EngineBase engine;
                if (args.Length > 0)
                    engine = new SmartBulkCopy(args[0], logger);
                else 
                    engine =  new SmartBulkCopy(logger);
                
                result = await engine.Copy();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception.");
                result = 1;
            }
            finally
            {
                LogManager.Shutdown();
            }

            return result;
        }
    }
}
