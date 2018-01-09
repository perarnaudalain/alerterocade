using System;
using Foundation;
using MapKit;
using ObjCRuntime;

namespace alerterocade.iOS
{
    public class WMSTileOverlay : MKTileOverlay
    {
        string urlString;

        public WMSTileOverlay(string url):base(url)
        {
            urlString = url;
        }

        public double xOfColumn(nint column, nint zoom)
        {
            double x = (double)column;
            double z = (double)zoom;
            return x / Math.Pow(2.0, z) * 360.0 - 180;
        }

        public double yOfRow(nint row, nint zoom)
        {
            double y = (double)row;
            double z = (double)zoom;
            double n = Math.PI - 2.0 * Math.PI * y / Math.Pow(2.0, z);
            return 180.0 / Math.PI * Math.Atan((0.5 * (Math.Exp(n) - Math.Exp(-n))));
        }

        public NSUrl urlForTilePath(MKTileOverlayPath path) {
            double left = xOfColumn(path.X, path.Z);
            double right = xOfColumn(path.X + 1, path.Z);
            double bottom = yOfRow(path.Y + 1, path.Z);
            double top = yOfRow(path.Y, path.Z);

            string resolvedUrl = urlString + "&BBOX="+left+","+bottom+","+right+","+top;
            return new NSUrl(resolvedUrl);
        }

        public override void LoadTileAtPath(MKTileOverlayPath path, MKTileOverlayLoadTileCompletionHandler result) {
            NSUrl url = urlForTilePath(path);
            NSMutableUrlRequest request = new NSMutableUrlRequest(url);
            request.HttpMethod = "GET";
            NSUrlSession.SharedSession.CreateDataTask(request, (data, response, error) => {
                result(data, null);
            }).Resume();
        }
    }
}
