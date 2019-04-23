using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace CustomBindableProperty.CustomViews
{
    public partial class CircularButton2View : ContentView
    {
        public static readonly BindableProperty ButtonNumberTextProperty = BindableProperty.Create("ButtonNumberText", typeof(string), typeof(CircularButtonView), default(string));
        public string ButtonNumberText
        {
            get
            {
                return (string)GetValue(ButtonNumberTextProperty);
            }
            set { SetValue(ButtonNumberTextProperty, value); }
        }

        public static readonly BindableProperty ButtonSubTextProperty = BindableProperty.Create("ButtonSubText", typeof(string), typeof(CircularButtonView), default(string));
        public string ButtonSubText
        {
            get
            {
                return (string)GetValue(ButtonSubTextProperty);
            }
            set { SetValue(ButtonSubTextProperty, value); }
        }


        public static readonly BindableProperty ButtonRadiusProperty = BindableProperty.Create("ButtonRadius", typeof(int), typeof(CircularButtonView), default(int));
        public int ButtonRadius
        {
            get
            {
                int x = (int)GetValue(ButtonRadiusProperty);
                if (x > 0)
                {
                    InnerButton.WidthRequest = InnerButton.HeightRequest = x * 2;
                }
                return x;

            }
            set
            {

                SetValue(ButtonRadiusProperty, value);
            }
        }

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(CircularButtonView), null);

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(CircularButtonView), null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }


        public CircularButton2View()
        {
            InitializeComponent();

            InnerButton.SetBinding(Button.CornerRadiusProperty, new Binding("ButtonRadius", source: this));
            InnerButton.SetBinding(Button.CommandProperty, new Binding("Command", source: this));
            InnerButton.SetBinding(Button.CommandParameterProperty, new Binding("CommandParameter", source: this));

            InnerLabel1.SetBinding(Label.TextProperty, new Binding("ButtonNumberText", source: this));
            InnerLabel2.SetBinding(Label.TextProperty, new Binding("ButtonSubText", source: this));

        }
    }
}
