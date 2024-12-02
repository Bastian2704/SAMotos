using Newtonsoft.Json;
using SAMotosMaui.Models;

namespace SAMotosMaui
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7140/api/");

            var response = client.GetAsync("saMoto").Result;

            if (response.IsSuccessStatusCode == true)
            {
                var moto = response.Content.ReadAsStringAsync().Result;
                var motoList = JsonConvert.DeserializeObject<List<SAMoto>>(moto);
                ListView1.ItemsSource = motoList;
            }
        }
    }

}
