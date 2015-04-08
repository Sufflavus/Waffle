using System;

using Bijuu.Contracts;


namespace Bijuu.Service
{
    public interface INotifier
    {
        void NewMessageNotify(MessageInfo message);
    }
}
