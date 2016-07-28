using Prism.Unity;
using Xamarin.Forms;
using Microsoft.Practices.Unity;
using Prism.Events;
using High10.Views;
using High10.Interfaces;
using High10.DataProvider;

namespace High10 {
    public partial class App : PrismApplication {
        protected override void OnInitialized() {
            InitializeComponent();
            NavigationService.NavigateAsync(nameof(LandingPage));
        }

        protected override void RegisterTypes() {
            Container.RegisterType<ILoginHelper, LoginHelper>();
            Container.RegisterType<IRestHelper, RestHelper>();
            Container.RegisterType<IDatabaseHelper, DatabaseHelper>();
            Container.RegisterInstance(typeof(ModelHelper), new ModelHelper(Container.Resolve<IRestHelper>(), Container.Resolve<IDatabaseHelper>(), Container.Resolve<ILoginHelper>()));

            Container.RegisterTypeForNavigation<LandingPage>();
            Container.RegisterTypeForNavigation<MasterDetailContainerPage>();
            Container.RegisterTypeForNavigation<MessagesPage>();
        }
    }
}
