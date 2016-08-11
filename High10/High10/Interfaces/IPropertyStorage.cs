using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High10.Interfaces {
  public interface IPropertyStorage {

    T Get<T>( string key, T defaultValue = default( T ) );

    Task Save<T>( string key, T value );

  }
}
