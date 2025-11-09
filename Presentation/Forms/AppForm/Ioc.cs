// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace CiccioGest.Presentation.AppForm
{
    public sealed class Ioc : IServiceProvider
    {
        public static Ioc Default { get; } = new();

        private volatile IServiceProvider? serviceProvider;

        public object? GetService(Type serviceType)
        {
            //ArgumentNullException.ThrowIfNull(serviceType);

            IServiceProvider? provider = serviceProvider;

            if (provider is null)
            {
                ThrowInvalidOperationExceptionForMissingInitialization();
            }

            return provider!.GetService(serviceType);
        }

        public T? GetService<T>()
            where T : class
        {
            IServiceProvider? provider = serviceProvider;

            if (provider is null)
            {
                ThrowInvalidOperationExceptionForMissingInitialization();
            }

            return (T?)provider!.GetService(typeof(T));
        }

        public T GetRequiredService<T>()
            where T : class
        {
            IServiceProvider? provider = serviceProvider;

            if (provider is null)
            {
                ThrowInvalidOperationExceptionForMissingInitialization();
            }

            T? service = (T?)provider!.GetService(typeof(T));

            if (service is null)
            {
                ThrowInvalidOperationExceptionForUnregisteredType();
            }

            return service!;
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            //ArgumentNullException.ThrowIfNull(serviceProvider);

            IServiceProvider? oldServices = Interlocked.CompareExchange(ref this.serviceProvider, serviceProvider, null);

            if (oldServices is not null)
            {
                ThrowInvalidOperationExceptionForRepeatedConfiguration();
            }
        }

        [DoesNotReturn]
        private static void ThrowInvalidOperationExceptionForMissingInitialization()
        {
            throw new InvalidOperationException("The service provider has not been configured yet.");
        }

        [DoesNotReturn]
        private static void ThrowInvalidOperationExceptionForUnregisteredType()
        {
            throw new InvalidOperationException("The requested service type was not registered.");
        }

        [DoesNotReturn]
        private static void ThrowInvalidOperationExceptionForRepeatedConfiguration()
        {
            throw new InvalidOperationException("The default service provider has already been configured.");
        }
    }
}