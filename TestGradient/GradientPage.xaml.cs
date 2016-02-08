using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TestGradient
{
    public partial class GradientPage : ContentPage
    {
        public GradientPage()
        {
            InitializeComponent();

            viewForEffect.Effects.Add(Effect.Resolve("TestEffect.GradientEffect"));
        }

    }
}

