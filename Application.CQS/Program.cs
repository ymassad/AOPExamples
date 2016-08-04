using System;
using AOP.Common;

namespace Application.CQS
{
    class Program
    {
        static void Main(string[] args)
        {
            var queryHandler =
                new FakeDocumentSource("connectionString1")
                    .AsLoggable(
                        new LoggingData { Name = "connectionString", Value = "connectionString1" },
                        new LoggingData { Name = "Department", Value = "A" });

            var result = queryHandler.Handle(new GetDocumentsQuery("docx"));

            Console.ReadLine();
        }
    }
}
