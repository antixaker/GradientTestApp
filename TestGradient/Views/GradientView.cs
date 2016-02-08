using System;
using Xamarin.Forms;

namespace TestGradient.Views
{
    public class GradientView : View
    {
        public GradientView()
        {
        }

        public GradientView(Color first, Color second)
        {
            StartColor = first;
            EndColor = second;
        }

        public Color StartColor { get; set; }

        public Color EndColor { get; set; }

    }
}

