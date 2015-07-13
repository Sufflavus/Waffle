using System;


namespace Tabby.Station.Controllers
{
    public class WindowController : IWindowController
    {
        public void OpenChatterWindow(Guid userId)
        {
            var chatter = new Chatter(userId);
            chatter.Show();
        }
    }
}
