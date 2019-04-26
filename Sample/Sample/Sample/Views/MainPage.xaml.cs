using Sample.ViewModels;
using Xamarin.Forms;

namespace Sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //ここでViewはViewModelを参照します
            BindingContext = new MainPageViewModel();
        }

        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    Device.OpenUri(new Uri(@"https://www.google.com/"));
        //}

        //private void Button_Clicked_1(object sender, EventArgs e)
        //{
        //    var openUriService = DependencyService.Get<IOpenUriService>();
        //    openUriService.OpenUri(@"https://www.google.com/");
        //}
    }
}
