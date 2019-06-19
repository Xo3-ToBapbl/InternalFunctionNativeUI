using System;
using System.Drawing;
using CoreGraphics;
using Foundation;
using InternalFunctionsNativeUI.iOS.Extensions;
using InternalFunctionsNativeUI.iOS.Utilities;
using UIKit;

namespace InternalFunctionsNativeUI.iOS.Views
{
    [Register("CircleView")]
    public class CircleView : UIView
    {
        public CircleView()
        {
            Initialize();
        }

        public CircleView(RectangleF bounds) : base(bounds)
        {
            Initialize();
        }


        private void Initialize()
        {
            BackgroundColor = UIColor.Clear;
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            using (var graphicContext = UIGraphics.GetCurrentContext())
            {
                UIColor.Clear.FromHex(Colors.LightGreen).SetFill();

                var path = new CGPath();
                path.AddArc(Bounds.GetMidX(), Bounds.GetMidY(), 60f, 0, 2.0f*(float)Math.PI, true);

                graphicContext.AddPath(path);
                graphicContext.DrawPath(CGPathDrawingMode.Fill);
            }
        }
    }
}