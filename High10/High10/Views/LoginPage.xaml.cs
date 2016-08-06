using System.Runtime.CompilerServices;
using High10.CustomControls;
using High10.Views;
using Xamarin.Forms;

namespace High10.Views {
  public enum LoginPageType { LoggedOut, LogIn, Register }

  public partial class LoginPage : ContentPage {
    private static readonly int LeftPanelXOffset = 2000;
    private static readonly int CenterPanelXOffset = 0;
    private static readonly int RightPanelXOffset = -LeftPanelXOffset;

    public static readonly BindableProperty LoginPageTypeProperty = BindableProperty.Create( nameof( LoginPageType ), typeof( LoginPageType ), typeof( LoginPage ), LoginPageType.LoggedOut );
    public LoginPageType LoginPageType {
      get { return (LoginPageType)GetValue( LoginPageTypeProperty ); }
      protected set { SetValue( LoginPageTypeProperty, value ); }
    }

    public LoginPage() {
      InitializeComponent();

      LandingPageRegister.TranslateTo( RightPanelXOffset, 0, 0 );
      LandingPageLogIn.TranslateTo( LeftPanelXOffset, 0, 0 );

      SetBinding( LoginPageTypeProperty, new Binding( nameof( LoginPageType ), BindingMode.TwoWay ) );
    }

    protected override void OnPropertyChanged( [CallerMemberName] string propertyName = null ) {
      base.OnPropertyChanged( propertyName );
      if ( propertyName == nameof( LoginPageType ) ) {
        switch ( LoginPageType ) {
          case LoginPageType.LoggedOut:
            AnimateControls(CenterPanelXOffset);
            break;
          case LoginPageType.LogIn:
            AnimateControls( RightPanelXOffset );
            break;
          case LoginPageType.Register:
            AnimateControls( LeftPanelXOffset );
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


    private void AnimateControls(int xOffset) {
      uint animationTime = 250;
      LandingPageRegister.TranslateTo( -2000 + xOffset, 0, animationTime );
      LandingPageLoggedOut.TranslateTo( 0 + xOffset, 0, animationTime );
      LandingPageLogIn.TranslateTo( 2000 + xOffset, 0, animationTime );
    }
  }
}
