using System;
using Xamarin.Forms.Platform.iOS;
using TestGradient;
using CoreAnimation;
using CoreGraphics;
using Xamarin.Forms;
using Renderers;

[assembly: ExportRenderer (typeof (GradientPage), typeof (GradientContentPageRenderer))]
namespace Renderers
{
    public class GradientContentPageRenderer : PageRenderer
    {
        protected override void OnElementChanged (VisualElementChangedEventArgs e)
        {
            base.OnElementChanged (e);

            if (e.OldElement == null) // perform initial setup
            {
                var page = e.NewElement as GradientPage;
                var gradientLayer = new CAGradientLayer ();
                gradientLayer.AffineTransform = CGAffineTransform.MakeRotation (new nfloat(45.0));
                gradientLayer.Frame = View.Bounds;
                gradientLayer.Colors = new CGColor[] { page.StartColor.ToCGColor (), page.EndColor.ToCGColor () };
                View.Layer.InsertSublayer (gradientLayer, 0);
            }
        }
    }    
}

