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

        public RelativeLayout makePies(IEnumerable<double> percentages)
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

            StackLayout layout = new StackLayout();
            layout.VerticalOptions = LayoutOptions.Center;
            layout.HorizontalOptions = LayoutOptions.Center;
            layout.Orientation = StackOrientation.Vertical;
            layout.Spacing = 1.0;
            layout.TranslationY = 170.0;

            Grid gridCurrency = new Grid();
            Label currency = new Label() {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions= LayoutOptions.CenterAndExpand,
                FontSize = 40.0,
                TextColor = Color.Red
            };

            gridCurrency.Children.Add(currency);
            Grid gridAmount = new Grid();
            Label amount = new Label() {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions= LayoutOptions.CenterAndExpand,
                FontSize = 40.0,
                TextColor = Color.Red
            };

            gridAmount.Children.Add(amount);
            StackLayout innerLayout = new StackLayout();
            innerLayout.HorizontalOptions = LayoutOptions.Center;
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
                HeightRequest = 500.0,
                WidthRequest = 500.0,
                BackgroundColor = Color.White,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            foreach (var percantage in percentages)
            {
                double Arc = (percantage / 100) * 360;
                double Radius = 150;
                double cX = 50;
                double cY = 50;
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
                relativeLayout.Children.Add(
                    path,
                    Constraint.Constant(0),
                    Constraint.Constant(0));
            }

            relativeLayout.Children.Add(
                layout,
                Constraint.Constant(0),
                Constraint.Constant(0));

            return relativeLayout;
        }

        public MainPage()
        {
            InitializeComponent();
            

        }



        
    }
}
