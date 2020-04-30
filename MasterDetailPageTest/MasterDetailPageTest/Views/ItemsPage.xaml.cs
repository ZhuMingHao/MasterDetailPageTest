using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MasterDetailPageTest.Models;
using MasterDetailPageTest.Views;
using MasterDetailPageTest.ViewModels;

namespace MasterDetailPageTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
           
            MenuPage.menuItems.Insert(0,new HomeMenuItem { Id = MenuItemType.User, Title = "User" });
            MenuPage.menuItems.RemoveAt(1);
            await RootPage.NavigateFromMenu((int)MenuPage.menuItems[0].Id);    
        }
    }
}