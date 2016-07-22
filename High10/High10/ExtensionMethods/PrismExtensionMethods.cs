using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High10.ExtensionMethods {
    public static class PrismExtensionMethods {
        public static string CreateURI(this INavigationService @this, params string[] pages) {
            var result = "";
            foreach (var item in pages) {
                result += item + "/";
            }
            return result;
        }
    }
}
