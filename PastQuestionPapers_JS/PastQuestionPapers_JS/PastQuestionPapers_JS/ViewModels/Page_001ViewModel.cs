using System.Windows.Input;
using Xamarin.Forms;

namespace PastQuestionPapers_JavaScript.ViewModels
{
    class Page_001ViewModel : BaseViewModel
    {

        private string question;
        private string text;
        private string answer;
        private string execute;
        private HtmlWebViewSource result;

        public string Question
        {
            get { return question; }
            set { SetProperty(ref question, value); }
        }
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }
        public string Answer
        {
            get { return answer; }
            set { SetProperty(ref answer, value); }
        }
        public string Execute
        {
            get { return execute; }
            set { SetProperty(ref execute, value); }
        }
        public HtmlWebViewSource Result
        {
            get { return result; }
            set { SetProperty(ref result, value); }
        }

        public ICommand ExecuteCommand => new Command(() =>
        {
            //現在のコードを実行しているAssemblyを取得
            System.Reflection.Assembly myAssembly =
                System.Reflection.Assembly.GetExecutingAssembly();
            //指定されたマニフェストリソースを読み込む
            System.IO.StreamReader sr =
                new System.IO.StreamReader(
                myAssembly.GetManifestResourceStream("PastQuestionPapers_JS.Resources.Page_001.html"),
                    System.Text.Encoding.GetEncoding("utf-8"));
            //内容を読み込む
            string s = sr.ReadToEnd();
            //後始末
            sr.Close();
            
            s = s.Replace("⓴", "addAsync();");
            s = s.Replace("①", Answer);
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = s;
            Result = htmlSource;
        });

        public Page_001ViewModel()
        {
            Execute = "実行";

            Text = $@"
操作確認用
[問題]
var x=1;
var y=2;

if(3 == □)

if文が真となるように□に値を入れてください。
□にはxとyをそれぞれ１回以上含める必要があります。


[制約]
下記は予約文字となります。利用を控えてください。
EXEC_FANC

[ガイド]
↓下記に「x+y」と入力して「{Execute}」を押下してください。
最下部に「OK」と出たら正解、「NG」と出たら不正解です。
";
            

            //現在のコードを実行しているAssemblyを取得
            System.Reflection.Assembly myAssembly =
                System.Reflection.Assembly.GetExecutingAssembly();
            //指定されたマニフェストリソースを読み込む
            System.IO.StreamReader sr =
                new System.IO.StreamReader(
                myAssembly.GetManifestResourceStream("PastQuestionPapers_JS.Resources.Page_001.html"),
                    System.Text.Encoding.GetEncoding("utf-8"));
            //内容を読み込む
            string s = sr.ReadToEnd();
            //後始末
            sr.Close();

            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = s;
            Result = htmlSource;

        }
    }
}
