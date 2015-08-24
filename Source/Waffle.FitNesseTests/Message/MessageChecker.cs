using System;
using System.Linq;

using Bijuu.Contracts;
using Bijuu.ServiceProvider;

using Microsoft.Practices.Unity;

using fit;


namespace Waffle.FitNesseTests.Message
{
    public class MessageChecker : ColumnFixture
    {
        [Dependency]
        public IBijuuServiceClient BijuuServiceClient { get; set; }

        public string Message
        {
            get { return GetMessage().Text; }
        }

        public Guid RecipientId
        {
            get { return GetMessage().RecipientId.Value; }
        }

        public Guid SenderId { get; set; }


        private MessageInfo GetMessage()
        {
            return BijuuServiceClient.GetAllMessages().FirstOrDefault(x => x.SenderId == SenderId);
        }
    }
}
