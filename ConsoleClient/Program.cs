using Grpc.Net.Client;
using System;
using System.Globalization;
using ProductionStructure.GrpcProtos;
using Google.Protobuf.WellKnownTypes;

namespace ProductionStructure.ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Presione una tecla para conectar");
            Console.ReadKey();

            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            var channel = GrpcChannel.ForAddress(
                "http://localhost:5030",
                new GrpcChannelOptions { HttpHandler = httpHandler });

            if (channel is null)
            {
                Console.WriteLine("Cannot connect");
                channel.Dispose();
                return;
            }

            var client = new WorkSession.WorkSessionClient(channel);

            Console.WriteLine("Presione una tecla para crear una Sesion de Trabajo");
            Console.ReadKey();
            var createResponse = client.CreateWorkSession(new CreateWorkSessionRequest()
            {
                Initdate = Timestamp.FromDateTime(DateTime.Now)
            });
        }
    }
    
}