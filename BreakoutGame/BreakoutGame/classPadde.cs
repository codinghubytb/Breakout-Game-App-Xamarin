using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BreakoutGame
{
    public class classPadde
    {
        public BoxView boxPadde { get; set; }
        public double valueX { get; set; }
        private double _positionX { get; set; }
        private double _positionY { get; set; }
        private double _sizeWidth { get; set; }
        private double _sizeHeight { get; set; }
        public classPadde(double value)
        {
            valueX = value;
        }
        public void createPadde(double x, double y, double width, double height)
        {
            _positionX = x;
            _positionY = y;
            _sizeWidth = width;
            _sizeHeight = height;
            boxPadde = new BoxView { BackgroundColor = Color.White};
            Rectangle paddingRect = new Rectangle(_positionX, _positionY, _sizeWidth, _sizeHeight);
            boxPadde.SetValue(AbsoluteLayout.LayoutBoundsProperty, paddingRect);
            boxPadde.SetValue(AbsoluteLayout.LayoutFlagsProperty, AbsoluteLayoutFlags.All);
        }
        public void setPaddlePosition(double x)
        {
            Rectangle paddingRect = new Rectangle(x, _positionY, _sizeWidth, _sizeHeight);
            boxPadde.SetValue(AbsoluteLayout.LayoutBoundsProperty, paddingRect);
            _positionX = x;
        }
        public void setPaddleSize(double width, double height)
        {
            Rectangle paddingRect = new Rectangle(_positionX, _positionY, width, height);
            boxPadde.SetValue(AbsoluteLayout.LayoutBoundsProperty, paddingRect);
            _sizeWidth = width;
            _sizeHeight = height;
        }
        public void movePadde()
        {
            Rectangle paddingRect = new Rectangle(boxPadde.X + valueX, boxPadde.Y, boxPadde.Width, boxPadde.Height);
            boxPadde.SetValue(AbsoluteLayout.LayoutBoundsProperty, paddingRect);
        }
    }
}
