using Prism.Unity;
using Xamarin.Forms;
using Microsoft.Practices.Unity;
using Prism.Events;
using High10.Views;

namespace High10 {
    public partial class App : PrismApplication {
        protected override void OnInitialized() {
            InitializeComponent();
            NavigationService.NavigateAsync(nameof(LandingPage));
        }

        protected override void RegisterTypes() {
            //Container.RegisterType<ILoginDataStatusProvider, LoginDataStatusProvider>();

            Container.RegisterTypeForNavigation<LandingPage>();
            Container.RegisterTypeForNavigation<MasterDetailContainerPage>();
            Container.RegisterTypeForNavigation<MessagesPage>();
        }
    }
}
