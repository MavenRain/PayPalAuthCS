using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Data.Json;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PayPalAuthCS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var startUri = new Uri("https://api.sandbox.paypal.com/v1/oauth2/token");
            var httpClient = new HttpClient();
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, startUri);
            var iDictionary = new Dictionary<string, string>();
            iDictionary.Add("grant_type", "client_credentials");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes("AYSkoxC6MolMcRAlHJF6xWTvIWj4A6XcyAdhBSxsL8CJ1-wTo8L3L69V5A6c:ELxcaRDSmbrGcSSAGSZMiCMM4nRoufAwiXiFcfdGeuIQoziPwuMIm8d4LFC-")));
            httpRequest.Content = new FormUrlEncodedContent(iDictionary);
            var httpResponseObject = JsonObject.Parse(await ((await httpClient.SendAsync(httpRequest)).Content.ReadAsStringAsync()));
            Output.Text = httpResponseObject.GetNamedString("access_token", "");
        }
    }
}
