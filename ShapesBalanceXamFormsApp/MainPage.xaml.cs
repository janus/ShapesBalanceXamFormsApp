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
                makePies(10, 10, 5, 5);
            }
            else if (amount > 1000 )
            {
                makePies(15, 15, 10, 10);
            }

        }

        public void makePies(double P0, double P1, double P2, double P3)
        {

            double A0 = (P0 / 100) * 360;
            double A1 = (P1 / 100) * 360;
            double A2 = (P2 / 100) * 360;
            double A3 = (P3 / 100) * 360;
           

            double Radius = 150;
            double cX = 50;
            double cY = 50;
            double angle = 0;
            
            bool largeArc = angle > 180.0;
            grayPath.HorizontalOptions = LayoutOptions.Center;
            grayPath.VerticalOptions = LayoutOptions.Center;
            grayPath.StrokeLineCap = PenLineCap.Round;
            grayPath.StrokeThickness = 12;
            pathRoot.StrokeLineCap = PenLineCap.Round;
            pathRoot.StrokeThickness = 12;
            pathRoot2.StrokeLineCap = PenLineCap.Round;
            pathRoot2.StrokeThickness = 12;
            pathRoot3.StrokeLineCap = PenLineCap.Round;
            pathRoot3.StrokeThickness = 12;


            //if (startPoint.X == Math.Round(endPoint.X) && startPoint.Y == Math.Round(endPoint.Y))
            //    startPoint.X -= 0.01;






            //if (startPoint.X == Math.Round(endPoint.X) && startPoint.Y == Math.Round(endPoint.Y))
            //    endPoint.X -= 0.01;


            /////////////////////////////////////////////////////////////
            ///ARC0
            /////////////////////////////////////////////////////////////

            double arcAngle = 5;
            Point startPoint = ComputeCartesianCoordinate(arcAngle, Radius);
            Point endPoint = ComputeCartesianCoordinate(arcAngle + A0, Radius);

            startPoint.X += Radius + cX;
            startPoint.Y += Radius + cY;
            endPoint.X += Radius + cX;
            endPoint.Y += Radius + cY;
            grayPathFigure.StartPoint = startPoint;//new Point(50, 200);
            grayArcSegment.Point = endPoint;//new Point(100, 90);
            ////
            grayArcSegment.SweepDirection = SweepDirection.Clockwise;
            grayArcSegment.Size = new Size(Radius, Radius);
            grayArcSegment.RotationAngle = angle;
            grayArcSegment.IsLargeArc = largeArc;
            /////////////////////////////////////////////////////////////
            ///ARC1
            /////////////////////////////////////////////////////////////
            double arc1Angle = 95;

            startPoint = ComputeCartesianCoordinate(arc1Angle, Radius);
            startPoint.X += Radius + cX;
            startPoint.Y += Radius + cY;
            //if (startPoint.X == Math.Round(endPoint.X) && startPoint.Y == Math.Round(endPoint.Y))
            //    startPoint.X -= 0.01;


            endPoint = ComputeCartesianCoordinate(arc1Angle + A1, Radius);
            endPoint.X += Radius + cX;
            endPoint.Y += Radius + cY;
            //if (startPoint.X == Math.Round(endPoint.X) && startPoint.Y == Math.Round(endPoint.Y))
            //    endPoint.X -= 0.01;

            pathFigure.StartPoint = startPoint; //new Point(endPoint.X, endPoint.Y + 15);
            arcSegment.Point = endPoint;
            ////
            arcSegment.SweepDirection = SweepDirection.Clockwise;
            arcSegment.Size = new Size(Radius, Radius);
            arcSegment.RotationAngle = angle;
            arcSegment.IsLargeArc = largeArc;
            /////////////////////////////////////////////////////////////
            ///ARC2
            /////////////////////////////////////////////////////////////
            double arc2Angle = 185;

            startPoint = ComputeCartesianCoordinate(arc2Angle, Radius);
            startPoint.X += Radius + cX;
            startPoint.Y += Radius + cY;
            //if (startPoint.X == Math.Round(endPoint.X) && startPoint.Y == Math.Round(endPoint.Y))
            //    endPoint.X -= 0.01;


            endPoint = ComputeCartesianCoordinate(arc2Angle + A2, Radius);
            endPoint.X += Radius + cX;
            endPoint.Y += Radius + cY;
            //if (startPoint.X == Math.Round(endPoint.X) && startPoint.Y == Math.Round(endPoint.Y))
            //    endPoint.X -= 0.01;


            pathFigure2.StartPoint = startPoint;
            arcSegment2.Point = endPoint;
            ////
            arcSegment2.SweepDirection = SweepDirection.Clockwise;
            arcSegment2.Size = new Size(Radius, Radius);
            arcSegment2.RotationAngle = angle;
            arcSegment2.IsLargeArc = false;
            /////////////////////////////////////////////////////////////
            ///ARC3
            /////////////////////////////////////////////////////////////
            double arc3Angle = 275;

            startPoint = ComputeCartesianCoordinate(arc3Angle, Radius);
            startPoint.X += Radius + cX;
            startPoint.Y += Radius + cY;
            //if (startPoint.X == Math.Round(endPoint.X) && startPoint.Y == Math.Round(endPoint.Y))
            //    endPoint.X -= 0.01;


            endPoint = ComputeCartesianCoordinate(arc3Angle + A3, Radius);
            endPoint.X += Radius + cX;
            endPoint.Y += Radius + cY;
            //if (startPoint.X == Math.Round(endPoint.X) && startPoint.Y == Math.Round(endPoint.Y))
            //    endPoint.X -= 0.01;

            pathFigure3.StartPoint = startPoint;
            arcSegment3.Point = endPoint;

            arcSegment3.SweepDirection = SweepDirection.Clockwise;
            arcSegment3.Size = new Size(Radius, Radius);
            arcSegment3.RotationAngle = angle;
            arcSegment3.IsLargeArc = false;

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
