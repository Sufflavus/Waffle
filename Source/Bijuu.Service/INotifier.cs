using System;

using Bijuu.Contracts;

using Ginger.Contracts;


namespace Bijuu.Service
{
    public interface INotifier
    {
        void NewMessageNotify(MessageRecord message);
    }
}
