using System;
using CoreLocation;
using MapKit;
using UIKit;
using System;

using UIKit;
using MapKit;
using CoreLocation;
using alerterocade;
using alerterocade.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace alerterocade.iOS
{
    public class UIMapView:UIView
    {
        private void NewElementOnSizeChanged(object sender, EventArgs eventArgs)
        {
            var mapview = sender as MapView;
            var w = mapview.Width;
            var h = mapview.Height;
        }

        public UIMapView(ElementChangedEventArgs<MapView> e)
        {
            MKMapView mapView1;
            MKCoordinateRegion region;
            CLLocationCoordinate2D center;
            MKCoordinateSpan span;
            WMSTileOverlay overlay1;

            span = new MKCoordinateSpan(0.2, 0.2);
            center = new CLLocationCoordinate2D(44.837789, -0.58918);
            region = new MKCoordinateRegion(center, span);

            mapView1 = new MKMapView();
            mapView1.MapType = MKMapType.Standard;
            mapView1.SetRegion(region, false);
            //mapView1.Frame = this.Bounds;

            this.AddSubview(mapView1);

            overlay1 = new WMSTileOverlay("https://data.bordeaux-metropole.fr/wms?key=QHUHHRI7HD&LAYERS=CI_TRAFI_L&FORMAT=image%2Fpng&TRANSPARENT=TRUE&SERVICE=WMS&VERSION=1.1.1&REQUEST=GetMap&STYLES=&SRS=EPSG%3A4326&WIDTH=256&HEIGHT=256");

            mapView1.OverlayRenderer = (MKMapView mapView, IMKOverlay overlay) =>
            {
                var _tileOverlay = overlay as MKTileOverlay;

                if (_tileOverlay != null)
                {
                    return new MKTileOverlayRenderer(_tileOverlay);
                }

                return new MKOverlayRenderer(overlay);
            };

            mapView1.AddOverlay(overlay1);

            e.NewElement.SizeChanged += (object sender, EventArgs ev) => {
                MapView mapview2 = sender as MapView;
                mapView1.Frame = new CoreGraphics.CGRect(0, 0, mapview2.Width, mapview2.Height);
            };
        }
    }
}
