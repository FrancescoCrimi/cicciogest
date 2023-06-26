// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System.Threading.Tasks;

namespace CiccioGest.Presentation.UwpMenu.Activation
{
    // For more information on understanding and extending activation flow see
    // https://github.com/microsoft/TemplateStudio/blob/main/docs/UWP/activation.md
    internal interface IActivationHandler
    {
        bool CanHandle(object args);

        Task HandleAsync(object args);
    }
}
