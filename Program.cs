public class BankCustomer
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string CardNum { get; set; }
    public int Pin { get; set; }
    public double Balance { get; set; }

    public BankCustomer(string name, string lastName, string cardNum, int pin, double balance)
    {
        this.Name = name;
        this.LastName = lastName;
        this.CardNum = cardNum;
        this.Pin = pin;
        this.Balance = balance;
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Scegli una delle seguenti opzioni: ");
            Console.WriteLine("");
            Console.WriteLine("1. Deposita");
            Console.WriteLine("2. Ritira");
            Console.WriteLine("3. Mostra saldo");
            Console.WriteLine("4. Esci");
            Console.WriteLine("");
        }

        void deposit(BankCustomer bankCustomer)
        {
            Console.WriteLine("");
            Console.WriteLine("Quanti soldi vuoi depositare?");
            double amount = 0;
            try
            {
                amount = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Comando non valido!");
            }
            bankCustomer.Balance += amount;
            Console.WriteLine("");
            Console.WriteLine($"Hai depositato € {amount}, il tuo nuovo saldo è di € {bankCustomer.Balance}");
        }

        void withDraw(BankCustomer bankCustomer)
        {
            Console.WriteLine("");
            Console.WriteLine("Inserisci l'importo da ritirare");
            Console.WriteLine("");
            double amount = 0;
            try
            {
                amount = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Comando non valido!");
            }

            // Controllo che i soldi ci siano
            if (bankCustomer.Balance >= amount)
            {
                bankCustomer.Balance -= amount;
                Console.WriteLine("");
                Console.WriteLine($"Hai ritirato € {amount}, il tuo nuovo saldo è di € {bankCustomer.Balance}");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Non hai abbastanza fondi sul conto :(");
                Console.WriteLine("");
            }
        }

        void balance(BankCustomer bankCustomer)
        {
            Console.WriteLine("");
            Console.WriteLine($"Saldo disponibile: € {bankCustomer.Balance}");
        }

        List<BankCustomer> bankCustomers = new List<BankCustomer>();

        bankCustomers.Add(new BankCustomer("Gigino", "Rossi", "4888154523655222", 1234, 1207.55));
        bankCustomers.Add(new BankCustomer("Eric", "Brown", "4888584798653215", 1234, 202.64));
        bankCustomers.Add(new BankCustomer("Marco", "Verdi", "4888369866221477", 1234, 5007.00));
        bankCustomers.Add(new BankCustomer("Simone", "Neri", "4888112221458998", 1234, 10244.27));

        Console.OutputEncoding = System.Text.Encoding.UTF8;


        // Prompt user
        Console.WriteLine("Benvenuto nella tua fantastica banca!");
        Console.Write("Per favore, inserisci il numero della tua carta di debito: ");

        string debitCardNum = "";
        BankCustomer currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                Console.WriteLine("");
                currentUser = bankCustomers.FirstOrDefault(customer => customer.CardNum.Equals(debitCardNum));

                if (currentUser != null) break;
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Questa carta non è presente nei nostri archivi, sei sicuro che sia corretto?");
                    Console.WriteLine("");
                }
            }
            catch { Console.WriteLine("Questa carta non è presente nei nostri archivi, sei sicuro che sia corretto?"); }
        }

        Console.Write("Inserisci il pin: ");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                Console.WriteLine("");

                if (currentUser.Pin.Equals(userPin)) { break; }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Il pin inserito non è corretto, riprova!");
                    Console.WriteLine("");
                }
            }
            catch { Console.WriteLine("Il pin inserito non è corretto, riprova!"); }
        }

        Console.WriteLine($"Benvenuto {currentUser.Name} {currentUser.LastName}! :)");
        Console.WriteLine("");
        int options = 0;
        int answer = 1;

        while (answer == 1)
        {
            printOptions();
            try
            {
                options = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Comando non valido!");
            }

            if (options.Equals(1)) deposit(currentUser);
            else if (options.Equals(2)) withDraw(currentUser);
            else if (options.Equals(3)) balance(currentUser);
            else if (options.Equals(4))
            {
                Console.WriteLine("Ciao e buona giornata! :)");
                break;
            }
            else options.Equals(0);

            Console.WriteLine("");
            Console.WriteLine("Vuoi fare un'altra operazione?");
            Console.WriteLine("1. Si");
            Console.WriteLine("2. No");
            Console.WriteLine("");
            try
            {
                answer = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("");
                Console.WriteLine("Inserisci un numero compreso tra 1 e 2!");
            }
            Console.WriteLine("");

            if (answer == 1)
            {
                printOptions();
                try
                {
                    options = int.Parse(Console.ReadLine());
                }
                catch
                {

                    Console.WriteLine("Usa il punto, non la virgola!");
                }

                if (options.Equals(1)) deposit(currentUser);
                else if (options.Equals(2)) withDraw(currentUser);
                else if (options.Equals(3)) balance(currentUser);
                else if (options.Equals(4))
                {
                    Console.WriteLine("Ciao, buona giornata! :)");
                    break;
                }
                else options.Equals(0);
            }
            else if (answer == 2)
            {
                Console.WriteLine("Ciao, buona giornata :)");
            }
            else
            {
                while (answer != 1 && answer != 2)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Risposta non valida");
                    Console.WriteLine("");
                    Console.WriteLine("Vuoi fare un'altra operazione?");
                    Console.WriteLine("");
                    answer = int.Parse(Console.ReadLine());
                }

                Console.WriteLine("Ciao, buona giornata! :)");
            }
        }
    }
}