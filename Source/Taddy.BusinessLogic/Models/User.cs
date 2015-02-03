using System;


namespace Taddy.BusinessLogic.Models
{
    public sealed class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }


        public override string ToString()
        {
            return string.Format("Id: {0}, UserName: {1}", Id, Name);
        }
    }
}
