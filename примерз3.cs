/*Вариант 21. Техника.
Класс для первой части – телевизор.
Варианты свойств: страна-производитель, марка, диагональ, цена.
Варианты методов: посмотреть, включить, выключить, послу-
шать как работает (статический).
Возможные классы иерархии: техника (базовый), телефон, науш-
ники, патефон. .
Возможный интерфейс: IListenable дополнительный класс – собака. */


using System;
using System.Collections.Generic;

namespace pr1_3
{
    public interface IDevice
    {
        void TurnOn();
        void TurnOff();
        void ShowInfo();
        void PrintClassName();
    }

    // Базовый класс Device, реализующий IDevice
    public abstract class Device : IDevice
    {
        protected double screen_size;
        protected string brand;
        protected double price;
        protected string country;

        public Device(double screen_size, string brand, double price, string country)
        {
            this.screen_size = screen_size;
            this.brand = brand;
            this.price = price;
            this.country = country;
        }

        public virtual void TurnOn()
        {
            Console.WriteLine($"{brand} включен.");
        }

        public virtual void TurnOff()
        {
            Console.WriteLine($"{brand} выключен.");
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Бренд: {brand}, Размер экрана: {screen_size} дюймов, Цена: {price}, Страна: {country}");
            PrintClassName();
        }
        public virtual void PrintClassName()
        {
            Console.WriteLine("Техника");
        }
    }

    // Класс Television
    public class Television : Device
    {
        public Television(double screen_size, string brand, double price, string country)
            : base(screen_size, brand, price, country)
        {
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Это телевизор.");
        }
        public override void PrintClassName()
        {
            Console.WriteLine("Имя класса: Телевизор");
        }
        // Уникальный метод для телевизора
        public void ChangeChannel(int channel)
        {
            Console.WriteLine($"Канал переключен на {channel}.");
        }
    }

    // Класс Phone
    public class Phone : Device
    {
        private string operatingSystem;

        public Phone(double screen_size, string brand, double price, string country, string operatingSystem)
            : base(screen_size, brand, price, country)
        {
            this.operatingSystem = operatingSystem;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Операционная система: {operatingSystem}");
            Console.WriteLine("Это телефон.");
        }
        public override void PrintClassName()
        {
            Console.WriteLine("Имя класса: Телефон");
        }
        // Уникальный метод для телефона
        public void MakeCall(string number)
        {
            Console.WriteLine($"Звонок на номер {number}.");
        }
    }

    // Класс Headphones
    public class Headphones : Device
    {
        private bool isWireless;

        public Headphones(double screen_size, string brand, double price, string country, bool isWireless)
            : base(screen_size, brand, price, country)
        {
            this.isWireless = isWireless;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Беспроводные: {(isWireless ? "Да" : "Нет")}");
            Console.WriteLine("Это наушники.");
        }
        public override void PrintClassName()
         {
             Console.WriteLine("Имя класса: Наушники");
         }
        // Уникальный метод для наушников
        public void AdjustVolume(int level)
        {
            Console.WriteLine($"Громкость установлена на уровень {level}.");
        }
    }

    // Новый класс Dog, не входящий в иерархию
    public class Dog : IDevice
    {
         private string name;

         public Dog(string name)
         {
             this.name = name;
         }

         public void TurnOn()
         {
             Console.WriteLine($"{name} просыпается.");
         }

         public void TurnOff()
         {
             Console.WriteLine($"{name} засыпает.");
         }

         public void ShowInfo()
         {
             Console.WriteLine($"Собака по имени: {name}");
             Console.WriteLine("Это собака.");
         }
        public void PrintClassName()
         {
             Console.WriteLine("Имя класса: Собака");
         }
         // Уникальный метод для собаки
         public void FetchBall()
         {
             Console.WriteLine($"{name} приносит мяч.");
         }
     }

     // класс Патефон
     public class Patophone : Device
     {
         private int speed;

