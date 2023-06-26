// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System.Threading.Tasks;

namespace CiccioGest.Presentation.UwpMenu.Activation
{
    // Extend this class to implement new ActivationHandlers
    internal abstract class ActivationHandler<T> : IActivationHandler
        where T : class
    {
        // You can override this method to add extra validation on activation args
        // to determine if your ActivationHandler should handle this activation args
        protected virtual bool CanHandleInternal(T args) => true;

        // Override this method to add the activation logic in your activation handler
        protected abstract Task HandleInternalAsync(T args);

        // CanHandle checks the args is of type you have configured
        public bool CanHandle(object args) => args is T && CanHandleInternal(args as T);

        public async Task HandleAsync(object args) => await HandleInternalAsync(args as T);
    }
}
