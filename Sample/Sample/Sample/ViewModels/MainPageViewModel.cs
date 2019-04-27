using Sample.Services;
using Sample.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sample.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        private string uriText;
        private bool isBusy;

        public string URIText
        {
            get { return uriText; }
            set { SetProperty(ref uriText, value); }
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public ICommand DependencyServiceCommand => new Command(() =>
        {
            var openUriService = DependencyService.Get<IOpenUriService>();

            openUriService.OpenUri(URIText);
        });

        public ICommand BusyCommand => new Command(async () =>
        {
            //待機(グルグル)を有効
            IsBusy = true;

            //三秒待機
            await Task.Delay(3000);

            //待機(グルグル)を停止
            IsBusy = false;
        });

        public ICommand MovePage1 => new Command(() => MessagingCenter.Send(this,"MovePage1"));
    }
}
