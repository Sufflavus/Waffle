using System;


namespace Taddy.BusinessLogic
{
    public sealed class Message
    {
        public DateTime CreateDate { get; set; }
        public string Text { get; set; }


        public override string ToString()
        {
            return string.Format("CreateDate: {0}, Text: {1}", CreateDate, Text);
        }
    }
}
