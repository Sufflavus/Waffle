using System;


namespace Ginger.Contracts
{
    public sealed class UserRecord
    {
        public Guid Id { get; set; }

        public bool IsOnline { get; set; }

        public string Name { get; set; }
    }
}
