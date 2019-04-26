using Sample.Services;
using Sample.UWP.Services;
using System;
using Windows.System;
using Xamarin.Forms;

[assembly: Dependency(typeof(OpenUriService))]
namespace Sample.UWP.Services
{
    class OpenUriService : IOpenUriService
    {
        public void OpenUri(string strUri)
        {
            Uri uri = new Uri(strUri);
            var wb = Launcher.LaunchUriAsync(uri);
        }
    }
}
