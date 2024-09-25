using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;
using Microsoft.Win32.SafeHandles;
using SwitcherSpace;
using static System.Net.Mime.MediaTypeNames;

namespace PRACTIC_1
{
    internal class Program
    {
        static List<ITools> tools = new List<ITools>();

        static void Main(string[] args)
        {
            bool isRunning = true;
            while(isRunning)
            {
                Console.Clear();
                Console.WriteLine("1. Задание 1");
                Console.WriteLine("2. Задание 2");
                Console.WriteLine("3. Задание 3");
                Console.WriteLine("0. Выход из программы");
                Console.Write("Выберите действие: ");

                switch(Console.ReadLine())
                {
                    case "1":
                        Menu_1();
                        break;

                    case "2":
                        Menu_2();
                        break;

                    case "3":
                        Menu_3();
                        break;

                    case "0":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Неверный выбор действия");
                        break;
                }
            }
        }

        static void Menu_1() // меню для 1-ого задания
        {
            Console.Clear();
            Switcher? switcher = null;

            string? text, eventName, color;
            ushort size;
            bool state_swc;

            ushort new_size;

            bool isRunning = true;
            while(isRunning)
            {
                Console.Clear();
                Console.WriteLine("1. Создать переключатель без параметров");
                Console.WriteLine("2. Создать переключатель с текстом, событием и размером");
                Console.WriteLine("3. Создать переключатель со всеми параметрами");
                Console.WriteLine("4. Вывести свойства переключателя (ToString)");
                Console.WriteLine("5. Вывести дефолтный размер переключателя (статический метод)");
                Console.WriteLine("6. Переключить состояние (вкл\\выкл)");
                Console.WriteLine("7. Показать связанное событие");
                Console.WriteLine("8. Изменить размер");
                Console.WriteLine("9. Создать еще один переключатель без параметров и сравнить с текущим");
                Console.WriteLine("10. Увеличить размер с помощью бинарного +");
                Console.WriteLine("0. Назад в главное меню");

                switch(Console.ReadLine())
                {
                    case "1":
                        switcher = new Switcher();
                        Console.WriteLine("Переключатель создан");
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.Write("Введите текст: ");
                        text = Console.ReadLine();

                        Console.Write("Введите событие: ");
                        eventName = Console.ReadLine();

                        Console.Write("Введите размер: ");
                        if(!ushort.TryParse(Console.ReadLine(), out size)) // проверка ввода
                        {
                           Console.WriteLine("Неверный ввод, возвращение в главное меню!");
                           Console.ReadLine();
                           isRunning = false;
                           break;
                        }

                        switcher = new Switcher(text, eventName, size);
                        Console.WriteLine("Переключатель создан");
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Write("Введите текст: ");
                        text = Console.ReadLine();

                        Console.Write("Введите событие: ");
                        eventName = Console.ReadLine();

                        Console.Write("Введите размер: ");
                        if (!ushort.TryParse(Console.ReadLine(), out size)) // проверка ввода
                        {
                            Console.WriteLine("Неверный ввод, возвращение в главное меню!");
                            Console.ReadLine();
                            isRunning = false;
                            break;
                        }

                        Console.Write("Введите цвет: ");
                        color = Console.ReadLine();

                        Console.Write("Введите состояние: ");
                        if(!bool.TryParse(Console.ReadLine(), out state_swc))
                        {
                            Console.WriteLine("Неверный ввод, возвращение в главное меню!");
                            Console.ReadLine();
                            isRunning = false;
                            break;
                        }

                        switcher = new Switcher(text, eventName, size,color, state_swc);
                        Console.WriteLine("Переключатель создан");
                        
                        Console.ReadLine();
                        break;

                    case "4":
                        string? info_str = switcher.ToString();
                        Console.WriteLine(info_str);
                        
                        Console.ReadLine();
                        break;

                    case "5":
                        Console.WriteLine(Switcher.GetDefaultSize());
                        Console.ReadLine();
                        break;

                    case "6":
                        switcher.ToggleState();
                        Console.ReadLine();
                        break;

                    case "7":
                        switcher.InvokeEvent();
                        Console.ReadLine();
                        break;

                    case "8":
                        Console.Write("Введите новый размер: ");
                        if (!ushort.TryParse(Console.ReadLine(), out new_size))
                        {
                            Console.WriteLine("Неверный ввод, возвращение в главное меню!");
                            Console.ReadLine();
                            isRunning = false;
                            break;
                        }

                        switcher.ChangeSize(new_size);
                      
                        Console.ReadLine();
                        break;

                    case "9":
                            Switcher temp_switcher = new Switcher();
                            Console.WriteLine("Свойства второго временного переключателя:");
                            Console.WriteLine(temp_switcher.ToString());

                            Console.WriteLine("Свойства основного переключателя:");
                            Console.WriteLine(switcher.ToString());

                            if (switcher == temp_switcher)
                            {
                                Console.WriteLine("Переключатели одинаковые");
                            }
                            else
                            {
                                Console.WriteLine("Переключатели разные");
                            }
                        
                        Console.ReadLine();
                        break;

                    case "10":
                            Console.Write("Введите новый размер: ");
                            if (!ushort.TryParse(Console.ReadLine(), out new_size))
                            {
                                Console.WriteLine("Неверный ввод, возвращение в главное меню!");
                                Console.ReadLine();
                                isRunning = false;
                                break;
                            }

                            switcher = switcher + new_size;
                            Console.WriteLine($"switcher + {new_size} = Новый размер - {switcher.Size}");
                        
                        
                        Console.ReadLine();
                        break;

                    case "0":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Невернный выбор, попробуйте еще раз!");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void Menu_2()
        {
            Console.Clear();

            Switcher? switcher = null;
            TextField? textField = null;
            Slider? slider = null;
            Button? button = null;

            bool isRunning = true;

            ushort newSpeed;

            while(isRunning)
            {
                Console.Clear();
                Console.WriteLine("1. Создать объекты с заранее подготовленными параметрами");
                Console.WriteLine("2. Показать свойства созданных объектов");
                Console.WriteLine("3. Выполнить методы объектов");
                Console.WriteLine("4. Вывести имя класса у объектов");
                Console.WriteLine("0. Назад");

                switch(Console.ReadLine())
                {
                    case "1":
                        switcher = new Switcher("on\\off", "переключает фон", 15, "green", true);
                        textField = new TextField("какой-то текст", "оглавление", 10, "white", 100);
                        slider = new Slider("slide this", "передвижение иконки", 5, "yellow", 52);
                        button = new Button("кнопка фона", "включение подсветки", 10, "brown", false);

                        Console.WriteLine("Объекты созданы");

                        Console.ReadLine();
                        break;

                    case "2":
                            Console.WriteLine(switcher.ToString());
                            Console.WriteLine(textField.ToString());
                            Console.WriteLine(slider.ToString());
                            Console.WriteLine(button.ToString());
                        
                        Console.ReadLine();
                        break;

                    case "3":
                        
                            Console.WriteLine(switcher.Text + ":");
                            switcher.InvokeEvent();
                            switcher.ToggleState();
                            Switcher.GetDefaultSize();

                            Console.WriteLine("\n" + textField.Text + ":");
                            textField.ShowWidthField();

                            Console.WriteLine("\n" + slider.Text + ":");
                            Console.Write("Введите скорость: ");
                            while(!ushort.TryParse(Console.ReadLine(), out newSpeed))
                            {
                                Console.WriteLine("Вводите корректно!");
                            }
                        slider.ChangeSpeed(newSpeed);

                        Console.WriteLine("\n" + button.Text + ":");
                        button.Activate();

                        Console.ReadLine();
                        break;

                    case "4":
                        Console.WriteLine(switcher.GetClassName());
                        Console.WriteLine(textField.GetClassName());
                        Console.WriteLine(slider.GetClassName());
                        Console.WriteLine(button.GetClassName());
                        
                        Console.ReadLine();
                        break;

                    case "0":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Невернный выбор, попробуйте еще раз!");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void Menu_3()
        {
            Console.Clear();

            bool isRunning = true;

            while(isRunning)
            {
                Console.Clear();
                Console.WriteLine("1. Добавить объект в список");
                Console.WriteLine("2. Вывести свойства объекта из списка");
                Console.WriteLine("3. Выполнить методы объекта из списка");
                Console.WriteLine("4. Вывод всех объектов в списке с указанием их классов");
                Console.WriteLine("5. Выполнить функцию с объектом из списка");
                Console.WriteLine("0. Назад");

                switch(Console.ReadLine())
                {
                    case "1":
                        AddObjectList();
                        Console.ReadLine();
                        break;

                    case "2":
                        DisplayObjectProperties();
                        Console.ReadLine();
                        break;

                    case "3":
                        ExecuteObjectMethodsList();
                        Console.ReadLine();
                        break;

                    case "4":
                        DisplayAllObjectsList();
                        Console.ReadLine();
                        break;

                    case "5":
                        ExecuteFunctionWithObject();
                        Console.ReadLine();
                        break;

                    case "0":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Невернный выбор, попробуйте еще раз!");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void AddObjectList()
        {
            Console.Clear();
            Console.WriteLine("Выберите объект для добавления:");
            Console.WriteLine("1. Переключатель");
            Console.WriteLine("2. Текстовое поле");
            Console.WriteLine("3. Слайдер");
            Console.WriteLine("4. Кнопка");
            Console.WriteLine("5. Гаджет");

            switch(Console.ReadLine())
            {
                case "1":
                    tools.Add(new Switcher("on\\off", "переключает фон", 15, "green", true));
                    break;

                case "2":
                    tools.Add(new TextField("какой-то текст", "оглавление", 10, "white", 100));
                    break;

                case "3":
                    tools.Add(new Slider("slide this", "передвижение иконки", 5, "yellow", 52));
                    break;

                case "4":
                    tools.Add(new Button("кнопка фона", "включение подсветки", 10, "brown", false));
                    break;

                case "5":
                    tools.Add(new Gadget("IPhone 16", "Apple"));
                    break;

                default:
                    Console.WriteLine("Неверный выбор");
                    return;
            }

            Console.WriteLine($"Объект {tools[^1].GetClassName()} добавлен в список");
        }

        static void DisplayObjectProperties()
        {
            ITools? tool = SelectObjectList();
            if(tool != null)
            {
                Console.WriteLine(tool.ToString());
            }
        }

        static ITools? SelectObjectList()
        {
            if(tools.Count == 0)
            {
                Console.WriteLine("Список пуст");
                return null;
            }

            Console.WriteLine("Выберите объект по номеру:");
            for(int i = 0; i < tools.Count; ++i)
            {
                Console.WriteLine($"{i + 1}. {tools[i].GetClassName()} - {tools[i].GetObjectName()}");
            }

            if(ushort.TryParse(Console.ReadLine(), out ushort index) && index > 0 && index <= tools.Count)
            {
                return tools[index - 1];
            }

            Console.WriteLine("Неверный выбор");
            return null;
        }

        static void ExecuteObjectMethodsList()
        {
            ITools? tool = SelectObjectList();
            if (tool != null)
                tool.Compliment();
        }

        static void DisplayAllObjectsList()
        {
            if(tools.Count == 0)
            {
                Console.WriteLine("Список пуст!");
                return;
            }

            Console.WriteLine("Объекты в списке:");
            for(int i = 0; i < tools.Count; ++i)
            {
                Console.WriteLine($"{tools[i].GetClassName()} - {tools[i].GetObjectName()}");
            }
        }

        static void ShowToolAdvice(ITools tool) // функция принимающая объект любого класса, реализ. интерф.
        {
            tool.UsageAdvice();
        }

        static void ExecuteFunctionWithObject()
        {
            ITools? tool = SelectObjectList();
            if(tool != null)
                ShowToolAdvice(tool);
        }
    }
}

namespace SwitcherSpace
{
    public interface ITools
    {
        string ToString();
        void Compliment();
        void UsageAdvice();
        string? GetClassName();
        string? GetObjectName();
    }

    abstract internal class InterfaceElement : ITools // абстрактный базовый класс 
    {
        public static readonly ushort defaultSize = 10; // дефолтный размер каждого элемента интерфейса
        public string? Text { get; private set; } // текст на интерфейсе
        public string? Event { get; private set; } // название связанного события
        public ushort Size { get; private set; } // размер интерфейса
        public string? Color { get; private set; } // цвет


        public InterfaceElement()
        {
            Text = "Текст не указан";
            Event = "Событие не указано";
            Size = defaultSize;
            Color = "Цвет не указан";
        }
        public InterfaceElement(string? text, string? eventName, ushort size)
        {
            Text = text;
            Event = eventName;
            Size = size;
            Color = "Цвет не указан";
        }
        public InterfaceElement(string? text, string? eventName, ushort size, string? color)
        {
            Text = text;
            Event = eventName;
            Size = size;
            Color = color;
        }


        public void ChangeText(string? newText) // изменить текст
        {
            string? oldText = newText;
            Text = newText;
            Console.WriteLine($"Текст изменен с \"{oldText}\" на \"{Text}\"");
        }
        public void ChangeEvent(string? newEvent) // изменить связанное событие
        {
            string? oldEvent = newEvent;
            Event = newEvent;
            Console.WriteLine($"Событие изменено с \"{oldEvent}\" на \"{Event}\"");
        }
        public void ChangeSize(ushort newSize) // изменить размер (метод из условия к 1 заданию вынесен сюда)
        {
            ushort oldSize = Size;
            Size = newSize;
            Console.WriteLine($"Размер изменен с {oldSize} на {Size}");
        }
        public void ChangeColor(string? newColor) // изменить цвет
        {
            string? oldColor = newColor;
            Color = newColor;
            Console.WriteLine($"Цвет изменен с \"{oldColor}\" на \"{Color}\"");
        }

        public virtual void Compliment()
        {
            Console.WriteLine($"Ваш интерфейс \"{Text}\" красивый");
        }
        public virtual void UsageAdvice()
        {
            Console.WriteLine("Совет по использованию интерфейса: нет");
        }
        public virtual string? GetClassName()
        {
            return "InterfaceElement";
        }

        public string? GetObjectName()
        {
            return Text;
        }
    }

    sealed internal class Switcher : InterfaceElement
    {
        public bool State { get; private set; } // состояние (on - true / off - false) (уникальное свойство)


        public Switcher() : base()
        {
            State = false;
        }
        public Switcher(string? text, string? eventName, ushort size) : base(text, eventName, size)
        {
            State = false;
        }
        public Switcher(string? text, string? eventName, ushort size, string? color, bool state)
            : base(text, eventName, size, color)
        {
            State = state;
        }


        public void ToggleState() // переключить состояние вкл/выкл
        {
            State = !State;
            Console.WriteLine($"Состояние переключено: {(State ? "Включено" : "Выключено")}");
        }
        public void InvokeEvent() // вызвать связанное событие
        {
            Console.WriteLine($"Событие переключателя: {Event}");
        }
        public static ushort GetDefaultSize() // статический метод, возвращающий базовый размер переключателя
        {
            return defaultSize;
        }
        public override void Compliment()
        {
            Console.WriteLine($"Ваш переключатель \"{Text}\" - красивый");
        }
        public override void UsageAdvice()
        {
            Console.WriteLine("Совет по использованию переключателя: переключайте не часто");
        }
        public override string? GetClassName()
        {
            return $"{base.GetClassName()} - переключатель";
        }

        public override string ToString() // перегрузка базового метода у класса
        {
            return $"Переключатель \"{Text}\":\nСобытие - {Event}\nРазмер - {Size}\n" +
                $"Цвет - {Color}\nСостояние - {(State ? "Включено" : "Выключено")}";
        }

        // перегрузка бинарного + (с помощью него, можно быстро увеличить размер переключателя)
        public static Switcher operator +(Switcher s, ushort additionalSize)
        {
            ushort newSize = (ushort)(s.Size + additionalSize);
            return new Switcher(s.Text, s.Event, newSize, s.Color, s.State);
        }
    
        // перегрузка оператора сравнения
        public static bool ReferenceEquals(Switcher obj_1, Switcher obj_2)
        {
            return obj_1.Text == obj_2.Text && obj_1.Event == obj_2.Event && obj_1.Size == obj_2.Size &&
                obj_1.State == obj_2.State;
        }

        public static bool operator == (Switcher obj_left, Switcher obj_right)
        {
            return obj_left.Size == obj_right.Size && obj_left.Text == obj_right.Text &&
                obj_left.Event == obj_right.Event && obj_left.Color == obj_right.Color &&
                obj_left.State == obj_right.State;
        }

        public static bool operator != (Switcher obj_left, Switcher obj_right)
        {
            return !(obj_left == obj_right);
        }
    }

    sealed internal class TextField : InterfaceElement
    {
        public ushort WidthField { get; private set; } // уникальное свойство

        public TextField(string? text, string? eventName, ushort size, string? color, ushort width)
            : base(text, eventName, size, color)
        {
            WidthField = width;
        }

        // уникальный метод вывода ширины поля
        public void ShowWidthField() => Console.WriteLine($"Ширина поля составляет {WidthField} px");

        public override string ToString() // перегрузка базового метода у класса
        {
            return $"Текстовое поле \"{Text}\":\nСобытие - {Event}\nРазмер - {Size}\n" +
                $"Цвет - {Color}\nШирина поля - {WidthField}";
        }

        public override void Compliment()
        {
            Console.WriteLine($"Ваше текстовое поле \"{Text}\" - красивое");
        }

        public override void UsageAdvice()
        {
            Console.WriteLine("Совет по использованию текстового поля: не выражайтесь)");
        }

        public override string? GetClassName()
        {
            return $"{base.GetClassName()} - текстовое поле";
        }
    }

    sealed internal class Button : InterfaceElement
    {
        public bool IsActivated { get; private set; } // уникальное поле состояния кнопки

        public Button(string? text, string? eventName, ushort size, string? color, bool is_activated)
            : base(text, eventName, size, color)
        {
            IsActivated = is_activated;
        }

        public void Activate() // уникальный метод активации кнопки
        {
            IsActivated = !IsActivated;
            Console.WriteLine($"Кнопка {(IsActivated ? "Включена" : "Выключена")}");
        }

        public override string ToString() // перегрузка базового метода у класса
        {
            return $"Кнопка \"{Text}\":\nСобытие - {Event}\nРазмер - {Size}\n" +
                $"Цвет - {Color}\nАктивация - {(IsActivated ? "Включена" : "Выключена")}";
        }

        public override void Compliment()
        {
            Console.WriteLine($"Ваша кнопка \"{Text}\" - красивая");
        }

        public override void UsageAdvice()
        {
            Console.WriteLine("Совет по использованию кнопки: не тыкайте сильно!");
        }

        public override string? GetClassName()
        {
            return $"{base.GetClassName()} - кнопка";
        }
    }

    sealed internal class Slider : InterfaceElement
    {
        public ushort Speed { get; private set; } // уникальное свойство скорости слайдера

        public Slider(string? text, string? eventName, ushort size, string? color, ushort speed)
            : base(text, eventName, size, color)
        {
            Speed = speed;
        }

        public void ChangeSpeed(ushort speed) // уникальный метод изменения скорости слайдера
        {
            Speed = speed;
            Console.WriteLine($"Установлена скорость слайдера {Speed}");
        }

        public override string ToString() // перегрузка базового метода у класса
        {
            return $"Слайдер \"{Text}\":\nСобытие - {Event}\nРазмер - {Size}\n" +
                $"Цвет - {Color}\nСкорость - {Speed}";
        }

        public override void Compliment()
        {
            Console.WriteLine($"Ваш слайдер \"{Text}\" - красивый");
        }

        public override void UsageAdvice()
        {
            Console.WriteLine("Совет по использованию переключателя: он хрупкий(");
        }

        public override string? GetClassName()
        {
            return $"{base.GetClassName()} - слайдер";
        }
    }

    // класс не входящий в иерархию и реализующий интерфейс
    internal class Gadget : ITools
    {
        public string Model { get; private set; }
        public string Manufacturer { get; private set; }

        public Gadget(string model, string manufacturer)
        {
            Model = model;
            Manufacturer = manufacturer;
        }

        public override string ToString()
        {
            return $"Гаджет \"{Model}\" от производителя \"{Manufacturer}\"";
        }

        public void Compliment()
        {
            Console.WriteLine($"Ваш гаджет \"{Model}\" - отличный выбор!");
        }

        public void UsageAdvice()
        {
            Console.WriteLine("Совет по использованию гаджета: желательно не бейте об стол");
        }
        public string? GetClassName()
        {
            return $"Gadget - гаджет";
        }

        public string? GetObjectName()
        {
            return Model;
        }
    }
}