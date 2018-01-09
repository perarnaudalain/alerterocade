using System;
using Xamarin.Forms;

namespace alerterocade
{
    public class MyButton:Button
    {
        public MyButton():base()
        {
            Margin = new Thickness(5);
            BackgroundColor = new Color(0.7, 0.7, 0.7);
            this.TextColor = Color.Black;
        }
    }
}
