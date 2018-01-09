using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace alerterocade
{
    public partial class Exit : ContentPage
    {
        public Exit(string value)
        {
            InitializeComponent();

            Text.Text = "Vous avez sélectionné la sortie " + value + ".\nSélectionner maintenant votre sortie de rocade par numéro ou par ville déservie.";
        }
    }
}
