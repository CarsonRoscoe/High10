using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace High10.CustomControls {
  // NOTE: Allows Android to bypass the action bar implementation of ContextActions via a custom renderer.
  // iOS can use ContextActions as usual
  // Create subcasses for each ViewModel combination
  public abstract class LongPressListView : ListView {
    public abstract void HandleItemLongPressed( int index );
  }
}
