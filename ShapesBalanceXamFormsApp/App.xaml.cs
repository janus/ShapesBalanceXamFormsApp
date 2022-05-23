using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Shapes;

namespace ShapesBalanceXamFormsApp
{
    public partial class App : Application
    {
     /**   public StackLayout ReflectedColorPage()
        {
            StackLayout stackLayout = new StackLayout();

            foreach(Fieldinfo info in typeof(Color).GetRuntimeFields())
            {
                if (info.GetCustomAttributes<ObsoleteAttribute>() != null)
                    continue;

                if (info.IsPublic && info.IsStatic && info.FieldType = typeof(Color))
                {
                    stackLayout.Children.Add(CreateColorLabel((Color)info.GetValue(null), info.Name));
                }
            }

            foreach(PropertyInfo info in typeof(Color).GetRuntimeProperties())
            {
                MethodInfo methodInfo = info.GetMethod;

                if(methodInfo.IsPublic && methodInfo.IsStatic && methodInfo.ReturnType == typeof(Color))
                {
                    stackLayout.Children.Add(CreateColorLabel((Color)info.GetValue(null), info.Name));
                }
            }

            return stackLayout;
        }
*/

        private Point ComputeCartesianCoordinate(double angle, double radius)
        {
            // convert to radians
            double angleRad = (Math.PI / 180.0) * (angle - 90);

            double x = radius * Math.Cos(angleRad);
            double y = radius * Math.Sin(angleRad);

            return new Point(x, y);
        }

        Label CreateColorLabel(Color color, string name)
        {
            Color backgroundColor = Color.Default;

            if(color != Color.Default)
            {
                double luminance = 0.3 * color.R + 0.59 * color.G + 0.11 * color.B;
                backgroundColor = luminance > 0.5? Color.Black : Color.White;
            }

            return new Label()
            {
                Text = name,
                TextColor = color,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                BackgroundColor = backgroundColor
            };
        }

        public StackLayout Pathk() {
            //<Path Stroke="Black" StrokeThickness="1"  Data="M 10,50 H 200" />
            var  path = new Path();
            RectangleGeometry RectGeom = new RectangleGeometry { Rect = new Rect { X = 10, Y = 98 - 25, Width = 150, Height = 50 } };
            Path RectPath = new Path { Data = RectGeom, StrokeThickness = 1, HeightRequest = 400, WidthRequest = 400 };
            StackLayout stackLayout = new StackLayout();
            stackLayout.Children.Add(
                 RectPath
            );
            return stackLayout;
        }

