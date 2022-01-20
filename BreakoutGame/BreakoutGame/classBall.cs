using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BreakoutGame
{
    public class classBall
    {
        public double valueX { get; set; } = 0.025;
        public double valueY { get; set; } = -0.025;

        private double _positionX { get; set; }
        private double _positionY { get; set; }
        private double _sizeWidth { get; set; }
        private double _sizeHeight { get; set; }
        public BoxView boxBall { get; set; }
        public classBall()
        {
        }
        public void createBall(double x, double y, double width, double height)
        {
            _positionX = x;
            _positionY = y;
            _sizeWidth = width;
            _sizeHeight = height;
            boxBall = new BoxView { BackgroundColor = Color.White, CornerRadius = 50 };
            Rectangle paddingRect = new Rectangle(_positionX, _positionY, _sizeWidth, _sizeHeight);
            boxBall.SetValue(AbsoluteLayout.LayoutBoundsProperty, paddingRect);
            boxBall.SetValue(AbsoluteLayout.LayoutFlagsProperty, AbsoluteLayoutFlags.PositionProportional);
        }
        public void setBallPosition(double x, double y)
        {
            Rectangle paddingRect = new Rectangle(x, y, boxBall.Width, boxBall.Height);
            boxBall.SetValue(AbsoluteLayout.LayoutBoundsProperty, paddingRect);
            _positionX = x;
            _positionY = y;
        }
        public void setBallSize(double width, double height)
        {
            Rectangle paddingRect = new Rectangle(boxBall.X, boxBall.Y, width, height);
            boxBall.SetValue(AbsoluteLayout.LayoutBoundsProperty, paddingRect);
        }
        public void moveBall()
        {
           Rectangle paddingRect = new Rectangle(_positionX + valueX, _positionY + valueY, boxBall.Width, boxBall.Height);
           boxBall.SetValue(AbsoluteLayout.LayoutBoundsProperty, paddingRect);
            _positionX = _positionX + valueX;
            _positionY = _positionY + valueY;
        } 
        public void collisionBalle(BoxView pad)
        {
            if (_positionX >= 1 || _positionX <= 0)
                valueX = -valueX;
            else if (boxBall.Bounds.IntersectsWith(pad.Bounds))
                if (valueY > 0)
                    valueY = -valueY;
            if(_positionY <= 0)
                valueY = -valueY;
        }
    }
}
