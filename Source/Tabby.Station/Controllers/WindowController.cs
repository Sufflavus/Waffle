using System;

using Tabby.Station.ViewModels;
using Tabby.Station.Views;


namespace Tabby.Station.Controllers
{
    public class WindowController : IWindowController
    {
        public void OpenChatterWindow(Guid userId)
        {
            var chatter = new ChatterWindow();
            (chatter.DataContext as ChatterWindowViewModel).UserId = userId;
            chatter.Show();
        }
    }
}
