
using Sample.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {

        public Page1()
        {
            InitializeComponent();

            //ここでViewはViewModelを参照します
            BindingContext = new Page1ViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //イベントのセット
            MessagingCenter.Subscribe<Page1ViewModel>(this, "Back",
                async (_) =>
                {
                    //自分を破棄して前ページに戻る
                    //画面は紙芝居であり、手前のPage1を破棄してMainPageを表に出す
                    await Navigation.PopModalAsync();
                });

            //タプルにして複数の個の値を渡す
            MessagingCenter.Subscribe<Page1ViewModel, (string, string)>(this, "ShowMessage",
                (_, t) =>
                {
                    //メッセージダイアログ
                    DisplayAlert(t.Item1, t.Item2, "OK");
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            //イベントの破棄
            MessagingCenter.Unsubscribe<Page1ViewModel>(this, "Back");
            MessagingCenter.Unsubscribe<Page1ViewModel, (string, string)>(this, "ShowMessage");
        }
    }
}