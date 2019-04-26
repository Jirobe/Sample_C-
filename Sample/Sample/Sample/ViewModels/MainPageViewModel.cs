using Sample.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sample.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        private string uriText;

        public string URIText
        {
            get { return uriText; }
            set { SetProperty(ref uriText, value); }
        }

        public ICommand DependencyServiceCommand => new Command(() =>
        {
            var openUriService = DependencyService.Get<IOpenUriService>();
            
            openUriService.OpenUri(URIText);
        });
    }
}
