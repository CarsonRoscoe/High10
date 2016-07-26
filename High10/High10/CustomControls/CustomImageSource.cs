using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace High10.CustomControls {
    public class CustomImageSource {
        public string ImagePath { get; set; }

        public static implicit operator ImageSource(CustomImageSource value) {
            var path = value?.ImagePath;
            if (!string.IsNullOrWhiteSpace(path)) {
                return ImageSource.FromResource(path);
            }
            return null;
        }
    }
}
