using System;
using Xamarin.Forms.Platform.iOS;
using CoreAnimation;
using CoreGraphics;
using Xamarin.Forms;
using TestGradient.Views;
using TestGradient.iOS.Effects;
using UIKit;

[assembly: ResolutionGroupName("TestEffect")]
[assembly: ExportEffect(typeof(GradientEffect), "GradientEffect")]
namespace TestGradient.iOS.Effects
{
    public class GradientEffect : PlatformEffect
    {
        GradientView currentView;

        protected override void OnAttached()
        {
            currentView = this.Element as GradientView;
            if (currentView != null)
            {
                currentView.SizeChanged += Renderer_Element_SizeChanged;
            }
            else
            {
                throw new NotSupportedException("Element doesn't support this type of effect. You must inherit element from GradientView.");
            }

        }

        void Renderer_Element_SizeChanged(object sender, EventArgs e)
        {
            var element = sender as GradientView;
            if (element == null)
                return;
            
            var bounds = element.Bounds;
            var rect = new CGRect(bounds.X, bounds.Y, bounds.Width, bounds.Height);

            UIGraphics.BeginImageContext(rect.Size);
            using (CGContext g = UIGraphics.GetCurrentContext())
            {
                using (var rgb = CGColorSpace.CreateDeviceRGB())
                {
                    nfloat[] colors = GetFloatArrayFromColors(element.StartColor, element.EndColor);

                    var gradient = new CGGradient(rgb, colors, null);

                    g.DrawRadialGradient(gradient, new CGPoint(0, 0), new nfloat(0), new CGPoint(100, 100), new nfloat(1000), CGGradientDrawingOptions.None);
                }


                using (var im = UIGraphics.GetImageFromCurrentImageContext())
                using (var imageHolder = new UIImageView(im))
                    Container.AddSubview(imageHolder);
                UIGraphics.EndImageContext();
            }

        }

        protected override void OnDetached()
        {
            currentView.SizeChanged -= Renderer_Element_SizeChanged;
        }

        nfloat[] GetFloatArrayFromColors(Color startColor, Color endColor)
        {
            var array = new nfloat[8];

            array[0] = new nfloat(startColor.R);            
            array[1] = new nfloat(startColor.G);
            array[2] = new nfloat(startColor.B);
            array[3] = new nfloat(startColor.A);

            array[4] = new nfloat(endColor.R);            
            array[5] = new nfloat(endColor.G);
            array[6] = new nfloat(endColor.B);
            array[7] = new nfloat(endColor.A);

            return array;
        }
    }
}

