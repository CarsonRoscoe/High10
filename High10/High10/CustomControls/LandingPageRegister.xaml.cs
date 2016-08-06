using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace High10.CustomControls {
  public partial class LandingPageRegister : Grid {
    public static readonly BindableProperty UsernameProperty = BindableProperty.Create( nameof( Username ), typeof( string ), typeof( LandingPageRegister ), "" );
    public string Username {
      get { return (string)GetValue( UsernameProperty ); }
      protected set { SetValue( UsernameProperty, value ); }
    }

    public static readonly BindableProperty PasswordProperty = BindableProperty.Create( nameof( Password ), typeof( string ), typeof( LandingPageRegister ), "" );
    public string Password {
      get { return (string)GetValue( PasswordProperty ); }
      protected set { SetValue( PasswordProperty, value ); }
    }

    public LandingPageRegister() {
      InitializeComponent();
      UsernameEntry.TextChanged += UsernameEntry_TextChanged;
      PasswordEntry.TextChanged += PasswordEntry_TextChanged;
    }

    private void UsernameEntry_TextChanged( object sender, TextChangedEventArgs e ) {
      Username = e.NewTextValue;
    }

    private void PasswordEntry_TextChanged( object sender, TextChangedEventArgs e ) {
      Password = e.NewTextValue;
    }
  }
}
