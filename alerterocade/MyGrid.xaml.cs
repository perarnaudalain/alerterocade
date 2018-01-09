using System;
using System.Collections.Generic;
using Xamarin.Forms;
using static alerterocade.DelegateMethod;
using static alerterocade.Enter;
using System.Diagnostics;

namespace alerterocade
{
    public partial class MyGrid : ContentView
    {
        void HandleTownClicked(object sender, System.EventArgs e)
        {
            TownScrollView.IsVisible = false;
            Number.IsVisible = true;
        }

        void HandleNumberClicked(object sender, System.EventArgs e)
        {
            TownScrollView.IsVisible = true;
            Number.IsVisible = false;
        }

        Del method;

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            method(((MyButton)sender).Text);
        }

        Dictionary<int, List<String>> dict;

        public MyGrid()
        {
            InitializeComponent();
        
            TownScrollView.IsVisible = false;
            Number.IsVisible = true;


            dict = new Dictionary<int, List<String>>();
            List<String> list1 = new List<String>();
            list1.Add("A10");
            list1.Add("Angoulème");
            list1.Add("La Rochelle");
            list1.Add("Paris");
            dict.Add(1, list1);

            List<String> list2 = new List<String>();
            list2.Add("Bordeaux-Bastide");
            list2.Add("Bassens");
            list2.Add("Carbon-Blanc");
            list2.Add("Lormont");
            list2.Add("Port et ZI d'Ambes");
            dict.Add(2, list2);

            List<String> list3 = new List<String>();
            list3.Add("Pont d'Aquitaine");
            list3.Add("Vieux Lormont");
            dict.Add(3, list3);

            List<String> list4 = new List<String>();
            list4.Add("Bordeaux-Centre");
            list4.Add("Bordeaux-Lac");
            list4.Add("Centre hôtelier du lac");
            list4.Add("Centre routier");
            list4.Add("Parc des expositions");
            dict.Add(4, list4);

            List<String> list5 = new List<String>();
            list5.Add("Bordeaux-Fret");
            list5.Add("ZI Bruges");
            dict.Add(5, list5);

            List<String> list6 = new List<String>();
            list6.Add("Blanquefort");
            list6.Add("Bruges");
            list6.Add("ZI Campillleau");
            dict.Add(6, list6);

            List<String> list7 = new List<String>();
            list7.Add("Esynes-Le Vigean");
            list7.Add("Le Bouscat");
            list7.Add("Le Taillan-Médoc");
            dict.Add(7, list7);

            List<String> list8 = new List<String>();
            list8.Add("Esynes-Centre");
            list8.Add("Lacanau");
            list8.Add("Le Taillan-Médoc");
            list8.Add("Le Verdon");
            list8.Add("Saint-Médard-en-Jalles");
            dict.Add(8, list8);

            List<String> list9 = new List<String>();
            list9.Add("Bordeaux-Caudéran");
            list9.Add("Le Haillan");
            list9.Add("Mérignac-Capeyron");
            list9.Add("Saint-Médard-en-Jalles");
            dict.Add(9, list9);

            List<String> list10 = new List<String>();
            list10.Add("Bordeaux-Caudéran");
            list10.Add("Le Haillan");
            list10.Add("Mérignac-Capeyron");
            list10.Add("Saint-Médard-en-Jalles");
            dict.Add(10, list10);

            search(null);

            SearchBar.TextChanged += (sender, args) => {
                Town.Children.Clear();

                foreach(View view in Town.Children) {
                    Town.Children.Remove(view);
                }
            };
        }

        public void search(string searchtext) {
            foreach (var item in dict)
            {
                if (item.Value.Count > 0)
                {
                    StackLayout sl = new StackLayout();
                    sl.BackgroundColor = new Color(0.7, 0.7, 0.7);
                    Label title = new Label();
                    title.Text = "Sortie " + item.Key;
                    sl.Children.Add(title);
                    title.Margin = new Thickness(5);
                    Town.Children.Add(sl);
                    title.FontAttributes = FontAttributes.Bold;

                    TapGestureRecognizer tgrtitle = new TapGestureRecognizer();
                    tgrtitle.Tapped += (s, e) =>
                    {
                        method("" + item.Key);
                    };
                    sl.GestureRecognizers.Add(tgrtitle);

                    foreach (String sublst in item.Value)
                    {
                        Label label = new Label();
                        label.Text = sublst;
                        Town.Children.Add(label);

                        TapGestureRecognizer tgr = new TapGestureRecognizer();
                        tgr.Tapped += (s, e) =>
                        {
                            method("" + item.Key);
                        };
                        label.GestureRecognizers.Add(tgr);
                    }
                }
            }
        }

        public void HandleClick(Del method) {
            this.method = method;
        }
    }
}
