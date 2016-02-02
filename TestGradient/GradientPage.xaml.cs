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
            StartColor = Color.Yellow;
            EndColor = Color.Green;
        }

        public Color StartColor { get; set; }

        public Color EndColor { get; set; }
    }
}

