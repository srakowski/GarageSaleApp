﻿using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GarageSaleApp.UwpApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GarageSaleEditorView : Page
    {
        public GarageSaleEditorView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            (this.DataContext as ViewModels.GarageSaleEventViewModel)
                ?.Load(e.Parameter);
        }
    }
}
