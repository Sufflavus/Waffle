using System;

using Bijuu.Service;

using fit;


namespace Waffle.FitNesseTests
{
    public class SetUpTestEnvironment : Fixture
    {
        internal static IRequestProcessor RequestProcessor;


        public SetUpTestEnvironment()
        {
            RequestProcessor = new RequestProcessor();
        }
    }
}
