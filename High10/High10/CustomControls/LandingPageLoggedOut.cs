using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace High10.CustomControls {
    public class LandingPageLoggedOut : Grid {
        public LandingPageLoggedOut(object bindingContext) {
            RowDefinitions = new RowDefinitionCollection {
                new RowDefinition { Height = new GridLength(7, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(3, GridUnitType.Star) }
            };

            var logInButton = new Button {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                TextColor = (Color)Application.Current.Resources["ColorLightText"],
                Text = "Log In",
                BackgroundColor = (Color)Application.Current.Resources["ColorMediumOrange"],
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                BindingContext = bindingContext
            };
            logInButton.SetBinding(Button.CommandProperty, new Binding("ToLogInPageButtonCommand"));

            var registerButton = new Button {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                TextColor = (Color)Application.Current.Resources["ColorMediumGreen"],
                Text = "Don't have High10?",
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                BindingContext = bindingContext
            };
            registerButton.SetBinding(Button.CommandProperty, new Binding("ToRegisterPageButtonCommand"));

            Children.Add(logInButton, 0, 0);
            Children.Add(registerButton, 0, 1);
        }
    }
}