        public RelativeLayout nPath1() {
            double Arc = (30 / 100) * 360;
            double Radius = 50;
            double cX = 50;
            double cY = 50;
            double arcAngle = 0;

            Point startPoint = ComputeCartesianCoordinate(arcAngle, Radius);
            Point endPoint = ComputeCartesianCoordinate(arcAngle + Arc, Radius);

            //startPoint.X += Radius + cX;
            //startPoint.Y += Radius + cY;
            //endPoint.X += Radius + cX;
            //endPoint.Y += Radius + cY;

            var path = new Path();
            path.StrokeLineCap = PenLineCap.Round;

            path.Stroke = new SolidColorBrush(Color.Yellow);

            path.StrokeThickness = 4;
            path.HorizontalOptions = LayoutOptions.Center;
            path.VerticalOptions = LayoutOptions.Center;

            var arcSegment = new ArcSegment();
            arcSegment.Point = endPoint;

            arcSegment.SweepDirection = SweepDirection.Clockwise;
            arcSegment.Size = new Size(Radius, Radius);
            arcSegment.RotationAngle = 0;
            arcSegment.IsLargeArc = false;

            var segments = new PathSegmentCollection();
            segments.Add(arcSegment);
            var pathFigure = new PathFigure() {
                StartPoint = startPoint,
                Segments = segments
            };

            var figures = new PathFigureCollection();
            figures.Add(pathFigure);
            path.Data = new PathGeometry() { Figures =  figures  };
            RelativeLayout LayoutRoot = new RelativeLayout
            {
                Margin = new Thickness(20)
            };

            LayoutRoot.Children.Add(
                    path,
                    () => new Xamarin.Forms.Rectangle(0, 10, 700, 600));

            return LayoutRoot;

        }
        public RelativeLayout Path1(){
            double Arc = (30 / 100) * 360;
            double Radius = 150;
            double cX = 50;
            double cY = 50;
            double arcAngle = 5;

            Point startPoint = ComputeCartesianCoordinate(arcAngle, Radius);
            Point endPoint = ComputeCartesianCoordinate(arcAngle + Arc, Radius);
            startPoint.X += cX;
            startPoint.Y += cY;
            endPoint.X += (Radius + 10 + cX);
            endPoint.Y += (Radius + 10 + cY);
            PathFigure pthFigure = new PathFigure();
            pthFigure.StartPoint =   startPoint ;//new Point(50, 50);

            ArcSegment arcSeg = new ArcSegment();
            arcSeg.Point =  endPoint;  //new Point(50, 50);
            arcSeg.Size = new Size(Radius, Radius);
            arcSeg.IsLargeArc = false;
            arcSeg.SweepDirection = SweepDirection.CounterClockwise;
            arcSeg.RotationAngle = 0;




            PathSegmentCollection myPathSegmentCollection = new PathSegmentCollection();
            myPathSegmentCollection.Add(arcSeg);

            pthFigure.Segments = myPathSegmentCollection;

            PathFigureCollection pthFigureCollection = new PathFigureCollection();

            pthFigureCollection.Add(pthFigure);

            PathGeometry pthGeometry = new PathGeometry();
            pthGeometry.Figures = pthFigureCollection;

            Path arcPath = new Path();
            arcPath.StrokeLineCap = PenLineCap.Round;
            arcPath.StrokeThickness = 12;
            arcPath.Stroke = new SolidColorBrush(Color.Black);
            arcPath.Data = pthGeometry;
            //arcPath.HorizontalOptions = LayoutOptions.Start;
            //arcPath.Fill = new SolidColorBrush(Color.Yellow);


            PathFigure pthFigure1 = new PathFigure();
            endPoint.X += 2 ;
            //endPoint.Y += 2 ;
            pthFigure1.StartPoint =   endPoint ;//new Point(50, 50);

            endPoint.X += 90;
            endPoint.Y -= 50 ;

            ArcSegment arcSeg1 = new ArcSegment();
            arcSeg1.Point =  endPoint;  //new Point(50, 50);
            arcSeg1.Size = new Size(Radius, Radius);
            arcSeg1.IsLargeArc = false;
            arcSeg1.SweepDirection = SweepDirection.CounterClockwise;
            //arcSeg1.RotationAngle = 45;




            PathSegmentCollection myPathSegmentCollection1 = new PathSegmentCollection();
            myPathSegmentCollection1.Add(arcSeg1);

            pthFigure1.Segments = myPathSegmentCollection1;

            PathFigureCollection pthFigureCollection1 = new PathFigureCollection();

            pthFigureCollection1.Add(pthFigure1);

            PathGeometry pthGeometry1 = new PathGeometry();
            pthGeometry1.Figures = pthFigureCollection1;

            Path arcPath1 = new Path();
            arcPath1.StrokeLineCap = PenLineCap.Round;
            arcPath1.StrokeThickness = 12;
            arcPath1.Stroke = new SolidColorBrush(Color.Yellow);
            arcPath1.Data = pthGeometry1;

            RelativeLayout LayoutRoot = new RelativeLayout
            {
                Margin = new Thickness(20)
            };

            LayoutRoot.Children.Add(
                    arcPath,
                    () => new Xamarin.Forms.Rectangle(200, 200, 700, 600));

            LayoutRoot.Children.Add(
                    arcPath1,
                    () => new Xamarin.Forms.Rectangle(200, 200, 700, 600));

            return LayoutRoot;
        }

