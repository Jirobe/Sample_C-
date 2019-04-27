using Sample.ViewModels;
using Xamarin.Forms;

namespace Sample.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //ここでViewはViewModelを参照します
            BindingContext = new MainPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //イベントのセット
            MessagingCenter.Subscribe<MainPageViewModel>(this, "MovePage1",
                async (_) =>
                {
                    await Navigation.PushModalAsync(new Page1(), true);
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            //イベントの破棄
            MessagingCenter.Unsubscribe<MainPageViewModel>(this, "MovePage1");
        }
    }
}
