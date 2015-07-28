using System;

using fit;


namespace Waffle.FitNesseTests
{
    public class HelloWorld : ColumnFixture
    {
        public string str1;
        public string str2;


        public string Concatenate()
        {
            return str1 + " " + str2;
        }
    }
}
