using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using High10.BusinessModels;
using High10.ExtensionMethods;
using System.Collections.ObjectModel;
using High10.Interfaces;

namespace High10.ViewModels {
  public class ContactViewModel : ISearchable {
    User m_user;

    public ContactViewModel( User user ) {
      m_user = user;
    }

    public string Points {
      get {
        return m_user.Points.ToString();
      }
    }

    private ImageSource _profilePicture;
    public ImageSource ProfilePicture {
      get {
        if ( _profilePicture == null && !string.IsNullOrEmpty( m_user.Base64ProfilePicture ) ) {
          _profilePicture = m_user.Base64ProfilePicture.ToImageSource();
        }
        return _profilePicture;
      }
    }

    public bool IsInitialVisible {
      get { return string.IsNullOrEmpty( m_user.Base64ProfilePicture ); }
    }

    private Color _circleColor;
    public Color CircleColor {
      get {
        if ( _circleColor == null ) {
          var hash = m_user.Username.GetHashCode();
          var red = hash % 255;
          var green = (hash % 25) * 10;
          var blue = (hash % 75) * 3;
          _circleColor = Color.FromRgb( red, green, blue ).AddLuminosity( .8 ).WithSaturation( .8 );
        }
        return _circleColor;
      }
    }

    public string Initial {
      get {
        return m_user.Username[0].ToString();
      }
    }

    public string Username {
      get {
        return m_user.Username;
      }
    }

    public string SearchableValue {
      get {
        return Username;
        ;
      }
    }
  }
}
