using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using High10.Interfaces;
using High10.ViewModels;

namespace High10.DataStructures {
  public class SearchableObservableCollection : ObservableCollection<ISearchable> {
    private List<ISearchable> m_allModels;
    private HashSet<int> m_isModelHidden;
    private int m_indexCount;

    public SearchableObservableCollection() {
      m_indexCount = 0;
      m_allModels = new List<ISearchable>();
      m_isModelHidden = new HashSet<int>();
    }

    public new void Add( ISearchable item ) {
      base.Add( item );
      m_allModels.Add( item );
    }

    public new void Clear() {
      base.Clear();
      m_allModels.Clear();
      m_indexCount = 0;
    }

    private void HideModel( int index ) {
      if ( !m_isModelHidden.Contains( index ) ) {
        m_isModelHidden.Add( index );
        base.Remove( m_allModels[index] );
      }
    }

    private void UnhideModel( int index ) {
      if ( m_isModelHidden.Contains( index ) ) {
        m_isModelHidden.Remove( index );
        base.Add( m_allModels[index] );
      }
    }

    public void Search( string search ) {
      for ( int i = 0; i < m_allModels.Count; i++ ) {
        var contactViewModel = m_allModels[i];
        bool wasHidden = false;
        for ( int l = 0; l < search.Length; l++ ) {
          if ( contactViewModel.SearchableValue.Length > l ) {
            if ( char.ToUpper( contactViewModel.SearchableValue[l] ) != char.ToUpper( search[l] ) ) {
              HideModel( i );
              wasHidden = true;
              break;
            }
          }
          else {
            HideModel( i );
            wasHidden = true;
            break;
          }
        }
        if ( !wasHidden ) {
          UnhideModel( i );
        }
      }
    }
  }
}
