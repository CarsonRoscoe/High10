using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace High10.CustomControls {
    public class LandingPageRegister : Grid {
        public static readonly BindableProperty UsernameProperty = BindableProperty.Create(nameof(Username), typeof(string), typeof(LandingPageLogIn), "");
        public string Username {
            get { return (string)GetValue(UsernameProperty); }
            protected set { SetValue(UsernameProperty, value); }
        }

        public static readonly BindableProperty PasswordProperty = BindableProperty.Create(nameof(Password), typeof(string), typeof(LandingPageLogIn), "");
        public string Password {
            get { return (string)GetValue(PasswordProperty); }
            protected set { SetValue(PasswordProperty, value); }
        }

        public LandingPageRegister(object bindingContext) {
            Margin = 8;

            Children.Add(new Label {
                Text = "Username",
                TextColor = (Color)Application.Current.Resources["ColorDarkText"],
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.End
            }, 0, 0);

            var usernameEntry = new Entry {
                TextColor = (Color)Application.Current.Resources["ColorDarkText"],
                BackgroundColor = (Color)Application.Current.Resources["ColorLightGray"],
                HorizontalTextAlignment = TextAlignment.Start
            };
            usernameEntry.TextChanged += UsernameEntry_TextChanged;
            Children.Add(usernameEntry, 0, 1);

            Children.Add(new Label {
                Text = "Password",
                TextColor = (Color)Application.Current.Resources["ColorDarkText"],
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.End
            }, 0, 2);

            var passwordEntry = new Entry {
                TextColor = (Color)Application.Current.Resources["ColorDarkText"],
                BackgroundColor = (Color)Application.Current.Resources["ColorLightGray"],
                HorizontalTextAlignment = TextAlignment.Start
            };
            passwordEntry.TextChanged += PasswordEntry_TextChanged;
            Children.Add(passwordEntry, 0, 3);

            var logInButton = new Button {
                TextColor = (Color)Application.Current.Resources["ColorLightText"],
                BackgroundColor = (Color)Application.Current.Resources["ColorMediumOrange"],
                BindingContext = bindingContext,
                Text = "Register"
            };
            logInButton.SetBinding(Button.CommandProperty, new Binding("RegisterButtonCommand"));
            Children.Add(logInButton, 0, 4);

            SetBinding(UsernameProperty, new Binding(nameof(Username), BindingMode.OneWayToSource));
            SetBinding(PasswordProperty, new Binding(nameof(Password), BindingMode.OneWayToSource));
        }

        private void UsernameEntry_TextChanged(object sender, TextChangedEventArgs e) {
            Username = e.NewTextValue;
        }

        private void PasswordEntry_TextChanged(object sender, TextChangedEventArgs e) {
            Password = e.NewTextValue;
        }
    }
}
