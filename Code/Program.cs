using System;

namespace TestTransaction
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new Service();
            while (true)
            {
                Console.WriteLine("Введите команду");
                var commandName = Console.ReadLine();
                switch (commandName)
                {
                    case Constants.Add:
                        int idAdd = PrintGetParsedValue<int>(Console.ReadLine, (string s) => Convert.ToInt32(s), "Введите Id: ",
                            "Введите целое число большее или равное 1");

                        DateTime dt = PrintGetParsedValue<DateTime>(Console.ReadLine, (string s) => Convert.ToDateTime(s),
                            "Введите дату в формате DD.MM.YYYY: ", "Введите в верном формате");

                        Decimal amount = PrintGetParsedValue<decimal>(() => Console.ReadLine().Replace('.', ','),
                            (string s) => Convert.ToDecimal(s), "Введите сумму, используя точку, как разделитель: ",
                            "Введите в верном формате");

                        if (service.Add(idAdd, dt, amount))
                        {
                            Console.WriteLine("Транзакция добавлена");
                        }
                        else
                        {
                            Console.WriteLine("Транзакция не добавлена. Id зарегистрирован в системе");
                        }
                        break;
                    case Constants.Get:
                        int idGet = PrintGetParsedValue<int>(Console.ReadLine, (string s) => Convert.ToInt32(s), "Введите Id: ",
                            "Введите целое число большее или равное 1");

                        string transactionString;
                        if (service.Get(idGet, out transactionString))
                        {
                            Console.WriteLine(transactionString);
                        }
                        else
                        {
                            Console.WriteLine("Транзакция не найдена в системе");
                        }
                        break;
                    case Constants.Exit:
                        return;
                    default:
                        break;
                }
            }
        }

        private static T PrintGetParsedValue<T>(Func<string> getValue, Func<string, T> parse, string title, string errorMessage)
        where T : struct
        {
            while (true)
            {
                Console.Write(title);
                T result;
                var value = getValue();
                if (Helper.GetParsedValue<T>(value, parse, out result))
                {
                    return result;
                }
                Console.Write(errorMessage);
            }
        }

    }
}






