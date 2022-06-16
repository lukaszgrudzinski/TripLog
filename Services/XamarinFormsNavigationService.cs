using System.Reflection;
using TripLog.Services;
using TripLog.ViewModels;

namespace TripLog.Services
{
    public class XamarinFormsNavigationService : INavigationService
    {
        public INavigation? XamarinFormsNav { get; set; }
        private readonly Dictionary<Type, Type> _map = new();
        public bool CanGoBack => XamarinFormsNav?.NavigationStack?.Any() == true;

        public event PropertyChangingEventHandler? CanGoBackChanged;

        public void RegisterViewMapping(Type viewModel, Type view)
        {
            _map.Add(viewModel, view);
        }

        public void ClearBackStack()
        {
            if(XamarinFormsNav?.NavigationStack.Count < 2)
            {
                return;
            }

            foreach (Page page in XamarinFormsNav!.NavigationStack)
            {
                XamarinFormsNav.RemovePage(page);
            }
        }

        public async Task GoBack()
        {
            if(CanGoBack)
            {
                await XamarinFormsNav!.PopAsync(true);

                OnCanGoBackChanged();
            }
        }

        protected void OnCanGoBackChanged()
        {
            CanGoBackChanged?.Invoke(this, new PropertyChangingEventArgs(nameof(CanGoBack)));
        }

        public async Task NavigateTo<TVM>() where TVM : BaseViewModel
        {
            await NavigateToView(typeof(TVM));

            if(XamarinFormsNav?.NavigationStack.Last().BindingContext is BaseViewModel viewModel)
            {
                viewModel.Init();
            }
        }

        private async Task NavigateToView(Type viewModelType)
        {
            if(!_map.TryGetValue(viewModelType, out Type viewType))
            {
                throw new ArgumentException($"No view found mapped for ViewModel '{viewModelType.FullName}'");
            }

            ConstructorInfo constructor = viewType.GetTypeInfo().DeclaredConstructors.First(ctor => !ctor.GetParameters().Any());

            Page page = constructor.Invoke(null) as Page ?? throw new InvalidCastException();

            object? vm = App.ServiceProvider.GetService(viewModelType);

            page.BindingContext = vm;

            await XamarinFormsNav!.PushAsync(page, true);
        }

        public async Task NavigateTo<TVM, TParameter>(TParameter parameter) where TVM : BaseViewModel
        {
            await NavigateToView(typeof(TVM));

            if (XamarinFormsNav?.NavigationStack.Last().BindingContext is BaseViewModel<TParameter> viewModel)
            {
                viewModel.Init(parameter);
            }
        }

        public void NavigateToUri(Uri uri)
        {
            uri = uri ?? throw new ArgumentNullException(nameof(uri));

            //TODO: Navigate to Uri
        }

        public void RemoveLastView()
        {
            if(XamarinFormsNav?.NavigationStack.Count < 2)
            {
                return;
            }

            Page lastView = XamarinFormsNav!.NavigationStack[XamarinFormsNav.NavigationStack.Count - 2];

            XamarinFormsNav.RemovePage(lastView);
        }
    }
}
