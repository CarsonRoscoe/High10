using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using High10.CustomControls;
using High10.ViewModels;
using Xamarin.Forms;

namespace High10.ViewCells {
  public partial class ContactCell : FastCell {
    protected override void InitializeCell() {
      InitializeComponent();
    }

    protected override void SetupCell( bool isRecycled ) {
      var viewModel = BindingContext as ContactViewModel;
      if (viewModel != null ) {
        Username.Text = viewModel.Username;
        Points.Text = viewModel.Points;
        ProfilePicture.Source = viewModel.ProfilePicture;
      }
    }
  }
}
