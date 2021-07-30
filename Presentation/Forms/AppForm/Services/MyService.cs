using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.AppForm.Services
{
    public class MyService : IDisposable
    {
        private readonly ILogger<MyService> logger;

        public MyService(ILogger<MyService> logger)
        {
            this.logger = logger;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public string MyId => GetHashCode().ToString();

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
