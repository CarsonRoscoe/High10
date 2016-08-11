using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Xamarin.Forms;

[assembly: Dependency( typeof( High10.Storage.PropertyStorage ) )]
namespace High10.Storage {
  public class PropertyStorage : IPropertyStorage {
    public T Get<T>( string key, T defaultValue = default( T ) ) {
      if ( Application.Current.Properties.ContainsKey( key ) ) {
        var textValue = Application.Current.Properties[key] as string;
        if ( textValue != null ) {
          return JsonConvert.DeserializeObject<T>( textValue );
        }
      }
      return defaultValue;
    }

    public Task Save<T>( string key, T value ) {
      if ( key != null ) {
        if ( value != null ) {
          Application.Current.Properties[key] = JsonConvert.SerializeObject( value );
        }
        else {
          if ( Application.Current.Properties.ContainsKey( key ) ) {
            Application.Current.Properties.Remove( key );
          }
        }
        return Application.Current.SavePropertiesAsync();
      }
      return Task.Delay( 1 );
    }
  }
}
