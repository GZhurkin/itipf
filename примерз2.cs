/*Вариант 21. Техника.
Класс для первой части – телевизор.
Варианты свойств: страна-производитель, марка, диагональ, цена.
Варианты методов: посмотреть, включить, выключить, послу-
шать как работает (статический).
Возможные классы иерархии: техника (базовый), телефон, науш-
ники, патефон. .
Возможный интерфейс: IListenable дополнительный класс – собака. */
using System;

namespace pr1_2
{
    internal class Program
    {
        public abstract class Tech
        {
            protected double screen_size;
            protected string brand;
            protected double price;
            protected string country;

            public double Screen_size
            {
                get { return screen_size; }
                set { screen_size = value; }
            }

            public string Brand
            {
                get { return brand; }
                set { brand = value; }
            }

            public double Price
            {
                get { return price; }
                set { price = value; }
            }

            public string Country
            {
                get { return country; }
                set { country = value; }
            }
            public Tech()
            {
                brand = "Sony";
                screen_size = 42.0;
                price = 10000.0;
                country = "Japan";
            }

            public Tech(string brand, double screen_size, double price, string country)
            {
                this.brand = brand;
                this.screen_size = screen_size;
                this.price = price;
                this.country = country;
            }

            public virtual void PrintClassName()
            {
                Console.WriteLine("Техника");
            }

            public virtual void TurnOn()
            {
                Console.WriteLine($"{brand} is now ON.");
            }

            public virtual void TurnOff()
            {
                Console.WriteLine($"{brand} is now OFF.");
            }
        }

        public class Television : Tech
        {
            private string screenType;

            public string ScreenType
            {
                get { return screenType; }
                set { screenType = value; }
            }

            public Television() : base()
            {
                screenType = "LED";
            }

            public Television(string brand, double screen_size, double price, string country, string screenType)
                : base(brand, screen_size, price, country)
            {
                this.screenType = screenType;
            }

            public override void PrintClassName()
            {
                base.PrintClassName();
                Console.WriteLine("Это Телевизор.");
            }

            public void Watch() // Custom method
            {
                Console.WriteLine($"Смотрю телевизор {brand} с типом экрана {screenType}.");
            }
        }

        // Phone class
        public class Phone : Tech
        {
            private string color;

            public string Color
            {
                get { return color; }
                set { color = value; }
            }

            public Phone() : base()
            {
                color = "Черный"; // Default color
            }

            public Phone(string brand, double screen_size, double price, string country, string color)
                : base(brand, screen_size, price, country)
            {
                this.color = color;
            }

            public override void PrintClassName()
            {
                base.PrintClassName();
                Console.WriteLine("Это объект Телефон.");
            }

            public void Call(string number) // Custom method (review how it works)
            {
                Console.WriteLine($"Звоню на номер {number} с телефона {brand}. Цвет: {color}.");
            }
        }

        // Headphones class
        public class Headphones : Tech
        {
             private bool noiseCancelling;

             public bool NoiseCancelling
             {
                 get { return noiseCancelling; }
                 set { noiseCancelling = value; }
             }

             public Headphones() : base()
             {
                 noiseCancelling = false;
             }

             public Headphones(string brand, double price, string country, bool noiseCancelling)
                 : base(brand, 0.0, price, country)
             {
                 this.noiseCancelling = noiseCancelling;
             }

             public override void PrintClassName()
             {
                 base.PrintClassName();
                 Console.WriteLine("Это объект Наушники.");
             }

             public void Listen() 
             {
                 Console.WriteLine($"Слушаю музыку на наушниках {brand}. Шумоподавление: {(noiseCancelling ? "включено" : "выключено")}.");
             }
         }

         // Gramophone class
         public sealed class Gramophone : Tech
         {
             private int recordCount;

             public int RecordCount
             {
                 get { return recordCount; }
                 set { recordCount = value; }
             }

             public Gramophone() : base()
             {
                 recordCount = 0; 
             }

