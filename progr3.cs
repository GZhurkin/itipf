using System;
using System.Collections.Generic;

namespace TreeProject
{
    // Интерфейс IGrowable
    public interface IGrowable
    {
        void Grow();
        void ShowInfo();
        void PrintClassName();
    }

    // Базовый класс Tree, реализующий IGrowable
    public abstract class Tree : IGrowable
    {
        protected int age;
        protected double height;
        protected string health;
        protected int fruitCount;

        public Tree(int age, double height, string health, int fruitCount)
        {
            this.age = age;
            this.height = height;
            this.health = health;
            this.fruitCount = fruitCount;
        }

        public virtual void Grow()
        {
            height += 0.5;
            age++;
            Console.WriteLine($"{GetType().Name} растет. Возраст: {age}, Высота: {height} м.");
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Возраст: {age}, Высота: {height} м, Здоровье: {health}, Количество плодов: {fruitCount}");
            PrintClassName();
        }

        public abstract void Harvest();
        public virtual void PrintClassName()
        {
            Console.WriteLine("Техника");
        }
    }

    // Класс LemonTree
    public class LemonTree : Tree
    {
        public LemonTree(int age, double height, string health, int fruitCount)
            : base(age, height, health, fruitCount) {}

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Это лимонное дерево.");
        }

        public override void PrintClassName()
        {
            Console.WriteLine("Имя класса: Лимонное дерево");
        }

        public override void Harvest()
        {
            Console.WriteLine($"Собрано {fruitCount} лимонов.");
            fruitCount = 0;
        }

        public static void PlayMusic()
        {
            Console.WriteLine("Играется вдохновляющая музыка для роста лимонного дерева.");
        }
    }

    // Класс CherryTree
    public class CherryTree : Tree
    {
        public CherryTree(int age, double height, string health, int fruitCount)
            : base(age, height, health, fruitCount) {}

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Это вишня.");
        }

        public override void PrintClassName()
        {
            Console.WriteLine("Имя класса: Вишня");
        }

        public override void Harvest()
        {
            Console.WriteLine($"Собрано {fruitCount} вишен.");
            fruitCount = 0;
        }
    }

    // Класс AppleTree
    public class AppleTree : Tree
    {
        public AppleTree(int age, double height, string health, int fruitCount)
            : base(age, height, health, fruitCount) {}

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Это яблоня.");
        }

        public override void PrintClassName()
        {
            Console.WriteLine("Имя класса: Яблоня");
        }

        public override void Harvest()
        {
            Console.WriteLine($"Собрано {fruitCount} яблок.");
            fruitCount = 0;
        }
    }

    // Sealed класс MapleTree
    public sealed class MapleTree : Tree
    {
        public MapleTree(int age, double height, string health)
            : base(age, height, health, 0) {}

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Это клён.");
        }

        public override void PrintClassName()
        {
            Console.WriteLine("Имя класса: Клён");
        }

        public override void Harvest()
        {
            Console.WriteLine("Клён не даёт плодов.");
        }
    }

    // Класс Watermelon (Арбуз), не входящий в иерархию деревьев
    public class Watermelon : IGrowable
    {
        private double weight;

        public Watermelon(double weight)
        {
            this.weight = weight;
        }

        public void Grow()
        {
            weight += 0.5;
            Console.WriteLine($"Арбуз растет. Вес: {weight} кг.");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Арбуз весит {weight} кг.");
        }

        public void PrintClassName()
        {
            Console.WriteLine("Имя класса: Арбуз");
        }

        public void Eat()
        {
            Console.WriteLine("Арбуз съеден.");
        }
    }

    internal class Program
    {
        static List<IGrowable> growables = new List<IGrowable>();

        static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Добавить новый объект");
                Console.WriteLine("2. Вывести свойства объекта");
                Console.WriteLine("3. Выполнить методы объекта");
                Console.WriteLine("4. Вывести все объекты в списке");
                Console.WriteLine("5. Выполнить функцию с объектом");
                Console.WriteLine("6. Выход");
                Console.Write("Выберите пункт меню: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddNewObject();
                        break;
                    case "2":
                        ShowObjectInfo();
                        break;
                    case "3":
                        ExecuteObjectMethods();
                        break;
                    case "4":
                        ShowAllObjects();
                        break;
                    case "5":
                        ExecuteFunctionWithObject();
                        break;
                    case "6":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
        }

        static void AddNewObject()
        {
            Console.WriteLine("Выберите тип объекта:");
            Console.WriteLine("1. Лимонное дерево");
            Console.WriteLine("2. Вишня");
            Console.WriteLine("3. Яблоня");
            Console.WriteLine("4. Клён");
            Console.WriteLine("5. Арбуз");

            switch (Console.ReadLine())
            {
                case "1":
                    growables.Add(new LemonTree(5, 2.5, "Хорошее", 10));
                    break;
                case "2":
                    growables.Add(new CherryTree(3, 2.0, "Среднее", 30));
                    break;
                case "3":
                    growables.Add(new AppleTree(4, 3.5, "Отличное", 15));
                    break;
                case "4":
                    growables.Add(new MapleTree(7, 4.0, "Здоровое"));
                    break;
                case "5":
                    growables.Add(new Watermelon(1.5));
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }

        static void ShowObjectInfo()
        {
            if (growables.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            for (int i = 0; i < growables.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {growables[i].GetType().Name}");
            }

            Console.Write("Выберите объект для вывода свойств: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= growables.Count)
            {
                growables[index - 1].ShowInfo();
            }
            else
            {
                Console.WriteLine("Неверный выбор.");
            }
        }

        static void ExecuteObjectMethods()
        {
            if (growables.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            for (int i = 0; i < growables.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {growables[i].GetType().Name}");
            }

            Console.Write("Выберите объект для выполнения методов: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= growables.Count)
            {
                IGrowable growable = growables[index - 1];
                growable.Grow();

                switch (growable)
                {
                    case LemonTree lemon:
                        lemon.Harvest();
                        LemonTree.PlayMusic();
                        break;
                    case CherryTree cherry:
                        cherry.Harvest();
                        break;
                    case AppleTree apple:
                        apple.Harvest();
                        break;
                    case Watermelon watermelon:
                        watermelon.Eat();
                        break;
                    default:
                        Console.WriteLine("Неизвестный тип объекта.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Неверный выбор.");
            }
        }

        static void ShowAllObjects()
        {
            if (growables.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            foreach (var growable in growables)
            {
                growable.ShowInfo();
            }
        }

        static void ExecuteFunctionWithObject()
        {
            if (growables.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            Console.Write("Выберите объект для выполнения функции: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= growables.Count)
            {
                IGrowable growable = growables[index - 1];
                growable.Grow();
            }
            else
            {
                Console.WriteLine("Неверный выбор.");
            }
        }
    }
}
