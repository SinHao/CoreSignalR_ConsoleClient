using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace CoreSignalR_ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/SignalR_Sample")
                .Build();

            connection.On<string, string>("ClientMethod1", (userName, message) =>
            {
                Console.WriteLine($"{userName}:{message}");
            });

            //SignalR連線開始
            connection.StartAsync()
                .ContinueWith(t =>
                {
                    if (t.IsCompletedSuccessfully)
                    {
                        //呼叫Server的ServerMethod1();
                        connection.InvokeAsync("ServerMethod1", "ConesoleUser", "ConsoleMessage");
                    }
                });            

            Console.Read();
        }
    }
}
