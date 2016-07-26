using System.Runtime.CompilerServices;
using High10.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace High10.Views {
    public enum LandingPageType { LoggedOut, LogIn, Register }

    public partial class LandingPage : ContentPage {
        LandingPageLoggedOut _loggedOutGrid;
        LandingPageLogIn _logInGrid;
        LandingPageRegister _registerGrid;

        public static readonly BindableProperty LandingPageTypeProperty = BindableProperty.Create(nameof(LandingPageType), typeof(LandingPageType), typeof(LandingPage), LandingPageType.LoggedOut);
        public LandingPageType LandingPageType {
            get { return (LandingPageType)GetValue(LandingPageTypeProperty); }
            protected set { SetValue(LandingPageTypeProperty, value); }
        }

        public LandingPage() {
            InitializeComponent();

            _loggedOutGrid = new LandingPageLoggedOut(BindingContext);
            _logInGrid = new LandingPageLogIn(BindingContext);
            _registerGrid = new LandingPageRegister(BindingContext);
            _contentGrid.Children.Add(_loggedOutGrid, 0, 1);
            _contentGrid.Children.Add(_logInGrid, 0, 1);
            _contentGrid.Children.Add(_registerGrid, 0, 1);

            _registerGrid.TranslateTo(-2000, 0, 0);
            _logInGrid.TranslateTo(2000, 0, 0);

            SetBinding(LandingPageTypeProperty, new Binding(nameof(LandingPageType), BindingMode.TwoWay));
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(LandingPageType)) {
                switch(LandingPageType) {
                    case LandingPageType.LoggedOut:
                        _registerGrid.TranslateTo(-2000, 0, 250);
                        _loggedOutGrid.TranslateTo(0, 0, 250);
                        _logInGrid.TranslateTo(2000, 0, 250);
                        break;
                    case LandingPageType.LogIn:
                        _registerGrid.TranslateTo(-4000, 0, 250);
                        _loggedOutGrid.TranslateTo(-2000, 0, 250);
                        _logInGrid.TranslateTo(0, 0, 250);
                        break;
                    case LandingPageType.Register:
                        _registerGrid.TranslateTo(0, 0, 250);
                        _loggedOutGrid.TranslateTo(2000, 0, 250);
                        _logInGrid.TranslateTo(4000, 0, 250);
                        break;
                }
            }
        }

        protected override bool OnBackButtonPressed() {
            if (LandingPageType != LandingPageType.LoggedOut) {
                LandingPageType = LandingPageType.LoggedOut;
                return true;
            } else {
                return base.OnBackButtonPressed();
            }
        }
    }
}
