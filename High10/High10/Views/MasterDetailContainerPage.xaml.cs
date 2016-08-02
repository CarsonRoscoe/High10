using System;
using Xamarin.Forms;

namespace High10.Views {
  public partial class MasterDetailContainerPage : MasterDetailPage {
    public MasterDetailContainerPage() {
      InitializeComponent();
      NavigationPage.SetHasNavigationBar( this, false );
      if (Detail is MasterDetailNavigationPage) {
        ((MasterDetailNavigationPage)Detail).ToggleMaster = () => IsPresented = !IsPresented;
      }
    }
  }
}