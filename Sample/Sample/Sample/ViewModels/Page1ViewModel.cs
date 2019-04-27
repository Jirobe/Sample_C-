using System.Windows.Input;
using Xamarin.Forms;

namespace Sample.ViewModels
{
    class Page1ViewModel : BaseViewModel
    {
        private string messageText;

        public string MessageText
        {
            get { return messageText; }
            set { SetProperty(ref messageText, value); }
        }

        public ICommand BackCommand => new Command(() => MessagingCenter.Send(this, "Back"));

        public ICommand MessageCommand => new Command(() => MessagingCenter.Send(this, "ShowMessage", ("Message", MessageText ?? "Empty.")));
    }
}
