using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace CustomBindableProperty.ViewModels
{
    public class MyTabbedPageViewModel
    {
        public Command<Page> CurrentPageChangedCommand { get; set; }

        public MyTabbedPageViewModel()
        {
            CurrentPageChangedCommand = new Command<Page>(CurrentPageChangedEvent);
        }

        private void CurrentPageChangedEvent(Page page)
        {
            Debug.WriteLine("Clicked on " + page.Title);

        }
    }
}
