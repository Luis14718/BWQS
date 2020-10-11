using System.ComponentModel;
using Xamarin.Forms;
using BWQRS.ViewModels;

namespace BWQRS.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}