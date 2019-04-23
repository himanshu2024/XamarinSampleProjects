using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace CustomBindableProperty.CustomViews
{
    public partial class ImageButtonView     : ContentView
    {
        public static readonly BindableProperty ButtonTextProperty = BindableProperty.Create("ButtonText", typeof(string), typeof(ImageButtonView), default(string));

        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }

        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create("Source", typeof(ImageSource), typeof(ImageButtonView), default(ImageSource));

        public ImageSource Source
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(ImageButtonView), null);

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public event EventHandler Clicked;
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(ImageButtonView), null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public ImageButtonView()
        {
            InitializeComponent();

            InnerLabel.SetBinding(Label.TextProperty, new Binding("ButtonText", source: this));
            InnerImage.SetBinding(Image.SourceProperty, new Binding("Source", source: this));

            this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Clicked?.Invoke(this, EventArgs.Empty);
                    if (Command != null)
                    {
                        if (Command.CanExecute(CommandParameter))
                            Command.Execute(CommandParameter);
                    }
                })
            });


        }
    }
}
