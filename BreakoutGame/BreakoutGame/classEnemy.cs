using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BreakoutGame
{
    public class classEnemy
    {
        private Random random = new Random();

        public List<Button> listEnemy { get; set; }
        public int listEnemyInvisible { get; set; }
        private classBall _ball { get; set; }
        private AbsoluteLayout _gameArea { get; set; }
        public classEnemy(classBall ball, AbsoluteLayout gameArea)
        {
            listEnemy = new List<Button>();
            _ball = ball;
            _gameArea = gameArea;
        }
        private Button createEnnemy(double x, double y, double width, double height)
        {
            Button boxEnnemy = new Button { BackgroundColor = /*Color.FromRgb(random.Next(30, 255), random.Next(30, 255), random.Next(30, 255))*/Color.Red, CornerRadius = 5,
            BorderColor = Color.Khaki, BorderWidth = 3};
            Rectangle paddingRect = new Rectangle(x,y, width, height);
            boxEnnemy.SetValue(AbsoluteLayout.LayoutBoundsProperty, paddingRect);
            boxEnnemy.SetValue(AbsoluteLayout.LayoutFlagsProperty, AbsoluteLayoutFlags.All);

            return boxEnnemy;
        }

        public void collisionEnemy()
        {
            for (int i = 0; i < listEnemy.Count; i++)
            {
                if (_ball.boxBall.Bounds.IntersectsWith(listEnemy[i].Bounds) && listEnemy[i].IsVisible)
                {
                    if(_ball.valueY < 0)
                        _ball.valueY = -_ball.valueY;
                    listEnemy[i].IsVisible = false;
                    listEnemyInvisible--;
                }
            }
        }

        public void AddEnemy()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    Button enemy = createEnnemy(i * 0.2, j * 0.09, 0.15, 0.08);
                    listEnemy.Add(enemy);
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        _gameArea.Children.Add(enemy);
                    });
                }
            }
            listEnemyInvisible = listEnemy.Count;
        }

        public void EnemyVisible()
        {
            for (int i = 0; i < listEnemy.Count; i++)
            {
                listEnemy[i].IsVisible = true;
            }
            listEnemyInvisible = listEnemy.Count;
        }
    }
}
