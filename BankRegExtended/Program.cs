using System;
using System.Collections.Generic;
using System.Linq;



namespace BankRegExtended
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Client> clients = new List<Client>();
            clients.Add(new Client
            {
                Name = "Василий Александрович Петров",
                DateOfBirth = "25.05.1975",
                PassNumber = "I-ПР012345",
                AccData = new Account { AccNumber = 0230000000563456, CurrencyType = new RUB (), Ammount = 460 },
                //AccSum = 500
            });
            clients.Add(new Client
            {
                Name = "Dan Brown",
                DateOfBirth = "23.09.1985",
                PassNumber = "I-ПР055345",
                AccData = new Account { AccNumber = 0230000000143456, CurrencyType = new RUB(), Ammount = 1200 },
                
                //AccSum = 2500
            });
            clients.Add(new Client
            {
                Name = "Егор Борисович Брынза",
                DateOfBirth = "01.02.1963",
                PassNumber = "I-ПР058845",
                AccData = new Account { AccNumber = 0230000000178456, CurrencyType = new RUB(), Ammount = 8700},
                //AccSum = 630
            });
            clients.Add(new Client
            {
                Name = "Алиса Макаровна Шашли",
                DateOfBirth = "05.08.2001",
                PassNumber = "I-ПР753845",
                AccData = new Account { AccNumber = 0230000000278456, CurrencyType = new RUB(), Ammount = 1200 },
                //AccSum = 2365
            });
            clients.Add(new Client
            {
                Name = "Изя Вольфович Шниперсон",
                DateOfBirth = "14.06.1958",
                PassNumber = "I-ПР753822",
                AccData = new Account { AccNumber = 0230000000778456, CurrencyType = new USD(), Ammount = 2300 },
                //AccSum = 33568
            });


            //Поиск по номеру паспорта
            DisplayClientByPass(clients, "I-ПР058845");

            //Поиск по имени
            DisplayClientByName(clients, "Алиса Макаровна Шашли");

            //Выборка по сумме
            DisplayClientUnderSum(clients, 1200);

            //Поиск клиента с мин суммой
            DisplayLowestSumClient(clients);

            //Подсчет общей суммы денег
            CountAllMoney(clients);

            //Самый молодой клиент банка
            DisplayYoungClient(clients);


        }
        public static void DisplayClientByPass(List<Client> clients, string passNumber)
        {
            var findName =
          from client in clients
          where client.PassNumber == passNumber
          select client;

            foreach (var item in findName)
            {
                Console.WriteLine($" Найдены данные по номеру пасспорта {passNumber}: {item.Name} {item.AccData.Ammount} \n");
            }
        }
        public static void DisplayClientByName(List<Client> clients, string name)
        {
            var findName =
          from client in clients
          where client.Name == name
          select client;

            foreach (var item in findName)
            {
                Console.WriteLine($" Найдены данные по ФИО {name}: {item.AccData} {item.AccData.Ammount} \n");
            }
        }

        public static void DisplayClientUnderSum(List<Client> clients, decimal sum)
        {
            var lowerSum =
               from client in clients
               where client.AccData.Ammount < sum
               select client;
            foreach (var cl in lowerSum)
            {
                Console.WriteLine($" Сумма меньше {sum}$:   {cl.Name} {cl.PassNumber} {cl.AccData.Ammount} \n");
            }
        }

        public static void DisplayLowestSumClient(List<Client> clients)
        {
            Dictionary<string, decimal> sumCollection =
            new Dictionary<string, decimal>();

            foreach (var cl in clients)
            {
                sumCollection.Add(cl.Name, cl.AccData.Ammount);
            }
            decimal lowestFromVal = sumCollection.Values.Min();
            foreach (var cl in sumCollection)
            {
                if (cl.Value == lowestFromVal)
                {
                    Console.WriteLine($" Наименьший остаток на счету: {cl.Key} {cl.Value} \n");
                }
            }
        }

        public static void CountAllMoney(List<Client> clients)
        {
            Dictionary<string, decimal> sumCollection =
            new Dictionary<string, decimal>();

            foreach (var cl in clients)
            {
                sumCollection.Add(cl.Name, cl.AccData.Ammount);
            }
            decimal totalSum = sumCollection.Values.Sum();
            Console.WriteLine($" Общая сумма остатков на счетах клиентов банка: {totalSum} \n");
        }

        public static void DisplayYoungClient(List<Client> clients)
        {
            Dictionary<DateTime, string> birthDays =
            new Dictionary<DateTime, string>();

            foreach (var cl in clients)
            {
                birthDays.Add(DateTime.Parse(cl.DateOfBirth), cl.Name);
            }

            foreach (var cl in birthDays)
            {
                DateTime clientDate = birthDays.Keys.Max();
                if (cl.Key == clientDate)
                {
                    Console.WriteLine($" Самый молодой клиент банка: {cl.Value} {cl.Key}");
                }
            }
        }
    }
}
