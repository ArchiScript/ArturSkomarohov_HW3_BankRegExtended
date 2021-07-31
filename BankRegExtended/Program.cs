using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;


namespace BankRegExtended
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Client> clients = new List<Client>();
            clients.Add(new Client
            {
                Name = "Василий Александрович Петров",
                DateOfBirth = "25.05.1975",
                PassNumber = "I-ПР012345",
                AccNumber = 0230000000123456,
                AccSum = 500
            });
            clients.Add(new Client
            {
                Name = "Dan Brown",
                DateOfBirth = "23.09.1985",
                PassNumber = "I-ПР055345",
                AccNumber = 0230000000143456,
                AccSum = 2500
            });
            clients.Add(new Client
            {
                Name = "Егор Борисович Брынза",
                DateOfBirth = "01.02.1963",
                PassNumber = "I-ПР058845",
                AccNumber = 0230000000178456,
                AccSum = 630
            });
            clients.Add(new Client
            {
                Name = "Алиса Макаровна Шашли",
                DateOfBirth = "05.08.2001",
                PassNumber = "I-ПР753845",
                AccNumber = 0230000000278456,
                AccSum = 2365
            });


            var findName =
                from client in clients
                where client.Name == "Василий Александрович Петров"
                orderby client.AccSum descending
                select client;
            foreach (var cl in findName)
            {
                Console.WriteLine($"Найден клиент {cl.DateOfBirth}");
            }


            var lowerSum =
                from client in clients
                where client.AccSum < 1000
                select client;
            foreach (var cl in lowerSum)
            {
                Console.WriteLine($"Сумма меньше 1000$:   {cl.Name} {cl.PassNumber} {cl.AccSum}");
            }
            Dictionary<string, decimal> sumCollection =
            new Dictionary<string, decimal>();

            
            foreach (var cl in clients)
            {
                sumCollection.Add(cl.Name, cl.AccSum);
            }
            decimal lowestFromVal = sumCollection.Values.Min();
            foreach (var cl in sumCollection)
            {
                if(cl.Value == lowestFromVal) { Console.WriteLine($"{cl.Key} {cl.Value}"); }
            }

            decimal overall = sumCollection.Values.Sum();
            Console.WriteLine(overall);

        }


    }
}
