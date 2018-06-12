using System;
using System.Runtime.CompilerServices;
using High10.ViewModels;
using Xamarin.Forms;

namespace High10.Views {
  public partial class MasterDetailContainerPage : MasterDetailPage {
    public static readonly BindableProperty ToggleMasterDetailProperty = BindableProperty.Create( nameof( ToggleMasterDetail ), typeof( Action ), typeof( MasterDetailContainerPage ) );
    public Action ToggleMasterDetail {
      get { return (Action)GetValue( ToggleMasterDetailProperty ); }
      set { SetValue( ToggleMasterDetailProperty, value ); }
    }

    public MasterDetailContainerPage() {
      InitializeComponent();
      NavigationPage.SetHasNavigationBar( this, false );
      SetBinding( ToggleMasterDetailProperty, new Binding( nameof( ToggleMasterDetail ), BindingMode.OneWayToSource ) );
      ToggleMasterDetail = () => IsPresented = !IsPresented;
    }
  }
}