using System;
using System.Drawing;

using CoreGraphics;
using Foundation;
using InternalFunctionsNativeUI.iOS.Extensions;
using InternalFunctionsNativeUI.iOS.Utilities;
using UIKit;

namespace InternalFunctionsNativeUI.iOS.Views.PartialViews
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

        void Initialize()
        {
            BackgroundColor = UIColor.Green;
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            using (var graphicContext = UIGraphics.GetCurrentContext())
            {
                //UIColor.Clear.FromHex(Constants.Colors.LightAzure).SetFill();
                UIColor.Red.SetFill();

                var path = new CGPath();
                path.AddArc(Bounds.GetMidX(), Bounds.GetMidY(), 50f, 0, 2.0f*(float)Math.PI, true);

                graphicContext.AddPath(path);
                graphicContext.DrawPath(CGPathDrawingMode.FillStroke);
            }
        }
    }
}