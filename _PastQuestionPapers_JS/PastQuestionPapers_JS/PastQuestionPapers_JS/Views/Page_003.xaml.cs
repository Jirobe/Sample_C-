using PastQuestionPapers_JavaScript.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PastQuestionPapers_JavaScript.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page_003 : ContentPage
	{
		public Page_003 ()
		{
			InitializeComponent ();

            BindingContext = new Page_003ViewModel();

        }
	}
}