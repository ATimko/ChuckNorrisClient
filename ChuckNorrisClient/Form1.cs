using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuckNorrisClient
{
    public partial class Form1 : Form
    {
        static HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();

            //Initialize client settings
            //MAKE SURE, YOUR URL ENDS WITH A FORWARD SLASH
            client.BaseAddress =
                new Uri("http://api.icndb.com/");
            client.DefaultRequestHeaders.Accept.Clear();

            //Tell service we want JSON data
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            //Tell service which browser (user-agent) we are using
            //SOME WEB SERVICES REQUIRE USER-AGENT TO BE SET
            client.DefaultRequestHeaders.Add("User-Agent", "Joe's App");
        }

        private async void btnGetRandomJoke_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response =
                await client.GetAsync("jokes/random");
            //Check if web service returns HTTP 200 - OK
            if(response.IsSuccessStatusCode)
            {
                string data =
                    await response.Content.ReadAsStringAsync();
                MessageBox.Show(data);
            }
            else
            {
                MessageBox.Show("There was an error. Try again");
            }
        }
    }
}
