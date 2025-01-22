using Grpc.Net.Client;
using System;
using System.Globalization;
using ProductionStructure.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using System.Security.Cryptography.X509Certificates;
using CountryData.Standard;

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

            #region Menu
            #endregion

            #region Functions CRUD
                #region Site
            //static void CreateSite(GrpcChannel channel)
            //{
            //    var siteClient =new Site.SiteClient(channel);

            //    string siteName;
            //    //Country country;
            //    string city;
            //    string address;

            //    Console.WriteLine("Name:\n");
            //    siteName = Console.ReadLine();
            //    Console.WriteLine("Country Short Code:\n");
                 
            //}
                #endregion

                #region Area
                #endregion

                #region WorkCenter
                #endregion

                #region Unit
                #endregion

                #region WorkSession
                #endregion
            #endregion
        }
    }
    
}