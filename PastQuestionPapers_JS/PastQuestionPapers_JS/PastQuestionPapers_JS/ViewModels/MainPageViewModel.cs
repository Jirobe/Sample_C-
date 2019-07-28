using System.Collections.ObjectModel;

namespace PastQuestionPapers_JavaScript.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        private string list1_Title;
        private ObservableCollection<MainPageItem> items;

        public ObservableCollection<MainPageItem> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }
        public string List1_Title
        {
            get { return list1_Title; }
            set { SetProperty(ref list1_Title, value); }
        }

        public MainPageViewModel()
        {
            List1_Title = "問題";
            Items = new ObservableCollection<MainPageItem>()
            {
                new MainPageItem(){ Number="操作確認用", Title="" , NextPageMessage="Page_001"},
                 new MainPageItem(){ Number="問1", Title="" , NextPageMessage="Page_002"},
            };
        }
    }
}
