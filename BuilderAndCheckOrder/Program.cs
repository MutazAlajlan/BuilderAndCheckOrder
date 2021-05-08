using System;

namespace BuilderAndCheckOrder
{
    class Program
    {
        class XMLBuilder
        {
            string xml;

            public XMLBuilder AddHeader()
            {
                this.xml += "<?xml version=\"1.0\" encoding=\"utf - 8\"?>\n";
                return this;
            }

            public XMLBuilder AddTag(string input)
            {
                 this.xml += "<" + input + "> \n";
                return this;
            }
            public XMLBuilder AddContent(string input, char format =' ')
            {
                if(format != ' ' && (format == 'i' || format == 'b'))
                {
                   // text format for b = bold, i = italic.
                    this.xml += '<' + format + '>' + input + "</" + format + ">\n";
                }
                else
                {
                    // without format.
                    this.xml += input + "\n";
                }
                return this;
            }
            public XMLBuilder AddComment(string input)
            {
                this.xml += "<!--" + input + "-->\n";
                return this;
            }
            public string Get()
            {
                return this.xml;
            }
            public XMLBuilder()
            {
                xml = "";
            }
        }
        public static bool CheckOrder(string value)
        {
            //return true if even.
            int count = 0;
            for(int index = 0; index < value.Length; index++)
            {
                if(Char.IsDigit(value[index]))
                {
                    for(int i = 0; i < value.Length; i++)
                    {
                        if (value[i] == value[index])
                        {
                            count++;
                        }
                    }
                }
            }
            if (count % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        static void Main(string[] args)
        {
            XMLBuilder xml = new XMLBuilder();
            string xmlString = xml.AddHeader().AddTag("soap:Envelope").AddTag("soap:Body")
                .AddTag("id").AddContent("394").AddTag("id").AddComment("end of id tag")
                .AddTag("soap:Body").AddTag("soap:Envelope").Get();
            Console.WriteLine(xmlString);

            string numbers = "893398";
            string falseNumbers = "1234321";
            Console.WriteLine(CheckOrder(numbers));
            Console.WriteLine(CheckOrder(falseNumbers));
            Console.WriteLine(CheckOrder("1122345543"));

        }
    }
}
