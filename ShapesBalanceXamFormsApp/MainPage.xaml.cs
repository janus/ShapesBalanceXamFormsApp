using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace ShapesBalanceXamFormsApp
{
    public partial class MainPage : ContentPage
    {
        private Point ComputeCartesianCoordinate(double angle, double radius)
        {
            // convert to radians
            double angleRad = (Math.PI / 180.0) * (angle - 90);

            double x = radius * Math.Cos(angleRad);
            double y = radius * Math.Sin(angleRad);

            return new Point(x, y);
        }

        public void render(double amount)
        {

            if(amount < 0)
                return;
            else if(amount < 1000 && amount > 0)
            {
                double[] percentages = {10.0, 10.0, 5.0, 5.0};
                makePies(percentages);
            }
            else if (amount > 1000 )
            {
                double[] percentages = {15.0, 15.0, 10.0, 10.0};
                makePies(percentages);
            }

        }

        public void makePies(IEnumerable<double> percentages)
        {

            if (percentages.Sum() > 100) {
                throw new ArgumentException("Sum of percentages should not be more than 100");
            }

            if (percentages.Sum() < 99) {
                throw new ArgumentException("Sum of percentages should not be less than 99");
            }

            Color[] colors = { Color.Black, Color.Red, Color.Yellow, Color.Blue, Color.Brown, Color.Indigo, Color.Violet, Color.Orange };

            bool start = true;
            Point startPoint;
            Point endPoint;
            double angleDivision = 360 / percentages.Count();
            double arcAngle;
            double baseAngle = 5;
            double previousArcAngle = 0;
            double angle = 0;
            
            bool largeArc = angle > 180.0;
            Grid grid =  new Grid();
            int i = 0;

            foreach (var percantage in percentages)
            {
                double Arc = (percantage / 100) * 360;
                double Radius = 150;
                double cX = 50;
                double cY = 50;
                double angle = 0;
                if (start == true) {
                    arcAngle = baseAngle;
                    start = false;
                } else {
                    arcAngle = previousArcAngle + angleDivision;
                }

                previousArcAngle = arcAngle;
                startPoint = ComputeCartesianCoordinate(arcAngle, Radius);
                endPoint = ComputeCartesianCoordinate(arcAngle + Arc, Radius);

                startPoint.X += Radius + cX;
                startPoint.Y += Radius + cY;
                endPoint.X += Radius + cX;
                endPoint.Y += Radius + cY;

                var path = new Path();
                path.StrokeLineCap = PenLineCap.Round;

                path.Stroke = new SolidColorBrush(colors[i % colors.Count()]);
                i++;
                path.StrokeThickness = 4;
                path.HorizontalOptions = LayoutOptions.Start;
                path.VerticalOptions = LayoutOptions.Start;

                var arcSegment = new ArcSegment();
                arcSegment.Point = endPoint;

                arcSegment.SweepDirection = SweepDirection.Clockwise;
                arcSegment.Size = new Size(Radius, Radius);
                arcSegment.RotationAngle = angle;
                arcSegment.IsLargeArc = largeArc;

                var segments = new PathSegmentCollection();
                segments.Add(arcSegment);
                var pathFigure = new PathFigure() {
                    StartPoint = startPoint,
                    Segments = segments

                };

                var figures = new PathFigureCollection();
                figures.Add(pathFigure);
                path.Data = new PathGeometry() { Figures =  figures  };
                grid.Children.Add(path);
            }
        }

        public MainPage()
        {
          InitializeComponent();
        



            //constants

            double amount = 2000;
            Currency.Text = "€";
            Amount.Text = amount.ToString();

            Currency.TextColor = Color.Black;
            Currency.FontSize = 20;
            Currency.TranslationY = -10;
            Amount.TextColor = Color.Black;

            render(amount);
            //label.Text = amount.ToString();
            

        }



        
    }
}
