using System;

using UIKit;
using MapKit;
using CoreLocation;
using alerterocade;
using alerterocade.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MapView), typeof(MapRenderer))]
namespace alerterocade.iOS
{
    public partial class MapRenderer : ViewRenderer<MapView, UIMapView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<MapView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                SetNativeControl(new UIMapView(e));
            }
        }
    }
}