// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.FormsApp.Presenters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.FormsApp
{
    public class Program
    {
        [STAThread]
        static async Task Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
            builder.ConfigureFormsApp();

            IHost host = builder.Build();
            await host.StartAsync();

            ApplicationConfiguration.Initialize();
            if (args.Contains("config"))
            {
                var presenter = host.Services.GetRequiredService<SettingPresenter>();
                presenter.Run();
            }
            else
            {
                var win = host.Services.GetRequiredService<MainPresenter>();
                win.Run();
            }
        }
    }
}
