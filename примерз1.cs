using System;

namespace TelevisionApp
{
    public class Television
    {
        // Поля
        private string brand;
        private double screenSize;
        private double price;
        private string country;
        private bool isOn; // Поле для отслеживания состояния телевизора

        // Константное поле
        public const string Advice = "Настройте телевизор на правильный канал и наслаждайтесь.";

        // Свойства
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public double ScreenSize
        {
            get { return screenSize; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Диагональ должна быть положительным числом.");
                screenSize = value;
            }
        }

        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Цена не может быть отрицательной.");
                price = value;
            }
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        // Конструкторы
        public Television() // Конструктор по умолчанию
        {
            brand = "Sony";
            screenSize = 42.0;
            price = 10000.0;
            country = "Japan";
            isOn = false;
        }

        public Television(string brand, double screenSize, double price, string country) // Конструктор с параметрами
        {
            this.brand = brand;
            ScreenSize = screenSize; // Используем свойство для проверки
            Price = price; // Используем свойство для проверки
            this.country = country;
            isOn = false;
        }

        // Методы
        public void TurnOn()
        {
            isOn = true;
            Console.WriteLine($"{brand} телевизор включен.");
        }

        public void TurnOff()
        {
            isOn = false;
            Console.WriteLine($"{brand} телевизор выключен.");
        }

        public void Watch()
        {
            if (!isOn)
                Console.WriteLine($"{brand} телевизор выключен. Сначала включите его.");
            else
                Console.WriteLine($"{brand} телевизор включен. Наслаждайтесь просмотром.");
        }

        // Статический метод
        public static void ShowAdvice()
        {
            Console.WriteLine(Advice);
        }

        // Перегрузка метода ToString()
        public override string ToString()
        {
            return $"Телевизор: {brand}, диагональ: {screenSize} дюймов, цена: {price} руб., страна: {country}";
        }

        public override bool Equals(object obj) 
        { 
            if (obj is Television tv) 
                return this.brand == tv.brand && this.screenSize == tv.screenSize && 
                       this.price == tv.price && this.country == tv.country && this.isOn == tv.isOn; 
            return false; 
        } 
 
        public override int GetHashCode() 
        { 
            return HashCode.Combine(brand, screenSize, price, country, isOn); 
        }
        // Перегрузка оператора сравнения ==
        public static bool operator ==(Television t1, Television t2)
        {
            return t1.Brand == t2.Brand &&
                   Math.Abs(t1.ScreenSize - t2.ScreenSize) < 0.001 &&
                   Math.Abs(t1.Price - t2.Price) < 0.001 &&
                   t1.Country == t2.Country;
        }

        // Перегрузка оператора !=
        public static bool operator !=(Television t1, Television t2)
        {
            return !(t1 == t2);
        }

        // Перегрузка арифметической операции +
        public static Television operator +(Television tv, double additionalPrice)
        {
            if (tv == null)
                throw new ArgumentNullException(nameof(tv), "Телевизор не может быть null.");
            
            return new Television(tv.Brand, tv.ScreenSize, tv.Price + additionalPrice, tv.Country);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Television tv1 = new Television(); // Создаем первый телевизор

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Задать параметры первого телевизора");
                Console.WriteLine("2. Вывести свойства первого телевизора");
                Console.WriteLine("3. Выполнить статический метод");
                Console.WriteLine("4. Включить телевизор");
                Console.WriteLine("5. Посмотреть телевизор");
                Console.WriteLine("6. Выключить телевизор"); 
                Console.WriteLine("7. Сравнить два телевизора"); 
                Console.WriteLine("8. Увеличить цену первого телевизора");
                Console.WriteLine("9. Выход");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Введите марку первого телевизора: ");
                        tv1.Brand = Console.ReadLine();

                        double screenSizeInput;
                        while (true)
                        {
                            Console.Write("Введите диагональ первого телевизора (в дюймах): ");
                            if (double.TryParse(Console.ReadLine(), out screenSizeInput) && screenSizeInput > 0)
                            {
                                tv1.ScreenSize = screenSizeInput;
                                break; // Выход из цикла, если ввод корректный
                            }
                            else
                                Console.WriteLine("Ошибка: введите положительное число для диагонали.");
                        }

                        double priceInput;
                        while (true)
                        {
                            Console.Write("Введите цену первого телевизора (руб): ");
                            if (double.TryParse(Console.ReadLine(), out priceInput) && priceInput >= 0)
                            {
                                tv1.Price = priceInput;
                                break; // Выход из цикла, если ввод корректный
                            }
                            else
                                Console.WriteLine("Ошибка: цена не может быть отрицательной.");
                        }

                        Console.Write("Введите страну первого телевизора: ");
                        tv1.Country = Console.ReadLine();
                        break;

                    case "2":
                        Console.WriteLine(tv1.ToString());
                        break;

                    case "3":
                        Television.ShowAdvice();
                        break;

                    case "4":
                        tv1.TurnOn();
                        break;

                    case "5":
                        tv1.Watch();
                        break;

                    case "6":
                        tv1.TurnOff();
                        break;

                    case "7":
                        // Создаем второй телевизор для сравнения с фиксированными значениями.
                        Television tv2 = new Television("Samsung", 55.0, 15000.0, "South Korea");

                        if (tv1 == tv2)
                            Console.WriteLine("Телевизоры одинаковые.");
                        else
                            Console.WriteLine("Телевизоры разные.");
                        
                        break;

                    case "8":
                        Console.Write("Введите сумму для увеличения цены первого телевизора: ");
                        if (double.TryParse(Console.ReadLine(), out double additionalPrice) && additionalPrice >= 0)
                        {
                            tv1.Price += additionalPrice; // Прямое прибавление к цене первого телевизора
                            Console.WriteLine($"Обновленный первый телевизор: {tv1}"); // Вывод обновленного телевизора
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: введите корректное неотрицательное число.");
                        }
                        break;

                    case "9":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Неправильно введен номер пункта, попробуйте еще раз");
                        break;
                }
            }
        }
    }
}