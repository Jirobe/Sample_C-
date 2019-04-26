using Android.Content;
using Android.Net;
using Sample.Droid.Services;
using Sample.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(OpenUriService))]
namespace Sample.Droid.Services
{
    class OpenUriService : IOpenUriService
    {
        public void OpenUri(string strUri)
        {
            Uri uri = Uri.Parse(strUri);
            Intent intent = new Intent(Intent.ActionView, uri);
            Android.App.Application.Context.StartActivity(intent);
        }
    }
}