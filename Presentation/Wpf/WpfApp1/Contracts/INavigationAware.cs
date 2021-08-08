namespace CiccioGest.Presentation.WpfApp.Contracts
{
    public interface INavigationAware
    {
        void OnNavigatedTo(object parameter);

        void OnNavigatedFrom();
    }
}
