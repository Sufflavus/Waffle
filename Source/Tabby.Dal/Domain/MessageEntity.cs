using System;


namespace Tabby.Dal.Domain
{
    public sealed class MessageEntity
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
    }
}