             public Gramophone(string brand, double price, string country, int recordCount)
                 : base(brand, 0.0, price, country)
             {
                 this.recordCount = recordCount;
             }

             public override void PrintClassName()
             {
                 base.PrintClassName();
                 Console.WriteLine("Это объект Патефон.");
             }

             public void PlayRecord()
             {
                 Console.WriteLine($"Воспроизвожу запись на патефоне {brand}. Всего записей: {recordCount}.");
             }
         }

         static void Main(string[] args)
         {
             Tech device = null;
             bool exit = false;

             while (!exit)
             {
                 Console.WriteLine("\nМеню:");
                 Console.WriteLine("1. Создать устройство");
                 Console.WriteLine("2. Вывести свойства устройства");
                 Console.WriteLine("3. Выполнить методы устройства");
                 Console.WriteLine("4. Вывести имя класса устройства");
                 Console.WriteLine("5. Выход");
                 Console.Write("Выберите пункт меню: ");

                 int choice;

                 while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
                 {
                     Console.WriteLine("Некорректный ввод. Пожалуйста, введите число от 1 до 5.");
                     Console.Write("Выберите пункт меню: ");
                 }

                 switch (choice)
                 {
                     case 1:
                         Console.WriteLine("Выберите тип устройства:");
                         Console.WriteLine("1. Телевизор");
                         Console.WriteLine("2. Телефон");
                         Console.WriteLine("3. Наушники");
                         Console.WriteLine("4. Патефон");
                         Console.Write("Выберите тип устройства: ");

                         int deviceType;
                         while (!int.TryParse(Console.ReadLine(), out deviceType) || deviceType < 1 || deviceType > 4)
                         {
                             Console.WriteLine("Некорректный ввод. Пожалуйста, введите число от 1 до 4.");
                             Console.Write("Выберите тип устройства: ");
                         }

                         switch (deviceType)
                         {
                             case 1:
                                Console.Write("Введите марку телевизора: ");
                                string tvBrand = Console.ReadLine();
                                
                                Console.Write("Введите цену телевизора: ");
                                double tvPrice = GetValidDoubleInput();
                                
                                Console.Write("Введите страну производства телевизора: ");
                                string tvCountry = Console.ReadLine();
                                
                                Console.Write("Введите размер экрана телевизора (в дюймах): ");
                                double tvSize = GetValidDoubleInput();
                                
                                Console.Write("Введите тип экрана (LED/OLED):");
                                string tvScreenType = Console.ReadLine();

                                // Automatically set to "LED" if no valid input is provided
                                if (string.IsNullOrWhiteSpace(tvScreenType) || (tvScreenType != "LED" && tvScreenType != "OLED"))
                                {
                                    tvScreenType = "LED"; // Default to LED without any message
                                }

                                device = new Television(tvBrand, tvSize, tvPrice, tvCountry, tvScreenType);
                                break;

                             case 2:
                                 Console.Write("Введите марку телефона: ");
                                 string phoneBrand = Console.ReadLine();
                                 Console.Write("Введите цену телефона: ");
                                 double phonePrice = GetValidDoubleInput();
                                 Console.Write("Введите страну производства телефона: ");
                                 string phoneCountry = Console.ReadLine();
                                 Console.Write("Введите цвет телефона: ");
                                 string phoneColor = Console.ReadLine();

                                 device = new Phone(phoneBrand, 0.0, phonePrice, phoneCountry, phoneColor);
                                 break;

                             case 3:
                                 Console.Write("Введите марку наушников: ");
                                 string headphonesBrand = Console.ReadLine();
                                 Console.Write("Введите цену наушников: ");
                                 double headphonesPrice = GetValidDoubleInput();
                                 Console.Write("Введите страну производства наушников: ");
                                 string headphonesCountry = Console.ReadLine();
                                 bool noiseCancelling;
                                 while (true)
                                 {
                                     Console.Write("Есть ли шумоподавление? (true/false): ");
                                     if (bool.TryParse(Console.ReadLine(), out noiseCancelling))
                                         break;
                                     else 
                                         Console.WriteLine("Некорректный ввод. Пожалуйста введите true или false.");
                                 }

                                 device = new Headphones(headphonesBrand, headphonesPrice, headphonesCountry, noiseCancelling);
                                 break;

                             case 4:
                                 Console.Write("Введите марку патефона: ");
                                 string gramophoneBrand = Console.ReadLine();
                                 Console.Write("Введите цену патефона: ");
                                 double gramophonePrice = GetValidDoubleInput();
                                 Console.Write("Введите страну производства патефона: ");
                                 string gramophoneCountry = Console.ReadLine();
                                 int recordCount;
                                 while (true)
                                 {
                                     Console.Write("Введите количество записей у патефона: ");
                                     if (int.TryParse(Console.ReadLine(), out recordCount) && recordCount >= 0)
                                         break;
                                     else 
                                         Console.WriteLine("Некорректный ввод. Пожалуйста введите неотрицательное число.");
                                 }

                                 device = new Gramophone(gramophoneBrand, gramophonePrice, gramophoneCountry, recordCount);
                                 break;

                             default:
                                break;
                         }
                         break;

                     case 2:
                         if (device != null)
                         {
                             if (device is Television tv)
                             {
                                Console.WriteLine($"Телевизор - Марка: {tv.Brand}, Цена: {tv.Price}, Страна: {tv.Country}, Размер экрана: {tv.Screen_size} дюймов, Тип экрана: {tv.ScreenType}");
                             }
                             else if (device is Phone phone)
                             {
                                Console.WriteLine($"Телефон - Марка: {phone.Brand}, Цена: {phone.Price}, Страна: {phone.Country}, Цвет: {phone.Color}");
                             }
                             else if (device is Headphones headphones)
                             {
                                Console.WriteLine($"Наушники - Марка: {headphones.Brand}, Цена: {headphones.Price}, Страна: {headphones.Country}, Шумоподавление: {(headphones.NoiseCancelling ? "включено" : "выключено")}");
                             }
                             else if (device is Gramophone gramophone)
                             {
                                Console.WriteLine($"Патефон - Марка: {gramophone.Brand}, Цена: {gramophone.Price}, Страна: {gramophone.Country}, Количество записей: {gramophone.RecordCount}");
                             }
                         } 
                         else 
                         {

                            Console.WriteLine("Сначала создайте устройство."); 
                         } 
                         break;

                     case 3:
                         if (device != null) 
                         {

                             if (device is Television tv) 
                             {
                                tv.TurnOn(); 
                                tv.Watch(); 
                                tv.TurnOff(); 
                             } 
                             else if (device is Phone phone) 
                             {
                                phone.TurnOn(); 
                                phone.Call("123-456-7890");  
                                phone.TurnOff(); 
                             } 
                             else if (device is Headphones headphones) 
                             {
                                headphones.TurnOn(); 
                                headphones.Listen(); 
                                headphones.TurnOff(); 
                             } 
                             else if (device is Gramophone gramophone) 
                             {
                                gramophone.TurnOn(); 
                                gramophone.PlayRecord(); 
                                gramophone.TurnOff(); 
                             } 

                          }  
                          else  
                          {

                            Console.WriteLine("Сначала создайте устройство.");  
                          }  
                          break;

                     case 4:
                        if (device != null) 
                            device.PrintClassName(); 
                        else 
                            Console.WriteLine("Сначала создайте устройство."); 
                        break;

                     case 5:
                        exit = true; 
                        break;

                     default:
                        break; 

                  }  
              }  
          }  

          static double GetValidDoubleInput()
          {
              double result;
              while (true)
              {
                  if (double.TryParse(Console.ReadLine(), out result))
                      return result;
                  else
                      Console.WriteLine("Некорректный ввод. Пожалуйста введите число.");
              }
          }  
      }  
}