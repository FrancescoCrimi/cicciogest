namespace CiccioGest.Presentation.WpfApp1.Contracts
{
    public interface INavigationAware
    {
        void OnNavigatedTo(object parameter);

        void OnNavigatedFrom();
    }
}
