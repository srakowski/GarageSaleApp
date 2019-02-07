using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using GarageSaleApp.Domain;
using GarageSaleApp.UwpApp.Services;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GarageSaleApp.UwpApp.ViewModels
{
    class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<Frame>(() => Window.Current.Content as Frame);
            SimpleIoc.Default.Register<INavigationService, FrameNavigationService>();
            SimpleIoc.Default.Register<IGarageSaleEventRepository, DataAccess.FileGarageSaleEventRepository>();
            SimpleIoc.Default.Register<GarageSaleEventManager>();

            SimpleIoc.Default.Register<DashboardViewModel>();
            SimpleIoc.Default.Register<GarageSaleEventViewModel>();
        }

        public DashboardViewModel Dashboard
        {
            get => SimpleIoc.Default.GetInstance<DashboardViewModel>();
        }

        public GarageSaleEventViewModel GarageSaleEvent
        {
            get => SimpleIoc.Default.GetInstance<GarageSaleEventViewModel>();
        }
    }
}
