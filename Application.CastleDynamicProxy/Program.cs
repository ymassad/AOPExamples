using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AOP;
using AOP.Common;

namespace Application.CastleDynamicProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var finder =
                new FakeDocumentSource("connectionString1")
                .AsLoggable<IDocumentSource>(
                    new LoggingData { Name = "connectionString", Value = "connectionString1"},
                    new LoggingData { Name = "Department", Value = "A" });

            var result = finder.GetDocuments("docx");

            Console.ReadLine();
        }
    }
}

