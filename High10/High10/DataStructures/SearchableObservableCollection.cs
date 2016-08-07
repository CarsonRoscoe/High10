using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using High10.ViewModels;

namespace High10.DataStructures {
  public class SearchableObservableCollection : ObservableCollection<ContactViewModel> {
    private List<ContactViewModel> m_allModels;

    public SearchableObservableCollection() {
      m_allModels = new List<ContactViewModel>();
    }

    public new void Add(ContactViewModel item) {
      base.Add( item );
    }

    public new void Clear() {
      base.Clear();
      m_allModels.Clear();
    }

    public void Search(string search) {

    }
  }
}