         public Patophone(double screen_size, string brand, double price, string country, int speed)
             : base(screen_size, brand, price, country)
         {
             this.speed = speed;
         }

         public override void ShowInfo()
         {
             base.ShowInfo();
             Console.WriteLine($"Скорость: {speed} об/мин");
             Console.WriteLine("Это патефон.");
         }
        public override void PrintClassName()
         {
             Console.WriteLine("Имя класса: Патефон");
         }
         // Уникальный метод для патефона
         public void PlayRecord()
         {
             Console.WriteLine("Патефон проигрывает пластинку.");
         }
     }

     internal class Program
     {
         static void Main(string[] args)
         {
             List<IDevice> devices = new List<IDevice>();
             bool exit = false;

             while (!exit)
             {
                 Console.WriteLine("\nМеню:");
                 Console.WriteLine("1. Добавить новый объект");
                 Console.WriteLine("2. Вывести свойства объекта");
                 Console.WriteLine("3. Выполнить методы объекта");
                 Console.WriteLine("4. Вывести все объекты в списке");
                 Console.WriteLine("5. Выполнить функцию с объектом");
                 Console.WriteLine("6. Выход");
                 Console.Write("Выберите пункт меню: ");

                 int choice;
                 while (!int.TryParse(Console.ReadLine(), out choice))
                 {
                     Console.Write("Введите корректное число: ");
                 }

                 switch (choice)
                 {
                     case 1:
                         Console.WriteLine("Выберите тип объекта:");
                         Console.WriteLine("1. Телевизор");
                         Console.WriteLine("2. Телефон");
                         Console.WriteLine("3. Наушники");
                         Console.WriteLine("4. Собака");
                         Console.WriteLine("5. Патефон");

                         int typeChoice;
                         while (!int.TryParse(Console.ReadLine(), out typeChoice))
                         {
                             Console.Write("Введите корректное число: ");
                         }

                         switch (typeChoice)
                         {
                             case 1:
                                string tvModel = "";
                                while (string.IsNullOrWhiteSpace(tvModel))
                                {
                                    Console.Write("Введите модель телевизора: ");
                                    tvModel = Console.ReadLine();
                                    if (string.IsNullOrWhiteSpace(tvModel)) Console.WriteLine("назовите модель телевизора все-таки..");
                                }

                                double tvPrice;
                                while (true)
                                {
                                    Console.Write("Введите цену телевизора: ");
                                    if (double.TryParse(Console.ReadLine(), out tvPrice)) break;
                                    else Console.WriteLine("Введите корректное число для цены.");
                                }

                                double tvScreenSize;
                                while (true)
                                {
                                    Console.Write("Введите размер экрана телевизора (дюймы): ");
                                    if (double.TryParse(Console.ReadLine(), out tvScreenSize)) break;
                                    else Console.WriteLine("Введите корректное число для размера экрана.");
                                }

                                string tvCountry = "";
                                while (string.IsNullOrWhiteSpace(tvCountry))
                                {
                                    Console.Write("Введите страну производства телевизора: ");
                                    tvCountry = Console.ReadLine();
                                    if (string.IsNullOrWhiteSpace(tvCountry)) Console.WriteLine("Страна производства не может быть пустой.");
                                }

                                devices.Add(new Television(tvScreenSize, tvModel, tvPrice, tvCountry));
                                break;

                             case 2:
                                // Ввод данных телефона.
                                Console.Write("Введите производителя телефона: ");
                                string phoneManufacturer = Console.ReadLine();

                                // Проверка на пустой ввод производителя
                                while (string.IsNullOrWhiteSpace(phoneManufacturer))
                                {
                                    Console.Write("Производитель не может быть пустым. Пожалуйста, введите производителя телефона: ");
                                    phoneManufacturer = Console.ReadLine();
                                }

                                Console.Write("Введите модель телефона: ");
                                string phoneModel = Console.ReadLine();

                                // Проверка на пустой ввод модели
                                while (string.IsNullOrWhiteSpace(phoneModel))
                                {
                                    Console.Write("Модель не может быть пустой. Пожалуйста, введите модель телефона: ");
                                    phoneModel = Console.ReadLine();
                                }

                                double phonePrice;
                                while (true)
                                {
                                    Console.Write("Введите цену телефона: ");
                                    if (double.TryParse(Console.ReadLine(), out phonePrice) && phonePrice > 0) break;
                                    else Console.WriteLine("Введите корректное положительное число для цены.");
                                }

                                // Ввод операционной системы телефона.
                                string phoneOS = "";
                                while (string.IsNullOrWhiteSpace(phoneOS))
                                {
                                    Console.Write("Введите операционную систему телефона: ");
                                    phoneOS = Console.ReadLine();
                                    if (string.IsNullOrWhiteSpace(phoneOS))
                                        Console.WriteLine("Операционная система не может быть пустой строкой.");
                                }

                                // Добавляем телефон в список устройств
                                devices.Add(new Phone(6.0, phoneManufacturer, phonePrice, phoneManufacturer, phoneOS));
                                break;

                             case 3:
                                // Ввод данных наушников.
                                double headphonesScreenSize = 0; // Не требуется размер экрана для наушников.
                                bool isWireless;

                                while (true)
                                {
                                    Console.Write("Введите беспроводные наушники? (true/false): ");
                                    if (bool.TryParse(Console.ReadLine(), out isWireless)) break;
                                    else Console.WriteLine("Введите корректное значение.");
                                }

                                // Ввод бренда наушников
                                Console.Write("Введите бренд наушников: ");
                                string headphonesBrand = Console.ReadLine();

                                // Проверка на пустой ввод бренда
                                while (string.IsNullOrWhiteSpace(headphonesBrand))
                                {
                                    Console.Write("Бренд не может быть пустым. Пожалуйста, введите бренд наушников: ");
                                    headphonesBrand = Console.ReadLine();
                                }

                                // Ввод производителя наушников, который также будет страной производства
                                Console.Write("Введите производителя наушников: ");
                                string headphonesManufacturer = Console.ReadLine();

                                // Проверка на пустой ввод производителя
                                while (string.IsNullOrWhiteSpace(headphonesManufacturer))
                                {
                                    Console.Write("Производитель не может быть пустым. Пожалуйста, введите производителя наушников: ");
                                    headphonesManufacturer = Console.ReadLine();
                                }

                                double headphonesPrice;
                                while (true)
                                {
                                    Console.Write("Введите цену наушников: ");
                                    if (double.TryParse(Console.ReadLine(), out headphonesPrice) && headphonesPrice > 0) break;
                                    else Console.WriteLine("Введите корректное положительное число для цены.");
                                }

                                // Добавляем наушники в список устройств
                                devices.Add(new Headphones(headphonesScreenSize,headphonesBrand, headphonesPrice,headphonesManufacturer, 
                                    isWireless));

                                break;

                             case 4:
                                  // Ввод имени собаки.
                                  Console.WriteLine ("введите имя собаки:");
                                  string dogName = Console.ReadLine();
                                  devices.Add(new Dog(dogName));
                                  break;

                             case 5:
                                  // Ввод данных патефона.
                                  Console.WriteLine ("введите бренд патефона:");
                                  string patophoneBrand = Console.ReadLine();

                                  Console.WriteLine ("введите модель патефона:");
                                  string patophoneModel = Console.ReadLine();

                                  double patophonePrice; 
                                  while (true) 
                                  { 
                                      Console.WriteLine ("введите цену патефона:");
                                      if (double.TryParse(Console.ReadLine(), out patophonePrice)) break; 
                                      else Console.WriteLine ("введите корректное число для цены."); 
                                   } 

                                   Console.WriteLine ("введите страну производителя патефона:");
                                   string patophoneCountry = Console.ReadLine();

                                   int patophoneSpeed; 
                                   while (true) 
                                   { 
                                       Console.WriteLine ("введите скорость патефона (об/мин):");
                                       if (int.TryParse(Console.ReadLine(), out patophoneSpeed)) break; 
                                       else Console.WriteLine ("введите корректное число для скорости."); 
                                    } 

                                    devices.Add(new Patophone(patophoneSpeed, patophoneBrand, patophonePrice,patophoneCountry,
                                        patophoneSpeed));
                                    break;

                             default:
                                  Console.WriteLine ("неправильный выбор.");
                                  break;
                         }
                         break;

                     case 2:
                         if (devices.Count == 0)
                         {
                             Console.WriteLine ("список пуст.");
                         }
                         else
                         {
                             for (int i = 0; i < devices.Count; i++)
                             {
                                Console.WriteLine ($"{i + 1}. {devices[i].GetType().Name}");
                             }
                             Console.WriteLine ("выберите объект для вывода свойств: ");
                             int index = Convert.ToInt32(Console.ReadLine()) - 1;

                             if (index >= 0 && index < devices.Count)
                             {
                                devices[index].ShowInfo();
                             }
                             else
                             {
                                Console.WriteLine ("неправильный индекс.");
                             }
                         }
                         break;

                     case 3:
                         if (devices.Count == 0)
                         {
                             Console.WriteLine ("список пуст.");
                         }
                         else
                         {
                             for (int i = 0; i < devices.Count; i++)
                             {
                                Console.WriteLine ($"{i + 1}. {devices[i].GetType().Name}");
                             }
                             Console.WriteLine ("выберите объект для выполнения методов: ");
                             int index = Convert.ToInt32(Console.ReadLine()) - 1;

                             if (index >= 0 && index < devices.Count)
                             {
                                devices[index].TurnOn(); // Включаем устройство.
                                
                                switch (devices[index])
                                {
                                    case Television tv:
                                        tv.ChangeChannel(5); // Пример вызова уникального метода для телевизора.
                                        break;
                                    case Phone phone:
                                        phone.MakeCall("+123456789"); // Пример вызова уникального метода для телефона.
                                        break;
                                    case Headphones hp:
                                        hp.AdjustVolume(10); // Пример вызова уникального метода для наушников.
                                        break;
                                    case Dog dog:
                                        dog.FetchBall(); // Пример вызова уникального метода для собаки.
                                        break;
                                    case Patophone patophone:
                                        patophone.PlayRecord(); // Пример вызова уникального метода для патефона.
                                        break;
                                    default:
                                        Console.WriteLine ("неизвестный тип устройства");
                                        break;
                                }
                                
                                devices[index].TurnOff(); // Выключаем устройство.
                             }
                             else
                             {
                                Console.WriteLine ("неправильный индекс.");
                             }
                         }
                         break;

                     case 4:
                         if (devices.Count == 0)
                         {
                            Console.WriteLine ("список пуст.");
                         }
                         else
                         {
                            foreach (var device in devices)
                            {
                                device.ShowInfo();
                            }
                        }
                        break;

                    case 5: /* функция */
                        if (devices.Count == 0)
                        {
                            Console.WriteLine("Список устройств пуст.");
                        }
                        else
                        {
                            Console.WriteLine("Список устройств:");
                            for (int i = 0; i < devices.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {devices[i].GetType().Name}");
                            }

                            Console.Write("Выберите устройство для выполнения функций: ");
                            int index = Convert.ToInt32(Console.ReadLine()) - 1;

                            if (index >= 0 && index < devices.Count)
                            {
                                ExecuteDeviceFunctions(devices[index]);
                            }
                            else
                            {
                                Console.WriteLine("Неправильный индекс.");
                            }
                        }
                        break;

                        
                    case 6:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine ("неправильный выбор. Пожалуйста выберите снова.");
                        break;
                }
             }
         }
        static void ExecuteDeviceFunctions(IDevice device)
      {
          if (device != null)
          {
              device.TurnOn();
              device.ShowInfo();
              device.TurnOff();
          }
          else
          {
              Console.WriteLine("Устройство не создано.");
          }
      }
     }
}