using System.Threading.Tasks;

namespace CiccioGest.Presentation.WinUiApp1.Activation;

public interface IActivationHandler
{
    bool CanHandle(object args);

    Task HandleAsync(object args);
}
