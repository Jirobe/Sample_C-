using Sample.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sample.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        //ADD Start
        private string uRIText;

        public string URIText
        {
            get { return uRIText; }
            set { SetProperty(ref uRIText, value); }
        }
        //ADD End

        //MOD Start
        //public ICommand DeviceOpenUriCommand => new Command(() => Device.OpenUri(new Uri(@"https://www.google.com/")));

        //public ICommand DependencyServiceCommand => new Command(() =>
        //{
        //    var openUriService = DependencyService.Get<IOpenUriService>();
        //    openUriService.OpenUri(@"https://www.google.com/");
        //});

        public ICommand DeviceOpenUriCommand => new Command(() => Device.OpenUri(new Uri(URIText)));

        public ICommand DependencyServiceCommand => new Command(() =>
        {
            var openUriService = DependencyService.Get<IOpenUriService>();
            
            openUriService.OpenUri(URIText);
        });
        //MOD End
    }
}
