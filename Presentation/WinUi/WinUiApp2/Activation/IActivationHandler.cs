using System.Threading.Tasks;

namespace CiccioGest.Presentation.WinUiApp2.Activation;

public interface IActivationHandler
{
    bool CanHandle(object args);

    Task HandleAsync(object args);
}
