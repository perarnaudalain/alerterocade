using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace alerterocade
{
    public partial class Carte : ContentPage
    {
        void OpendataMapClicked(object sender, System.EventArgs e)
        {
        }

        void GoogleDataClicked(object sender, System.EventArgs e)
        {
        }

        /*private string urlString;
        private bool timer;
        private int count;
        private double width = 0;
        private double height = 0;
        private static readonly int TIMER = 10;*/

        public Carte()
        {
            InitializeComponent();

            /*Device.BeginInvokeOnMainThread(() =>
            {
                Count.Text = "Prochain rafraichissement dans " + TIMER + "s";
            });*/

        }

        /*protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (this.width != width || this.height != height)
            {
                this.width = width;
                this.height = height;

                OpenView();
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            OpenView();

            count = TIMER;
            timer = true;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Count.Text = "Prochain rafraichissement dans " + count.ToString() + "s";
                });
                --count;
                if (count < 0)
                {
                    count = TIMER;
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        WebView.Source = urlString;
                    });
                }
                return timer;
            });
        }

        private void OpenView()
        {
            double min;
            double top = 0;
            double left = 0;
            if(Map.Height < Map.Width) 
            {
                min = Map.Height;
                top = 0;
                left = (Map.Width - Map.Height) / 2;
            }
            else
            {
                min = Map.Width;
                top = (Map.Height - Map.Width) / 2;
                left = 0;
            }
            AbsoluteLayout.SetLayoutBounds(WebView, new Rectangle(left, top, min, min));

            urlString = "https://data.bordeaux-metropole.fr/wms?key=80ET4KGJHL&LAYERS=CI_TRAFI_L&FORMAT=image%2Fpng&TRANSPARENT=TRUE&SERVICE=WMS&VERSION=1.1.1&REQUEST=GetMap&STYLES=&SRS=EPSG%3A3945&BBOX=1404441.9133759,4175312.9133759,1425834.0866241,4195705.0866241&WIDTH=" + min + "&HEIGHT=" + min;

            Device.BeginInvokeOnMainThread(() =>
            {
                WebView.Source = urlString;
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            timer = false;
            count = TIMER;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            count = TIMER;

            Device.BeginInvokeOnMainThread(() =>
            {
                WebView.Source = urlString;
            });
        }*/
    }
}
