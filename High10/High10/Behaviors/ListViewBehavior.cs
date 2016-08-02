using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace High10.Behaviors {
  public static class ListViewBehavior {
    public static readonly BindableProperty ClearSelectionProperty = BindableProperty.CreateAttached( nameof( ClearSelection), typeof( bool ), typeof( ListViewBehavior ), false, propertyChanged: OnClearSelectionChanged );
    public static bool ClearSelection { get; set; }

    static void OnClearSelectionChanged( BindableObject view, object oldValue, object newValue ) {
      var listView = view as ListView;
      if ( listView == null )
        return;

      listView.ItemTapped -= ClearSelectionOnTap;
      if ( (bool)newValue ) {
        listView.ItemTapped += ClearSelectionOnTap;
      }
    }

    static void ClearSelectionOnTap( object sender, EventArgs e ) {
      var listView = sender as ListView;
      if ( listView != null ) {
        listView.SelectedItem = null;
      }
    }
  }
}
