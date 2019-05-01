using System;
using CustomBindableProperty.iOS.Renderer;
using CustomBindableProperty.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyTabbedPage), typeof(TabbedPageCustomRenderer))]
namespace CustomBindableProperty.iOS.Renderer
{
    public class TabbedPageCustomRenderer : TabbedRenderer
    {

        public override void ViewWillAppear(bool animated)
        {

            if (TabBar?.Items == null)
                return;

            var tabs = Element as TabbedPage;

            TabBar.SelectedImageTintColor = Color.FromHex("#009933").ToUIColor(); //UIColor.Red;

            base.ViewWillAppear(animated);
        }
    }
}
