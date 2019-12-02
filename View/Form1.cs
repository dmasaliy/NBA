using NBA.Infrastructure;
using NBA.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NBA
{
    public partial class Form1 : Form
    {
        NBAManager nb = new NBAManager();
        Country selectedleag = new Country();
        League selectedteams = new League();

        IEnumerable<Country> Countries { get; set; }
        IEnumerable<League> Leagues { get; set; }
        IEnumerable<Teams> Teamss { get; set; }
        IEnumerable<Fixtures> Fixturess { get; set; }




        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

            Countries = await nb.GetCountries();
            Leagues = await nb.GetLeagues();


            if (Countries.Count() > 0)
            {
                foreach (Country country in Countries)
                {
                    listBox1.Items.Add(country.Country_name);
                }
            }
            List<int> teamIds = new List<int>();

            Fixturess = await nb.GetFixtures(textBox1.Text, textBox2.Text);
            if (Fixturess.Count() > 0)
            {
                foreach (var item in Fixturess)
                {

                    if (!teamIds.Contains(item.Away_team_key))
                        teamIds.Add(item.Away_team_key);

                }

            }

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            Country country = new Country();
            country.Country_name = listBox1.SelectedItem.ToString();

            foreach (Country selectedcountry in Countries)
            {
                if (selectedcountry.Country_name == country.Country_name)
                    country.Country_key = selectedcountry.Country_key;
            }

            foreach (League league in Leagues)
            {
                if (league.Country_key == country.Country_key)
                {
                    listBox2.Items.Add(league.League_name);
                }
            }
        }



        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            var res = Task.Run(() => nb.GetFixtures(textBox1.Text, textBox2.Text));
            Fixturess = res.Result;
            League league = new League();
            league.League_name = listBox2.SelectedItem.ToString();

            foreach (League selectedleag in Leagues)
            {
                if (selectedleag.League_name == league.League_name)
                    league.League_key = selectedleag.League_key;
            }
            if (Fixturess != null)
            {
                foreach (Fixtures fixtures in Fixturess)
                {
                    if (fixtures.League_key == league.League_key)
                    {
                        if (!listBox3.Items.Contains(fixtures.Event_away_team))
                            listBox3.Items.Add(fixtures.Event_away_team);
                    }
                }
            }
        }

        private void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var TeamKey = Fixturess.FirstOrDefault(x => x.Event_away_team == listBox3.SelectedItem).Home_team_key;
            pictureBox1.Image = GetImage(TeamKey.ToString());
        }

        private Image GetImage(string TeamKey)
        {
            Teams res = Task.Run(()=> nb.GetTeams(TeamKey.ToString())).Result;
            Image image= ImageUtil.FromURL(res.Team_logo).Result;
            return image;

        }
    }
}
