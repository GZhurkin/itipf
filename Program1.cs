using System;

namespace LemonTreeApp
{
    public class LemonTree
    {
        // Поля
        private int fruitCount;
        private int age;
        private double height;
        private double health;
        private bool isCaredFor;

        // Константное поле
        public const string IdealSong = "The Tree Song - популярная композиция для прогулок среди деревьев.";

        // Свойства
        public int FruitCount
        {
            get { return fruitCount; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Количество плодов не может быть отрицательным.");
                fruitCount = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Возраст не может быть отрицательным.");
                age = value;
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Высота должна быть положительной.");
                height = value;
            }
        }

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

        // Конструкторы
        public LemonTree()
        {
            fruitCount = 5;
            age = 2;
            height = 1.5;
            health = 80;
            isCaredFor = false;
        }

        public LemonTree(int fruitCount, int age, double height, double health)
        {
            FruitCount = fruitCount;
            Age = age;
            Height = height;
            Health = health;
            isCaredFor = false;
        }

        // Конструктор копирования
        public LemonTree(LemonTree other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other), "Копируемое дерево не может быть null.");
            
            this.fruitCount = other.fruitCount;
            this.age = other.age;
            this.height = other.height;
            this.health = other.health;
            this.isCaredFor = other.isCaredFor;
        }

        // Методы
        public void Harvest()
        {
            Console.WriteLine($"Вы собрали {fruitCount} плодов с лимонного дерева.");
            fruitCount = 0;
        }

        public void Care()
        {
            isCaredFor = true;
            health += 10;
            Console.WriteLine("Вы позаботились о лимонном дереве, здоровье увеличилось.");
        }

        public void PlayInspiringMusic()
        {
            Console.WriteLine("Вы играете вдохновляющую музыку для лимонного дерева.");
            if (isCaredFor)
            {
                height += 0.2;
                Console.WriteLine("Лимонное дерево выросло на 0.2 метра!");
            }
            else
            {
                Console.WriteLine("Дереву требуется уход для роста.");
            }
        }

        public static void ShowIdealSong()
        {
            Console.WriteLine(IdealSong);
        }

        public override string ToString()
        {
            return $"Лимонное дерево: плодов - {fruitCount}, возраст - {age} лет, высота - {height} м, здоровье - {health}%";
        }

        public override bool Equals(object obj)
        {
            if (obj is LemonTree tree)
                return this.fruitCount == tree.fruitCount && this.age == tree.age &&
                       Math.Abs(this.height - tree.height) < 0.001 && Math.Abs(this.health - tree.health) < 0.001 &&
                       this.isCaredFor == tree.isCaredFor;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(fruitCount, age, height, health, isCaredFor);
        }

        public static bool operator ==(LemonTree t1, LemonTree t2)
        {
            if (ReferenceEquals(t1, t2)) return true;
            if (ReferenceEquals(t1, null) || ReferenceEquals(t2, null)) return false;
            return t1.FruitCount == t2.FruitCount &&
                   t1.Age == t2.Age &&
                   Math.Abs(t1.Height - t2.Height) < 0.001 &&
                   Math.Abs(t1.Health - t2.Health) < 0.001;
        }

        public static bool operator !=(LemonTree t1, LemonTree t2)
        {
            return !(t1 == t2);
        }

        public static LemonTree operator +(LemonTree tree, double additionalHeight)
        {
            if (tree == null)
                throw new ArgumentNullException(nameof(tree), "Дерево не может быть null.");

            // Увеличиваем высоту текущего дерева
            tree.height += additionalHeight;
            return tree; // Возвращаем текущее дерево с обновленной высотой
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            LemonTree tree1 = new LemonTree(); 

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Задать параметры первого лимонного дерева");
                Console.WriteLine("2. Вывести свойства первого лимонного дерева");
                Console.WriteLine("3. Выполнить статический метод");
                Console.WriteLine("4. Собрать урожай");
                Console.WriteLine("5. Позаботиться о дереве");
                Console.WriteLine("6. Включить вдохновляющую музыку");
                Console.WriteLine("7. Сравнить два дерева");
                Console.WriteLine("8. Увеличить высоту первого дерева");
                Console.WriteLine("9. Выход");

                switch (Console.ReadLine())
                {
                    case "1":
                        tree1.FruitCount = ReadInt("Введите количество плодов: ");
                        tree1.Age = ReadInt("Введите возраст дерева: ");
                        tree1.Height = ReadDouble("Введите высоту дерева (в метрах): ");
                        tree1.Health = ReadDouble("Введите здоровье дерева (в процентах): ");
                        break;

                    case "2":
                        Console.WriteLine(tree1.ToString());
                        break;

                    case "3":
                        LemonTree.ShowIdealSong();
                        break;

                    case "4":
                        tree1.Harvest();
                        break;

                    case "5":
                        tree1.Care();
                        break;

                    case "6":
                        tree1.PlayInspiringMusic();
                        break;

                    case "7":
                        LemonTree tree2 = new LemonTree(10, 3, 2.0, 70);

                        if (tree1 == tree2)
                            Console.WriteLine("Деревья одинаковые.");
                        else
                            Console.WriteLine("Деревья разные.");
                        break;

                    case "8":
                        double additionalHeight = ReadDouble("Введите количество метров для увеличения высоты: ");
                        tree1 += additionalHeight; // Используем перегруженный оператор
                        Console.WriteLine($"Обновлённое дерево: {tree1}");
                        break;

                    case "9":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Неправильный ввод, попробуйте снова.");
                        break;
                }
            }
        }

        static int ReadInt(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value) && value >= 0)
                    return value;
                else
                    Console.WriteLine("Введите корректное целое число.");
            }
        }

        static double ReadDouble(string prompt)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out value) && value >= 0)
                    return value;
                else
                    Console.WriteLine("Введите корректное число.");
            }
        }
    }
}