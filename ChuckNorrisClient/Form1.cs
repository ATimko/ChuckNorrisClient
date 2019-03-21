using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
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
                RandJokeResponse data =
                    await response.Content.ReadAsAsync<RandJokeResponse>();

                Value jokeData = data.JokeData;
                string decodedJoke = WebUtility.HtmlDecode(jokeData.JokeText);

                //Decode any special HTML Entities
                //ex. &quot; should be "
                MessageBox.Show(decodedJoke);

                //Can use this way too
                //MessageBox.Show(data.value.joke);
                //MessageBox.Show(data.value.categories.ToString());
                if(jokeData.Categories.Count > 0)
                {
                //MessageBox.Show(jokeData.categories.ToString());
                MessageBox.Show(string.Join("\n",jokeData.Categories));
                }
                //MessageBox.Show(jokeData.joke);
            }
            else
            {
                MessageBox.Show("There was an error. Try again");
            }
        }
    }
}
