// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Infrastructure;
using CiccioGest.Presentation.AppForm.Presenters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CiccioGest.Presentation.AppForm
{
    public  class Program
    {
        public Program(string[] args)
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                .ConfigureFormsApp()
                .BuildServiceProvider());
            if (args.Contains("config"))
            {
                var presenter = Ioc.Default.GetRequiredService<SettingPresenter>();
                presenter.Run();
            }
            else
            {
                var win = Ioc.Default.GetRequiredService<MainPresenter>();
                win.Run();
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();
            _ = new Program(args);
        }
    }
}
