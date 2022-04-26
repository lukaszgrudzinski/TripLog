using TripLog.ViewModels;

namespace TripLog.Services
{
    public interface INavigationService
    {
        bool CanGoBack { get; }
        Task GoBack();
        Task NavigateTo<TVM>() where TVM : BaseViewModel;
        Task NavigateTo<TVM, TParameter>(TParameter parameter) where TVM : BaseViewModel;
        void RemoveLastView();
        void ClearBackStack();
        void NavigateToUri(Uri uri);
        event PropertyChangingEventHandler? CanGoBackChanged;
    }
}
