using System;

namespace TreeHierarchyApp
{
    internal class Program
    {
        // Абстрактный базовый класс Tree (Дерево)
        public abstract class Tree
        {
            protected int age;          // Возраст дерева
            protected double height;    // Высота дерева
            protected int fruitCount;   // Количество плодов

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

        // Подкласс LemonTree (Лимонное дерево)
        public class LemonTree : Tree
        {
            private double health; // Здоровье дерева в процентах
            private bool isCaredFor; // Был ли уход за деревом

            public double Health
            {
                get { return health; }
                set
                {
                    if (value < 0)
                        throw new ArgumentException("Здоровье должно быть в пределах от 0.");
                    health = value;
                }
            }

            public LemonTree(int age, double height, int fruitCount, double health)
                : base(age, height, fruitCount)
            {
                Health = health;
                isCaredFor = false;
            }

            public override void PrintClassName()
            {
                base.PrintClassName();
                Console.WriteLine("Это Лимонное дерево.");
            }

            public void CheckHealth()
            {
                Console.WriteLine($"Здоровье лимонного дерева: {health}%.");
            }

            // Метод ухода за деревом
            public void Care()
            {
                isCaredFor = true;
                health = Math.Min(100, health + 10); // Увеличиваем здоровье, не превышая 100%
                Console.WriteLine("Вы позаботились о лимонном дереве, здоровье увеличилось.");
            }

