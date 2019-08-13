using PastQuestionPapers_JavaScript.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PastQuestionPapers_JavaScript.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page_001 : ContentPage
	{
		public Page_001 ()
		{
			InitializeComponent ();

            BindingContext = new Page_001ViewModel();

        }
	}
}