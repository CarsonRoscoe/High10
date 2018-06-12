using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace High10.Views {
  [XamlCompilation( XamlCompilationOptions.Compile )]
  public partial class MasterPage : ContentPage {
    public MasterPage() {
      InitializeComponent();
      NavigationPage.SetHasNavigationBar( this, false );
    }
  }
}
