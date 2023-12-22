// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Hosting
{
    public class FormHostLifetime : IHostLifetime, IDisposable
    {
        private readonly ILogger<FormHostLifetime> logger;
        private readonly IHostApplicationLifetime hostApplicationLifetime;

        public FormHostLifetime(ILogger<FormHostLifetime> logger,
                                IHostApplicationLifetime hostApplicationLifetime)
        {
            this.logger = logger;
            this.hostApplicationLifetime = hostApplicationLifetime;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogDebug("StopAsync: " + GetHashCode().ToString());
            return Task.CompletedTask;
        }

        public Task WaitForStartAsync(CancellationToken cancellationToken)
        {
            System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.ApplicationExit += Application_ApplicationExit;
            logger.LogDebug("WaitForStartAsync: " + GetHashCode().ToString());
            return Task.CompletedTask;
        }

        private void Application_ApplicationExit(object? sender, EventArgs e)
        {
            System.Windows.Forms.Application.ApplicationExit -= Application_ApplicationExit;
            hostApplicationLifetime.StopApplication();
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
