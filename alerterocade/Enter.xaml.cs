using System;
using System.Collections.Generic;

using Xamarin.Forms;
using static alerterocade.DelegateMethod;

namespace alerterocade
{
    public partial class Enter : ContentPage
    {
        public Enter()
        {
            InitializeComponent();

            Grid.HandleClick(DelegateMethod);
        }

        /// <summary>
        /// Delegates the method.
        /// </summary>
        /// <param name="message">Message.</param>
        public void DelegateMethod(string value)
        {
            //DisplayAlert("result", value, "OK");

            var test = ((AlerteRocadePage)Application.Current.MainPage).CurrentPage;
            NavigationPage np = (NavigationPage)test;
            np.PushAsync(new Exit(value));
        }
    }
}
