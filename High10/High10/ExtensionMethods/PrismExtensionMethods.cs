using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace High10.ExtensionMethods {
    public static class PrismExtensionMethods {
        public static string CreateURI(this INavigationService @this, params string[] pages) {
            var result = "";
            foreach (var item in pages) {
                result += item + "/";
            }
            return result;
        }

        public async static Task NavigateToAsync<T1>(this INavigationService @this, NavigationParameters parameters = null, bool? useModalNavigation = null, bool animated = true) where T1 : Page {
            await @this.NavigateAsync(typeof(T1).Name, parameters, useModalNavigation, animated);
        }

        public async static Task NavigateToAsync<PageType1, PageType2>(this INavigationService @this, NavigationParameters parameters = null, bool? useModalNavigation = null, bool animated = true) where PageType1 : Page where PageType2 : Page {
            await @this.NavigateAsync(typeof(PageType1).Name + "/" + typeof(PageType2).Name, parameters, useModalNavigation, animated );
    }

        public async static Task NavigateToAsync<PageType1, PageType2, PageType3>(this INavigationService @this, NavigationParameters parameters = null, bool? useModalNavigation = null, bool animated = true) where PageType1 : Page where PageType2 : Page where PageType3 : Page {
            await @this.NavigateAsync(typeof(PageType1).Name + "/" + typeof(PageType2).Name + "/" + typeof(PageType3).Name, parameters, useModalNavigation, animated );
    }
    }
}
