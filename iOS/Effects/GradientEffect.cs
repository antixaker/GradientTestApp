using System;
using Xamarin.Forms.Platform.iOS;
using CoreAnimation;
using CoreGraphics;
using Xamarin.Forms;
using TestGradient.iOS.Effects;

[assembly: ResolutionGroupName("TestEffect")]
[assembly: ExportEffect(typeof(GradientEffectIOS), "GradientEffect")]
namespace TestGradient.iOS.Effects
{
    public class GradientEffectIOS : PlatformEffect
    {
        Xamarin.Forms.Color StartColor { get; set; } = Xamarin.Forms.Color.Yellow;

        Xamarin.Forms.Color EndColor { get; set; } = Xamarin.Forms.Color.Green;

        protected override void OnAttached()
        {
            var gradientLayer = new CAGradientLayer();
            //                gradientLayer.AffineTransform = CGAffineTransform.MakeRotation (new nfloat(45.0));
            gradientLayer.Frame = Container.Bounds;
            gradientLayer.Colors = new CGColor[] { StartColor.ToCGColor(), EndColor.ToCGColor() };
            Container.Layer.InsertSublayer(gradientLayer, 0);

        }

        protected override void OnDetached()
        {
            throw new NotImplementedException();
        }
    }
}

