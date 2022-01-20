using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;
using Android.App;

namespace BreakoutGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageGame : ContentPage
    {
        #region Variable
        classPadde padde;
        classBall ball;
        classEnemy enemy;
        classTimerBall timerBall;
        ImageSource source;
        List<Image> imageHeart;
        #endregion

        public PageGame(ImageSource src)
        {
            InitializeComponent();
            imageHeart = new List<Image>() { heart1, heart2, heart3, heart4 };
            source = src;
            padde = new classPadde(1);
            ball = new classBall();
            enemy = new classEnemy(ball, gameArea);
            padde.createPadde(0.5, 0.9, 0.2, 0.03);
            ball.createBall(0.5, 0.87, 20, 20);
            gameArea.Children.Add(padde.boxPadde);
            gameArea.Children.Add(ball.boxBall);
            enemy.AddEnemy();
            timerBall = new classTimerBall(ball, padde, enemy, lblCount, btnLevel, imageHeart);
        }
       
            
        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var slide = (Slider)sender;
            padde.setPaddlePosition(slide.Value);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            contentPageBackground.BackgroundImageSource = source;
            btnCommencer.IsVisible = false;
            gameStacklayout.IsVisible = true;
            timerBall.countDown();
        }

    }
}