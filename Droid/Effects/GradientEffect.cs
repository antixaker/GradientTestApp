using System;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using TestGradient.Droid.Effects;
using TestGradient.Views;

[assembly: ResolutionGroupName("TestEffect")]
[assembly: ExportEffect(typeof(GradientEffect), "GradientEffect")]
namespace TestGradient.Droid.Effects
{
    public class GradientEffect : PlatformEffect
    {
        GradientView currentElement;

        protected override void OnAttached()
        {
            currentElement = Element as GradientView;
            if (currentElement != null)
            {
                currentElement.SizeChanged += OnElementSizeChanged;
            }
            else
            {
                throw new NotSupportedException("Element doesn't support this type of effect");
            }
        }

        void OnElementSizeChanged(object sender, EventArgs e)
        {
            var elem = sender as View;
            if (elem == null)
                return;
            using (var imageBitmap = Bitmap.CreateBitmap((int)elem.Width, (int)elem.Height, Bitmap.Config.Argb8888))
            using (var canvas = new Canvas(imageBitmap))
            using (var gradient = new RadialGradient(0, 250, 1000, currentElement.StartColor.ToAndroid(), currentElement.EndColor.ToAndroid(), Shader.TileMode.Clamp))
            using (var paint = new Paint() { Dither = true })
            {
                paint.SetShader(gradient);
                canvas.DrawPaint(paint);

                Container.Background = new BitmapDrawable(imageBitmap);
            }
        }

        protected override void OnDetached()
        {
            currentElement.SizeChanged -= OnElementSizeChanged;
        }
    }
}

