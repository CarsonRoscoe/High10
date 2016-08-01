using System.Runtime.CompilerServices;
using High10.CustomControls;
using High10.Views;
using Xamarin.Forms;

namespace High10.Views {
  public enum LoginPageType { LoggedOut, LogIn, Register }

  public partial class LoginPage : ContentPage {
    LandingPageLoggedOut _loggedOutGrid;
    LandingPageLogIn _logInGrid;
    LandingPageRegister _registerGrid;

    public static readonly BindableProperty LoginPageTypeProperty = BindableProperty.Create( nameof( LoginPageType ), typeof( LoginPageType ), typeof( LoginPage ), LoginPageType.LoggedOut );
    public LoginPageType LoginPageType {
      get { return (LoginPageType)GetValue( LoginPageTypeProperty ); }
      protected set { SetValue( LoginPageTypeProperty, value ); }
    }

    public LoginPage() {
      InitializeComponent();

      _loggedOutGrid = new LandingPageLoggedOut( BindingContext );
      _logInGrid = new LandingPageLogIn( BindingContext );
      _registerGrid = new LandingPageRegister( BindingContext );
      _contentGrid.Children.Add(_loggedOutGrid, 0, 1);
      _contentGrid.Children.Add(_logInGrid, 0, 1);
      _contentGrid.Children.Add(_registerGrid, 0, 1);

      _registerGrid.TranslateTo( -2000, 0, 0 );
      _logInGrid.TranslateTo( 2000, 0, 0 );

      SetBinding( LoginPageTypeProperty, new Binding( nameof( LoginPageType ), BindingMode.TwoWay ) );
    }

    protected override void OnPropertyChanged( [CallerMemberName] string propertyName = null ) {
      base.OnPropertyChanged( propertyName );
      if ( propertyName == nameof( LoginPageType ) ) {
        switch ( LoginPageType ) {
          case LoginPageType.LoggedOut:
            _registerGrid.TranslateTo( -2000, 0, 250 );
            _loggedOutGrid.TranslateTo( 0, 0, 250 );
            _logInGrid.TranslateTo( 2000, 0, 250 );
            break;
          case LoginPageType.LogIn:
            _registerGrid.TranslateTo( -4000, 0, 250 );
            _loggedOutGrid.TranslateTo( -2000, 0, 250 );
            _logInGrid.TranslateTo( 0, 0, 250 );
            break;
          case LoginPageType.Register:
            _registerGrid.TranslateTo( 0, 0, 250 );
            _loggedOutGrid.TranslateTo( 2000, 0, 250 );
            _logInGrid.TranslateTo( 4000, 0, 250 );
            break;
        }
      }
    }

    protected override bool OnBackButtonPressed() {
      if ( LoginPageType != LoginPageType.LoggedOut ) {
        LoginPageType = LoginPageType.LoggedOut;
        return true;
      }
      else {
        return base.OnBackButtonPressed();
      }
    }
  }
}
