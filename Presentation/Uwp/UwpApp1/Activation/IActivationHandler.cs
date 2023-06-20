using System;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.UwpApp.Activation
{
    // For more information on understanding and extending activation flow see
    // https://github.com/microsoft/TemplateStudio/blob/main/docs/UWP/activation.md
    internal interface IActivationHandler
    {
        bool CanHandle(object args);

        Task HandleAsync(object args);
    }
}