            // Метод для роста с музыкой
            public void PlayInspiringMusic()
            {
                Console.WriteLine("Вы играете вдохновляющую музыку для лимонного дерева.");
                if (isCaredFor)
                {
                    height += 0.2; // Увеличиваем высоту дерева
                    Console.WriteLine("Лимонное дерево выросло на 0.2 метра!");
                }
                else
                {
                    Console.WriteLine("Дереву требуется уход для роста.");
                }
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
                Console.WriteLine("3. Выполнить метод дерева");
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
                        Console.WriteLine("4. Лимонное дерево");
                        Console.Write("Введите тип дерева: ");
                        int treeType;
                        while (!int.TryParse(Console.ReadLine(), out treeType) || treeType < 1 || treeType > 4)
                        {
                            Console.WriteLine("Некорректный ввод. Введите число от 1 до 4.");
                        }

                        // Ввод значений свойств дерева с проверками
                        int age;
                        while (true)
                        {
                            Console.Write("Введите возраст дерева (целое число неотрицательное): ");
                            if (int.TryParse(Console.ReadLine(), out age) && age >= 0) break;
                            Console.WriteLine("Некорректный ввод. Пожалуйста, введите неотрицательное целое число.");
                        }

                        double height;
                        while (true)
                        {
                            Console.Write("Введите высоту дерева (положительное число): ");
                            if (double.TryParse(Console.ReadLine(), out height) && height > 0) break;
                            Console.WriteLine("Некорректный ввод. Пожалуйста, введите положительное число.");
                        }

                        int fruitCount;
                        while (true)
                        {
                            Console.Write("Введите количество плодов на дереве (целое неотрицательное число): ");
                            if (int.TryParse(Console.ReadLine(), out fruitCount) && fruitCount >= 0) break;
                            Console.WriteLine("Некорректный ввод. Пожалуйста, введите неотрицательное целое число.");
                        }

                        switch (treeType)
                        {
                            case 1:
                                Console.Write("Введите сорт яблок: ");
                                string appleVariety = Console.ReadLine();
                                tree = new AppleTree(age, height, fruitCount, appleVariety);
                                break;
                            case 2:
                                Console.Write("Есть ли кислые вишни? (1/0): ");
                                bool hasSourCherries;
                                while (true)
                                {
                                    string input = Console.ReadLine().ToLower();
                                    if (input == "1")
                                    {
                                        hasSourCherries = true;
                                        break;
                                    }
                                    else if (input == "0")
                                    {
                                        hasSourCherries = false;
                                        break;
                                    }
                                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите '1' или '0'.");
                                }
                                tree = new CherryTree(age, height, fruitCount, hasSourCherries);
                                break;
                            case 3:
                                double sapVolume;
                                while (true)
                                {
                                    Console.Write("Введите объем сока в литрах (положительное число): ");
                                    if (double.TryParse(Console.ReadLine(), out sapVolume) && sapVolume > 0) break;
                                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите положительное число.");
                                }
                                tree = new MapleTree(age, height, fruitCount, sapVolume);
                                break;
                            case 4:
                                double health;
                                while (true)
                                {
                                    Console.Write("Введите здоровье дерева (от 0 до 100): ");
                                    if (double.TryParse(Console.ReadLine(), out health) && health >= 0 && health <= 100) break;
                                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите число от 0 до 100.");
                                }
                                tree = new LemonTree(age, height, fruitCount, health);
                                break;
                        }
                        break;

                    case 2:
                        if (tree != null)
                        {       
                            Console.WriteLine($"Возраст: {tree.Age}, Высота: {tree.Height} метров, Плодов: {tree.FruitCount}");
        
                            // Дополнительный вывод для каждого конкретного типа дерева
                            if (tree is AppleTree appleTree)
                            {
                                Console.WriteLine($"Сорт яблок: {appleTree.AppleVariety}");
                            }
                            else if (tree is CherryTree cherryTree)
                            {
                                Console.WriteLine($"Есть ли кислые вишни: {(cherryTree.HasSourCherries ? "Да" : "Нет")}");
                            }
                            else if (tree is MapleTree mapleTree)
                            {
                                Console.WriteLine($"Объем сока: {mapleTree.SapVolume} литров");
                            }
                            else if (tree is LemonTree lemonTree)
                            {
                                Console.WriteLine($"Здоровье дерева: {lemonTree.Health}%");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Сначала создайте дерево.");
                        }
                        break;

                    case 3:
                        if (tree != null)
                        {
                            Console.WriteLine("\nВыберите действие:");
                            Console.WriteLine("1. Дать дереву подрасти");
                            Console.WriteLine("2. Собрать плоды");
                            if (tree is AppleTree)
                                Console.WriteLine("3. Собрать яблоки");
                            else if (tree is CherryTree)
                                Console.WriteLine("3. Собрать вишни");
                            else if (tree is MapleTree)
                                Console.WriteLine("3. Собрать кленовый сок");
                            else if (tree is LemonTree)
                            {
                                Console.WriteLine("3. Проверить здоровье дерева");
                                Console.WriteLine("4. Ухаживать за деревом");
                                Console.WriteLine("5. Играть вдохновляющую музыку");
                            }
                            Console.Write("Выберите действие: ");

                            int action;
                            while (!int.TryParse(Console.ReadLine(), out action) || action < 1 || action > (tree is LemonTree ? 5 : 3))
                            {
                                Console.WriteLine("Некорректный ввод. Введите число от 1 до " + (tree is LemonTree ? 5 : 3) + ".");
                            }

                            switch (action)
                            {
                                case 1:
                                    tree.Grow();
                                    break;
                                case 2:
                                    tree.Harvest();
                                    break;
                                case 3:
                                    if (tree is AppleTree appleTree)
                                    {
                                        appleTree.PickApples();
                                    }
                                    else if (tree is CherryTree cherryTree)
                                    {
                                        cherryTree.PickCherries();
                                    }
                                    else if (tree is MapleTree mapleTree)
                                    {
                                        mapleTree.HarvestSap();
                                    }
                                    else if (tree is LemonTree lemonTree)
                                    {
                                        lemonTree.CheckHealth();
                                    }
                                    break;
                                case 4:
                                    if (tree is LemonTree lemonTreeCare)
                                    {
                                        lemonTreeCare.Care();
                                    }
                                    break;
                                case 5:
                                    if (tree is LemonTree lemonTreeMusic)
                                    {
                                        lemonTreeMusic.PlayInspiringMusic();
                                    }
                                    break;
                            }
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
                }
            }
        }
    }
}