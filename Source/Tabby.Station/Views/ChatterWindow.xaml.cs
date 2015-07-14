using System;
using System.Windows;


namespace Tabby.Station.Views
{
    /// <summary>
    /// Interaction logic for ChatterWindow.xaml
    /// </summary>
    public partial class ChatterWindow : Window
    {
        private readonly Guid _userId;


        public ChatterWindow(Guid userId)
        {
            _userId = userId;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }
    }
}
