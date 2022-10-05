using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SolarSystemWPF
{
    internal class Planet
    {
        int radius;
        int orbitalRadius;
        double CanvasWidth;
        double CanvasHeight;
        Ellipse ellipse;
        Canvas theCanvas;
        double angle;
        double xPos;
        double yPos;


        public Planet(int planetRadius, int orbitalRadius, Brush colour ,Canvas theCanvas)
        {
            this.radius = planetRadius;
            this.orbitalRadius = orbitalRadius;
            ellipse = new Ellipse();
            ellipse.Width = this.radius * 2;
            ellipse.Height = this.radius * 2;
            this.theCanvas = theCanvas;
            this.CanvasWidth = this.theCanvas.Width;
            this.CanvasHeight = theCanvas.Height;
            this.angle = 0; //This angle is in radians

            ellipse.Fill = colour;
            SolidColorBrush StrokeColor = new SolidColorBrush(Colors.Black);
            ellipse.Stroke = StrokeColor;
            theCanvas.Children.Add(ellipse);

        }

        public void DrawPlanet()
        {
            xPos = CanvasWidth / 2 - orbitalRadius * Math.Cos(angle) - radius;
            yPos = CanvasHeight / 2 - orbitalRadius * Math.Sin(angle) - radius;
            Canvas.SetLeft(ellipse, xPos);
            Canvas.SetTop(ellipse, yPos);
        }

        public void MovePlanet()
        {
            //Increment the angle
            angle += 1 / (orbitalRadius + 0.01);
            DrawPlanet();
        }
    }
}
