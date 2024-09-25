using System;

namespace pr1_2
{
    internal class Program
    {
        // Абстрактный базовый класс Tree (Дерево)
        public abstract class Tree
        {
            protected int age; // Возраст дерева
            protected double height; // Высота дерева
            protected int fruitCount; // Количество плодов

            public int Age
            {
                get { return age; }
                set { age = value; }
            }

            public double Height
            {
                get { return height; }
                set { height = value; }
            }

            public int FruitCount
            {
                get { return fruitCount; }
                set { fruitCount = value; }
            }

            public Tree()
            {
                age = 0;
                height = 1.0;
                fruitCount = 0;
            }

            public Tree(int age, double height, int fruitCount)
            {
                this.age = age;
                this.height = height;
                this.fruitCount = fruitCount;
            }

            // Виртуальный метод для вывода названия класса дерева
            public virtual void PrintClassName()
            {
                Console.WriteLine("Дерево");
            }

            // Виртуальный метод для роста дерева
            public virtual void Grow()
            {
                age++;
                height += 0.5;
                Console.WriteLine($"{GetType().Name} подросло. Текущий возраст: {age}, высота: {height} метров.");
            }

            // Виртуальный метод для сбора плодов
            public virtual void Harvest()
            {
                Console.WriteLine($"Собрано {fruitCount} плодов.");
                fruitCount = 0;
            }
        }

        // Подкласс AppleTree (Яблоня)
        public class AppleTree : Tree
        {
            private string appleVariety; // Сорт яблок

            public string AppleVariety
            {
                get { return appleVariety; }
                set { appleVariety = value; }
            }

            public AppleTree() : base()
            {
                appleVariety = "Антоновка";
                fruitCount = 10;
            }

            public AppleTree(int age, double height, int fruitCount, string appleVariety)
                : base(age, height, fruitCount)
            {
                this.appleVariety = appleVariety;
            }

            public override void PrintClassName()
            {
                base.PrintClassName();
                Console.WriteLine("Это Яблоня.");
            }

            public void PickApples()
            {
                Console.WriteLine($"Собрано {fruitCount} яблок сорта {appleVariety}.");
                fruitCount = 0;
            }
        }

        // Подкласс CherryTree (Вишня)
        public class CherryTree : Tree
        {
            private bool hasSourCherries; // Есть ли кислые вишни

            public bool HasSourCherries
            {
                get { return hasSourCherries; }
                set { hasSourCherries = value; }
            }

            public CherryTree() : base()
            {
                hasSourCherries = true;
                fruitCount = 20;
            }

            public CherryTree(int age, double height, int fruitCount, bool hasSourCherries)
                : base(age, height, fruitCount)
            {
                this.hasSourCherries = hasSourCherries;
            }

            public override void PrintClassName()
            {
                base.PrintClassName();
                Console.WriteLine("Это Вишня.");
            }

            public void PickCherries()
            {
                Console.WriteLine($"Собрано {fruitCount} вишен. Кислые вишни: {(hasSourCherries ? "да" : "нет")}.");
                fruitCount = 0;
            }
        }

        // Подкласс MapleTree (Клен) — запечатанный класс
        public sealed class MapleTree : Tree
        {
            private double sapVolume; // Объем сока

            public double SapVolume
            {
                get { return sapVolume; }
                set { sapVolume = value; }
            }

            public MapleTree() : base()
            {
                sapVolume = 5.0; // литров
            }

            public MapleTree(int age, double height, int fruitCount, double sapVolume)
                : base(age, height, fruitCount)
            {
                this.sapVolume = sapVolume;
            }

            public override void PrintClassName()
            {
                base.PrintClassName();
                Console.WriteLine("Это Клен.");
            }

            public void HarvestSap()
            {
                Console.WriteLine($"Собрано {sapVolume} литров кленового сока.");
                sapVolume = 0.0;
            }
        }

        static void Main(string[] args)
        {
            Tree tree = null;
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Создать дерево");
                Console.WriteLine("2. Вывести свойства дерева");
                Console.WriteLine("3. Выполнить методы дерева");
                Console.WriteLine("4. Вывести название класса дерева");
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
                        Console.WriteLine("Выберите тип дерева:");
                        Console.WriteLine("1. Яблоня");
                        Console.WriteLine("2. Вишня");
                        Console.WriteLine("3. Клен");
                        Console.Write("Выберите тип дерева: ");

                        int treeType;
                        while (!int.TryParse(Console.ReadLine(), out treeType) || treeType < 1 || treeType > 3)
                        {
                            Console.WriteLine("Некорректный ввод. Пожалуйста, введите число от 1 до 3.");
                            Console.Write("Выберите тип дерева: ");
                        }

                        switch (treeType)
                        {
                            case 1:
                                tree = new AppleTree();
                                break;
                            case 2:
                                tree = new CherryTree();
                                break;
                            case 3:
                                tree = new MapleTree();
                                break;
                            default:
                                break;
                        }
                        break;

                    case 2:
                        if (tree != null)
                        {
                            Console.WriteLine($"Возраст: {tree.Age}, Высота: {tree.Height} метров, Плодов: {tree.FruitCount}");
                        }
                        else
                        {
                            Console.WriteLine("Сначала создайте дерево.");
                        }
                        break;

                    case 3:
                        if (tree != null)
                        {
                            tree.Grow();
                            tree.Harvest();
                        }
                        else
                        {
                            Console.WriteLine("Сначала создайте дерево.");
                        }
                        break;

                    case 4:
                        if (tree != null)
                        {
                            tree.PrintClassName();
                        }
                        else
                        {
                            Console.WriteLine("Сначала создайте дерево.");
                        }
                        break;

                    case 5:
                        exit = true;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
