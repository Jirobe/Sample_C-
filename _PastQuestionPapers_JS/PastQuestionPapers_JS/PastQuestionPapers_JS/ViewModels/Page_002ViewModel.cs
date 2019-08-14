using System.Windows.Input;
using Xamarin.Forms;

namespace PastQuestionPapers_JavaScript.ViewModels
{
    class Page_002ViewModel : BaseViewModel
    {

        private string question;
        private string text;
        private string timer;
        private string answer;
        private string execute;
        private HtmlWebViewSource result;
        private bool isVisibleResult;

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
        
        public string Timer
        {
            get { return timer; }
            set { SetProperty(ref timer, value); }
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
        public bool IsVisibleResult
        {
            get { return isVisibleResult; }
            set { SetProperty(ref isVisibleResult, value); }
        }




        public ICommand ExecuteCommand => new Command(() =>
        {
            IsVisibleResult = true;

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

            s = s.Replace("①",
$@"
result1.innerHTML = 'fizzBuzz(3) = ' + fizzBuzz(3);   
result2.innerHTML = 'fizzBuzz(25) = ' + fizzBuzz(25); 
result3.innerHTML = 'fizzBuzz(135) = ' + fizzBuzz(135); 
result4.innerHTML = 'fizzBuzz(98) = ' + fizzBuzz(98); 

result5.innerHTML = 'NG'; 

if (fizzBuzz(3) == 'Fizz') if (fizzBuzz(25) == 'Buzz') if (fizzBuzz(135) == 'FizzBuzz') if (fizzBuzz(98) == '98')
result5.innerHTML = 'OK'; 
"
                );
            s = s.Replace("②", Answer);
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = s;
            Result = htmlSource;
        });

        public ICommand CloseCommand => new Command(() => IsVisibleResult = false);

        public Page_002ViewModel()
        {
            Execute = "実行";

            Text = $@"
Fizz Buzz

function fizzBuzz(number)の実装を行ってください。

・引数は整数です。
・引数が3で割り切れる場合は「Fizz」を返却してください。
・引数が5で割り切れる場合は「Buzz」を返却してください
・引数が3と5で割り切れる場合は「FizzBuzz」を返却してください。
・引数がいずれにも当てはまらない場合は引数を返却してください。
";
            Answer = $@"
function fizzBuzz(number) 
" + "{\r\n\r\n\r\n}";

            IsVisibleResult = false;

        }
    }
}
