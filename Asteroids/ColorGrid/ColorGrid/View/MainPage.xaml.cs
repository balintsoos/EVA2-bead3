using DLToolkit.Forms.Controls;
using Xamarin.Forms;

namespace Asteroids.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            FlowListView.Init();
        }
    }
}
