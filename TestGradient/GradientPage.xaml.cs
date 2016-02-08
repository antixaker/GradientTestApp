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

//            leibe.Effects.Add(Effect.Resolve("TestEffect.GradientEffect"));
//            buton.Effects.Add(Effect.Resolve("TestEffect.GradientEffect"));
            viewForEffect.Effects.Add(Effect.Resolve("TestEffect.GradientEffect"));
        }

    }
}