        public RelativeLayout StylishHeaderDemoPageCS()
    {
        RelativeLayout relativeLayout = new RelativeLayout
        {
            Margin = new Thickness(20)
        };

        relativeLayout.Children.Add(new BoxView
        {
            Color = Color.Silver
        }, () => new Xamarin.Forms.Rectangle(0, 10, 200, 5));

        relativeLayout.Children.Add(new BoxView
        {
            Color = Color.Silver
        }, () => new Xamarin.Forms.Rectangle(0, 20, 200, 5));

        relativeLayout.Children.Add(new BoxView
        {
            Color = Color.Silver
        }, () => new Xamarin.Forms.Rectangle(10, 0, 5, 65));

        relativeLayout.Children.Add(new BoxView
        {
            Color = Color.Silver
        }, () => new Xamarin.Forms.Rectangle(20, 0, 5, 65));

        relativeLayout.Children.Add(new Label
        {
            Text = "Stylish Header",
            FontSize = 24
        }, Constraint.Constant(30), Constraint.Constant(25));
        return  relativeLayout;
    }
        public RelativeLayout PathCurve()
        {

            double Arc = (30 / 100) * 360;
            double Radius = 10;
            double cX = 50;
            double cY = 50;
            double arcAngle = 5;

            Point startPoint;
            Point endPoint;

            startPoint = ComputeCartesianCoordinate(arcAngle, Radius);
            endPoint = ComputeCartesianCoordinate(arcAngle + Arc, Radius);

            startPoint.X += Radius + cX;
            startPoint.Y += Radius + cY;
            endPoint.X += Radius + cX;
            endPoint.Y += Radius + cY;

            var path = new Path();
            path.StrokeLineCap = PenLineCap.Round;
            path.BackgroundColor = Color.Red;
            path.Stroke = new SolidColorBrush(Color.Black);
            path.StrokeThickness = 1;
            path.HorizontalOptions = LayoutOptions.Center;
            path.Aspect = Stretch.Uniform;

            var arcSegment = new ArcSegment();
            arcSegment.Point = endPoint;

            arcSegment.SweepDirection = SweepDirection.Clockwise;
            arcSegment.Size = new Size(Radius, Radius);
            arcSegment.RotationAngle = 0;
            arcSegment.IsLargeArc = false;


            var segments = new PathSegmentCollection();
            segments.Add(arcSegment);
            var pathFigure = new PathFigure() {
                StartPoint = startPoint,
                Segments = segments
            };
            var pathsegmentcollection = new PathSegmentCollection();

           // pathsegmentcollection.Add(segmenta);

            //figure.Segments = pathsegmentcollection;

           // figure.Segments.Add(segmenta);
            var figures = new PathFigureCollection();
            figures.Add(pathFigure);
            path.Data = new PathGeometry() { Figures =  figures };
             RelativeLayout LayoutRoot = new RelativeLayout
            {
                Margin = new Thickness(20)
            };

            LayoutRoot.Children.Add(
                path,
                () => new Xamarin.Forms.Rectangle(0, 10, 700, 600));

            return LayoutRoot;
        }
        public Frame CreateColor(Color color, string name)
        {
            return new Frame()
            {
                BorderColor = Color.Accent,
                Padding = new Thickness(5),
                Content = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 15,
                    Children =
                    {
                        new BoxView()
                        {
                            Color = color
                        },
                        new Label()
                        {
                            Text = name,
                            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                            FontAttributes = FontAttributes.Bold,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.StartAndExpand,

                        },
                        new StackLayout()
                        {
                            Children =
                            {
                                new Label() {
                                Text = String.Format("{0:X2}-{1:X2}-{2:X2}", (int)(255 * color.R), (int)(255 * color.G), (int)(255 * color.B)),
                                VerticalOptions = LayoutOptions.CenterAndExpand,
                                IsVisible = (color != Color.Default)
                                },
                                new Label()
                                {
                                    Text = String.Format("{0:F2}, {1:F2}, {2:F2}", color.Hue, color.Saturation, color.Luminosity),
                                    VerticalOptions = LayoutOptions.CenterAndExpand,
                                    IsVisible = color != Color.Default
                                }
                            },
                            HorizontalOptions = LayoutOptions.End
                        }

                    }
                }
            };
        }
        public Frame FrameTextPage()
        {
            Frame frame = new Frame
            {
                BorderColor = Color.Black,
                BackgroundColor = Color.Yellow,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Content = new Label()
                {
                    Text = "I've been framed!",
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    FontAttributes = FontAttributes.Italic,
                    TextColor = Color.Blue
                }
            };
            return frame;
        }
  /**      public StackLayout VerticalOptionsDemoPage()
        {
            Color[] colors = { Color.Yellow, Color.Blue };
            int flipFlopper = 0;

            IEnumerable<Label> labels =
                from field in typeof(LayoutOptions).GetRuntimeFields()
                where field.IsPublic && field.IsStatic
                orderby ((LayoutOptions)field.GetValue(null)).Alignment
                select new Label
                {
                    Text = "VerticalOptions = " + field.Name,
                    VerticalOptions = (LayoutOptions)field.GetValue(null),
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    TextColor = colors[flipFlopper],
                    BackgroundColor = colors[flipFlopper = 1 - flipFlopper]
                };

            StackLayout stackLayout = new StackLayout();
            foreach(Label label in labels) {
                stackLayout.Children.Add(label);
            }
            return stackLayout;
        }
        */
        public StackLayout ColorLoopPage() {
            var colors = new[]
            {
                new { value = Color.White, name = "White"},
                new { value = Color.Silver, name = "Silver"},
                new { value = Color.Gray, name = "Gray"},
                new { value = Color.Black, name = "Black"},
                new { value = Color.Red, name = "Red"},
                new { value = Color.Maroon, name = "Maroon"},
                new { value = Color.Yellow, name = "Yellow"},
                new { value = Color.Olive, name = "Olive"},
                new { value = Color.Lime, name = "Lime"},
                new { value = Color.Green, name = "Green"},
                new { value = Color.Aqua, name = "Aqua"},
                new { value = Color.Teal, name = "Teal"},
                new { value = Color.Blue, name = "Blue"},
                new { value = Color.Navy, name = "Navy"},
                new { value = Color.Pink, name = "Pink"},
                new { value = Color.Fuchsia, name = "Fuchsia"},
                new { value = Color.Purple, name = "Purple"},
            };

            StackLayout stackLayout = new StackLayout();
            foreach (var color in colors)
            {
                stackLayout.Children.Add(
                    /**new Label
                    {
                        Text = color.name,
                        TextColor = color.value,
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                    } */
                    CreateColor(color.value, color.name)

                );
            }
           // Padding = new Thickness(5, Device.OnPlatform(20, 5, 5), 5, 5);
            //Content = stackLayout;
            return stackLayout;
        }
        public App()
        {

            MainPage = new ContentPage()
            {
                Padding = new Thickness(5),
                BackgroundColor = Color.Aqua,
                Content = Path1()
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
