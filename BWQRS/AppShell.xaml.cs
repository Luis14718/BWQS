using System;
using System.Collections.Generic;
using BWQRS.ViewModels;
using BWQRS.Views;
using Xamarin.Forms;

namespace BWQRS
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
