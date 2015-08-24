using System;

using Bijuu.ServiceProvider;

using Microsoft.Practices.Unity;

using fit;


namespace Waffle.FitNesseTests.Message
{
    public class SendMessage : ColumnFixture
    {
        [Dependency]
        public IBijuuServiceClient BijuuServiceClient { get; set; }

        public string Message { get; set; }
        public Guid SenderId { get; set; }


        public bool Send()
        {
            BijuuServiceClient.SendMessage(Message, SenderId);
            return true;
        }
    }
}
