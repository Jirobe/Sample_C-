using PastQuestionPapers_JavaScript.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PastQuestionPapers_JavaScript.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page_002 : ContentPage
	{
		public Page_002()
		{
			InitializeComponent ();

            BindingContext = new Page_002ViewModel();

        }
	}
}