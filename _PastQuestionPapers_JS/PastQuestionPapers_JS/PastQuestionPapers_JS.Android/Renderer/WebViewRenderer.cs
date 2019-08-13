using Android.Content;
using Java.Interop;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using WebView = Xamarin.Forms.WebView;

[assembly: ExportRenderer(typeof(WebView), typeof(PastQuestionPapers_JavaScript.Droid.Renderer.WebViewRenderer))]
namespace PastQuestionPapers_JavaScript.Droid.Renderer
{
    public class WebViewRenderer : Xamarin.Forms.Platform.Android.WebViewRenderer
    {
        public WebViewRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);
            Control.AddJavascriptInterface(new JavaScriptHandler(Control), "MyCalc");
        }
    }

    class JavaScriptHandler : Java.Lang.Object
    {
        private readonly Android.Webkit.WebView webView;

        public JavaScriptHandler(Android.Webkit.WebView webView)
        {
            this.webView = webView;
        }

        [Export]
        [Android.Webkit.JavascriptInterface]
        public void heavyAdd(int num)
        {
            var result = num * 2;

            // メインスレッドから呼ばないとエラー
            this.webView.Post(() =>
            {
                this.webView.LoadUrl($"javascript:MyCalc.onResult({result});");
            });
        }
    }
}