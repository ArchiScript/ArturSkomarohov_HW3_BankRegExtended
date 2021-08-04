using System;
using System.Collections.Generic;
using System.Linq;



namespace BankRegExtended
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Dictionary<Client, List<Account>> clients =
    new Dictionary<Client, List<Account>>();
            clients.Add(new Client
            {
                Name = "Василий Александрович Петров",
                DateOfBirth = "25.05.1975",
                PassNumber = "I-ПР012345",


            }, new List<Account>().Add(
                new Account
                {
                    AccNumber = 0230000000143456,
                    CurrencyType = new RUB(),
                    Balance = 1200m
                });
                

            clients.Add(new Client
            {
                Name = "Dan Brown",
                DateOfBirth = "23.09.1985",
                PassNumber = "I-ПР055345",

            }, new Account { AccNumber = 0230000000143456, CurrencyType = new RUB(), Balance = 1200m });
            clients.Add(new Client
            {
                Name = "Егор Борисович Брынза",
                DateOfBirth = "01.02.1963",
                PassNumber = "I-ПР058845",

            }, new Account { AccNumber = 0230000000178456, CurrencyType = new MDL(), Balance = 8700m });
            clients.Add(new Client
            {
                Name = "Алиса Макаровна Шашли",
                DateOfBirth = "05.08.2001",
                PassNumber = "I-ПР753845",

            }, new Account { AccNumber = 0230000000278456, CurrencyType = new RUB(), Balance = 1700m });
            clients.Add(new Client
            {
                Name = "Изя Вольфович Шниперсон",
                DateOfBirth = "14.06.1958",
                PassNumber = "I-ПР753822",

            }, new Account { AccNumber = 0230000000778456, CurrencyType = new USD(), Balance = 2300m });


            //Поиск по номеру паспорта
            DisplayClient(GetClientByPass(clients, "I-ПР058845"));


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


            DisplayConvertedCur(25, new USD(), new UAH());
        }


        public static void DisplayConvertedCur(decimal ammount, Currency convertFrom, Currency convertTo)
        {
            var conv = new CurrencyConverter().ConvertCur(ammount, convertFrom, convertTo);
            Console.WriteLine($"Конвертировано: {ammount} {convertFrom.Sign} на {conv} {convertTo.Sign}");
        }
        public static void DisplayClient(Dictionary<Client, Account> resultPair)
        {
            foreach (var cl in resultPair)
            {
                Console.WriteLine($"Найдены данные по номеру пасспорта \n" +
                    $"{cl.Key.Name} пасспорт № {cl.Key.PassNumber} \n Счет: {cl.Value.AccNumber} " +
                    $"{cl.Value.Balance} {cl.Value.CurrencyType.Sign} ");
            }
        }

        public static Dictionary<Client, Account> GetClientByPass(Dictionary<Client, Account> clients, string passNumber)
        {
            var findName =
                from client in clients
                where client.Key.PassNumber == passNumber
                select client;
            Dictionary<Client, Account> result = new Dictionary<Client, Account>();
            foreach (var item in findName)
            {
                result.Add(
                    new Client
                    {
                        Name = item.Key.Name,
                        PassNumber = item.Key.PassNumber,
                        DateOfBirth = item.Key.DateOfBirth
                    },
                    new Account
                    {
                        AccNumber = item.Value.AccNumber,
                        Balance = item.Value.Balance,
                        CurrencyType = item.Value.CurrencyType
                    });
                /*select (new Dictionary<Client, Account>().Add(
                                    new Client
                    {
                        Name = client.Key.Name,
                        PassNumber = client.Key.PassNumber,
                        DateOfBirth = client.Key.DateOfBirth
                    },
                    new Account
                    {
                        AccNumber = client.Value.AccNumber,
                        Balance = client.Value.Balance,
                        CurrencyType = client.Value.CurrencyType
                    }
                    ))).FirstOrDefault();*/

            }
            return result;
        }
        public static void DisplayClientByName(Dictionary<Client, Account> clients, string name)
        {
            var findName =
          from client in clients
          where client.Key.Name == name
          select client;

            foreach (var item in findName)
            {
                Console.WriteLine($" Найдены данные по ФИО {name}: {item.Key.Name} {item.Value.AccNumber} \n");
            }
        }

        public static void DisplayClientUnderSum(Dictionary<Client, Account> clients, decimal sum)
        {
            var lowerSum =
               from client in clients
               where client.Value.Balance < sum
               select client;
            foreach (var cl in lowerSum)
            {
                Console.WriteLine($" Сумма меньше {sum}$:   {cl.Key.Name} {cl.Key.PassNumber} {cl.Value.Balance} \n");
            }
        }

        public static void DisplayLowestSumClient(Dictionary<Client, Account> clients)
        {
            Dictionary<string, decimal> sumCollection =
            new Dictionary<string, decimal>();

            foreach (var cl in clients)
            {
                sumCollection.Add(cl.Key.Name, cl.Value.Balance);
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

        public static void CountAllMoney(Dictionary<Client, Account> clients)
        {
            List<decimal> sumCollection = new List<decimal>();
            foreach (var cl in clients)
            {
                sumCollection.Add(cl.Value.Balance);
            }
            decimal totalSum = sumCollection.Sum();
            Console.WriteLine($" Общая сумма остатков на счетах клиентов банка: {totalSum} \n");
        }

        public static void DisplayYoungClient(Dictionary<Client, Account> clients)
        {
            Dictionary<DateTime, string> birthDays =
            new Dictionary<DateTime, string>();

            foreach (var cl in clients)
            {
                birthDays.Add(DateTime.Parse(cl.Key.DateOfBirth), cl.Key.Name);
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
