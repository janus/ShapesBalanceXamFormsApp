using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace ShapesBalanceXamFormsApp
{
    public partial class MainPage : ContentPage
    {
        private Point ComputeCartesianCoordinate(double angle, double radius)
        {
            // convert to radians
            double angleRad = (Math.PI / 180.0) * angle;
            double x = radius * Math.Cos(angleRad);
            double y = radius * Math.Sin(angleRad);

            return new Point(x, y);
        }

        public void render(double amount)
        {
            if(amount < 0) {
                return;
            } else {
                double[] percentages = {15.0, 15.0, 10.0, 10.0, 30.9, 10.0, 9.0};
                makePies(amount, percentages);
            }
        }

        public void makePies(double balance, IEnumerable<double> percentages)
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
            double previousArcAngle = 0;
            double angle = 0;

            Grid grid =  new Grid();
            int i = 0;

            StackLayout layout = new StackLayout();
            layout.VerticalOptions = LayoutOptions.Center;
            layout.HorizontalOptions = LayoutOptions.Center;
            layout.Orientation = StackOrientation.Vertical;
            layout.TranslationY = 150.0;

            Grid gridCurrency = new Grid();
            Label currency = new Label() {
                Text = "€",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions= LayoutOptions.CenterAndExpand,
                FontSize = 20.0,
                TextColor = Color.Black,
                TranslationY = -10
            };

            gridCurrency.Children.Add(currency);
            Grid gridAmount = new Grid();
            string balanceConverted = balance.ToString();
            Label amount = new Label() {
                Text = balanceConverted,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions= LayoutOptions.CenterAndExpand,
                FontSize = 20.0,
                TextColor = Color.Black
            };

            gridAmount.Children.Add(amount);
            StackLayout innerLayout = new StackLayout();
            innerLayout.HorizontalOptions = LayoutOptions.Center;
            innerLayout.VerticalOptions = LayoutOptions.Center;
            innerLayout.Orientation = StackOrientation.Horizontal;
            innerLayout.Spacing = 1.0;
            innerLayout.TranslationX = 0.0;
            innerLayout.Children.Add(gridCurrency);
            innerLayout.Children.Add(gridAmount);

            Grid enclosing = new Grid();
            enclosing.Children.Add(innerLayout);
            Grid gridAccountBalance = new Grid();
            Label accountBalance = new Label() {
                Text = "Account Balance",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions= LayoutOptions.CenterAndExpand,
                FontSize = 20.0,
                TextColor = Color.Red
            };

            gridAccountBalance.Children.Add(accountBalance);
            layout.Children.Add(enclosing);
            layout.Children.Add(gridAccountBalance);

            RelativeLayout relativeLayout = new RelativeLayout() {
                BackgroundColor = Color.White,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = 500,
                WidthRequest = 500
            };

            Point previousStartPoint = new Point(0,0);
            Grid paths = new Grid();

            double startOffsetX = 50;
            double startOffsetY = 50;

            foreach (var percentage in percentages)
            {
                double Arc = (percentage / 100) * 360;
                double Radius = 150;
                if (start == true) {
                    arcAngle = 0;
                    start = false;
                    startPoint = ComputeCartesianCoordinate(arcAngle, Radius);
                    previousStartPoint.X = startOffsetX + startPoint.X + Radius ;
                    previousStartPoint.Y = startOffsetY + startPoint.Y + Radius ;
                } else {
                    arcAngle = previousArcAngle;
                }

                previousArcAngle = arcAngle + Arc;
                endPoint = ComputeCartesianCoordinate(arcAngle + Arc, Radius);
                endPoint.X += Radius + startOffsetX;
                endPoint.Y += Radius + startOffsetY;

                var path = new Path();
                path.StrokeLineCap = PenLineCap.Round;
                path.Stroke = new SolidColorBrush(colors[i % colors.Count()]);
                i++;
                path.StrokeThickness = 12;

                var arcSegment = new ArcSegment();
                arcSegment.Point = endPoint;
                arcSegment.SweepDirection = SweepDirection.Clockwise;
                arcSegment.Size = new Size(Radius, Radius);
                arcSegment.RotationAngle = angle;
                arcSegment.IsLargeArc = Arc > 180;

                var segments = new PathSegmentCollection();
                segments.Add(arcSegment);
                var pathFigure = new PathFigure() {
                    StartPoint = previousStartPoint
                };

                pathFigure.Segments.Add(arcSegment);
                var figures = new PathFigureCollection();
                figures.Add(pathFigure);
                path.Data = new PathGeometry() { Figures =  figures };

                paths.Children.Add(path);

                previousStartPoint = endPoint;
            }

            relativeLayout.Children.Add(
                paths, 
                () => new Xamarin.Forms.Rectangle(50, 50, 400, 400));

            relativeLayout.Children.Add(
                layout,
                () => new Xamarin.Forms.Rectangle(150, 2, 200, 200));
            Content = relativeLayout;
        }
        public MainPage()
        {
           double amount = 2000;
           render(amount);
        }
    }
}
