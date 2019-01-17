using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.FormsSnackBarDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SnackBar : TemplatedView
    {
        public static readonly BindableProperty ButtonTextColorProperty = BindableProperty.Create("ButtonTextColor", typeof(Color), typeof(SnackBar), default(Color));
        public Color ButtonTextColor
        {
            get { return (Color)GetValue(ButtonTextColorProperty); }
            set { SetValue(ButtonTextColorProperty, value); }
        }

        public static readonly BindableProperty MessageProperty = BindableProperty.Create("Message", typeof(string), typeof(SnackBar), default(string));
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly BindableProperty CloseButtonTextProperty = BindableProperty.Create("CloseButtonText", typeof(string), typeof(SnackBar), "Close");
        public string CloseButtonText
        {
            get { return (string)GetValue(CloseButtonTextProperty); }
            set { SetValue(CloseButtonTextProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create("FontSize", typeof(float), typeof(SnackBar), default(float));
        public float FontSize
        {
            get { return (float)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(SnackBar), Color.White);
        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty CloseButtonBackGroundColorProperty = BindableProperty.Create("CloseButtonBackGroundColor", typeof(Color), typeof(SnackBar), Color.Transparent);
        public Color CloseButtonBackGroundColor
        {
            get { return (Color)GetValue(CloseButtonBackGroundColorProperty); }
            set { SetValue(CloseButtonBackGroundColorProperty, value); }
        }

        public uint AnimationDuration { get; set; }

        #region IsOpen
        public static readonly BindableProperty IsOpenProperty = BindableProperty.Create("IsOpen", typeof(bool), typeof(SnackBar), false, propertyChanged: IsOpenChanged);
        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        private static void IsOpenChanged(BindableObject bindable, object oldValue, object newValue)
        {
            bool isOpen;

            if (bindable != null && newValue != null)
            {
                var control = (SnackBar)bindable;
                isOpen = (bool)newValue;

                if (control.IsOpen == false)
                {
                    control.Close();
                }
                else
                {
                    control.Open(control.Message);
                }
            }
        }

        #endregion

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create("FontFamily", typeof(string), typeof(SnackBar), default(string));
        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public SnackBar ()
		{
            IsVisible = false;
            AnimationDuration = 150;
			InitializeComponent ();
		}

        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            Close();
        }

        public async void Close()
        {
            await this.TranslateTo(0, 50, AnimationDuration);
            Message = string.Empty;
            IsOpen = IsVisible = false;
        }

        public async void Open(string message)
        {
            IsVisible = true;
            Message = message;
            await this.TranslateTo(0, 0, AnimationDuration);
        }
    }
}