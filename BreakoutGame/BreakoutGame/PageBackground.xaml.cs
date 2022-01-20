using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BreakoutGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageBackground : ContentPage
    {
        List<FileImageSource> imageSources;
        public PageBackground()
        {
            InitializeComponent();
            imageSources = new List<FileImageSource>()
            { 
                "bg1.jpg",
                "bg2.jpg",
                "bg3.jpg",
                "bg5.jpg",
                "bg6.jpg",
                "bg7.jpg",
                "bg8.jpg",
                "bg9.jpg",
                "bg10.jpg"
            };

            foreach (FileImageSource src in imageSources)
                stackLayoutImageBackground.Children.Add(creaateImage(src));
        }

        private ImageButton creaateImage(string src)
        {
            ImageButton img = new ImageButton();
            img.Source = src;
            img.BackgroundColor = Color.Transparent;
            img.Clicked += Img_Clicked;
            return img;
        }

        private void Img_Clicked(object sender, EventArgs e)
        {
            var src = (ImageButton)sender;
            Navigation.PushAsync(new PageGame(src.Source));
        }
    }
}