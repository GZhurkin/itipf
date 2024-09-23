using System;
using System.Collections.Generic;

// Интерфейс IGrowable
public interface IGrowable
{
    void Harvest();
    void TakeCare();
    void PlayMusic();
}

// Базовый класс Tree
public abstract class Tree : IGrowable
{
    public int FruitCount { get; set; }
    public double Height { get; set; }
    public int Age { get; set; }
    public int Health { get; set; }

    public Tree(int fruitCount, double height, int age, int health)
    {
        FruitCount = fruitCount;
        Height = height;
        Age = age;
        Health = health;
    }

    public abstract void Harvest();
    public abstract void TakeCare();

    public void PlayMusic()
    {
        Console.WriteLine("Играет вдохновляющая музыка для деревьев...");
    }

    public string GetTreeInfo()
    {
        return $"{this.GetType().Name}: Фруктов: {FruitCount}, Высота: {Height}, Возраст: {Age} лет, Здоровье: {Health}%";
    }

    public static string GetIdealSongForWalking()
    {
        return "Бах - Прелюдия №1";
    }
}

// Класс LemonTree (Лимонное дерево)
public class LemonTree : Tree
{
    public LemonTree(int fruitCount, double height, int age, int health) 
        : base(fruitCount, height, age, health) {}

    public override void Harvest()
    {
        Console.WriteLine($"Собрано {FruitCount} лимонов.");
        FruitCount = 0;
    }

    public override void TakeCare()
    {
        Console.WriteLine("Лимонное дерево полито и удобрено.");
        Health += 10;
        if (Health > 100) Health = 100;
    }
}

// Класс CherryTree (Вишня)
public class CherryTree : Tree
{
    public CherryTree(int fruitCount, double height, int age, int health)
        : base(fruitCount, height, age, health) {}

    public override void Harvest()
    {
        Console.WriteLine($"Собрано {FruitCount} вишен.");
        FruitCount = 0;
    }

    public override void TakeCare()
    {
        Console.WriteLine("Вишня подрезана и полита.");
        Health += 10;
        if (Health > 100) Health = 100;
    }
}

// Класс AppleTree (Яблоня)
public class AppleTree : Tree
{
    public AppleTree(int fruitCount, double height, int age, int health)
        : base(fruitCount, height, age, health) {}

    public override void Harvest()
    {
        Console.WriteLine($"Собрано {FruitCount} яблок.");
        FruitCount = 0;
    }

    public override void TakeCare()
    {
        Console.WriteLine("Яблоня подрезана и удобрена.");
        Health += 10;
        if (Health > 100) Health = 100;
    }
}

// Класс MapleTree (Клён)
public class MapleTree : Tree
{
    public MapleTree(int fruitCount, double height, int age, int health)
        : base(fruitCount, height, age, health) {}

    public override void Harvest()
    {
        Console.WriteLine("С клёна ничего не собрать, это же не плодовое дерево.");
    }

    public override void TakeCare()
    {
        Console.WriteLine("Клён полит и подрезан.");
        Health += 10;
        if (Health > 100) Health = 100;
    }
}

// Класс Watermelon (Арбуз)
public class Watermelon : IGrowable
{
    public int Weight { get; set; }
    public int Ripeness { get; set; }

    public Watermelon(int weight, int ripeness)
    {
        Weight = weight;
        Ripeness = ripeness;
    }

    public void Harvest()
    {
        Console.WriteLine($"Арбуз весом {Weight} кг собран.");
    }

    public void TakeCare()
    {
        Console.WriteLine("Арбуз полит и удобрен.");
        Ripeness += 10;
        if (Ripeness > 100) Ripeness = 100;
    }

    public void PlayMusic()
    {
        Console.WriteLine("Играет вдохновляющая музыка для арбузов...");
    }

    public override string ToString()
    {
        return $"Арбуз: Вес: {Weight} кг, Зрелость: {Ripeness}%";
    }
}

// Главное меню программы
internal class Program
{
    static List<IGrowable> plants = new List<IGrowable>();

    static void Main(string[] args)
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("1. Задание 1 - Работа с деревьями");
            Console.WriteLine("2. Задание 2 - Работа с интерфейсом IGrowable");
            Console.WriteLine("3. Задание 3 - Работа со списком растений");
            Console.WriteLine("0. Выход из программы");
            Console.Write("Выберите действие: ");

            switch (Console.ReadLine())
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
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void Menu_1() // Меню для работы с деревьями
    {
        Console.Clear();
        Tree? tree = null;

        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("1. Создать лимонное дерево");
            Console.WriteLine("2. Создать вишню");
            Console.WriteLine("3. Создать яблоню");
            Console.WriteLine("4. Создать клён");
            Console.WriteLine("5. Вывести свойства дерева");
            Console.WriteLine("6. Сбор урожая");
            Console.WriteLine("7. Уход за деревом");
            Console.WriteLine("8. Включить музыку для дерева");
            Console.WriteLine("9. Получить название композиции для прогулки (статический метод)");
            Console.WriteLine("0. Назад в главное меню");

            switch (Console.ReadLine())
            {
                case "1":
                    tree = new LemonTree(5, 2.5, 5, 80);
                    Console.WriteLine("Лимонное дерево создано.");
                    Console.ReadLine();
                    break;

                case "2":
                    tree = new CherryTree(50, 3.0, 7, 75);
                    Console.WriteLine("Вишня создана.");
                    Console.ReadLine();
                    break;

                case "3":
                    tree = new AppleTree(30, 4.0, 10, 90);
                    Console.WriteLine("Яблоня создана.");
                    Console.ReadLine();
                    break;

                case "4":
                    tree = new MapleTree(0, 5.5, 20, 100);
                    Console.WriteLine("Клён создан.");
                    Console.ReadLine();
                    break;

                case "5":
                    if (tree != null)
                    {
                        Console.WriteLine(tree.GetTreeInfo());
                    }
                    else
                    {
                        Console.WriteLine("Дерево не создано.");
                    }
                    Console.ReadLine();
                    break;

                case "6":
                    tree?.Harvest();
                    Console.ReadLine();
                    break;

                case "7":
                    tree?.TakeCare();
                    Console.ReadLine();
                    break;

                case "8":
                    tree?.PlayMusic();
                    Console.ReadLine();
                    break;

                case "9":
                    Console.WriteLine("Идеальная композиция для прогулки: " + Tree.GetIdealSongForWalking());
                    Console.ReadLine();
                    break;

                case "0":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Неверный выбор, попробуйте еще раз!");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void Menu_2() // Меню для работы с IGrowable
    {
        Console.Clear();

        IGrowable? growable = null;
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("1. Создать лимонное дерево");
            Console.WriteLine("2. Создать арбуз");
            Console.WriteLine("3. Сбор урожая");
            Console.WriteLine("4. Уход за растением");
            Console.WriteLine("5. Включить музыку для растения");
            Console.WriteLine("0. Назад");

            switch (Console.ReadLine())
            {
                case "1":
                    growable = new LemonTree(10, 3.0, 6, 85);
                    Console.WriteLine("Лимонное дерево создано.");
                    Console.ReadLine();
                    break;

                case "2":
                    growable = new Watermelon(12, 70);
                    Console.WriteLine("Арбуз создан.");
                    Console.ReadLine();
                    break;

                case "3":
                    growable?.Harvest();
                    Console.ReadLine();
                    break;

                case "4":
                    growable?.TakeCare();
                    Console.ReadLine();
                    break;

                case "5":
                    growable?.PlayMusic();
                    Console.ReadLine();
                    break;

                case "0":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Неверный выбор, попробуйте еще раз!");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void Menu_3() // Меню для работы со списком растений
    {
        Console.Clear();
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("1. Добавить растение в список");
            Console.WriteLine("2. Вывести свойства всех растений");
            Console.WriteLine("3. Сбор урожая для всех растений");
            Console.WriteLine("4. Уход за всеми растениями");
            Console.WriteLine("5. Включить музыку для всех растений");
            Console.WriteLine("0. Назад");

            switch (Console.ReadLine())
            {
                case "1":
                    AddPlantToList();
                    Console.ReadLine();
                    break;

                case "2":
                    DisplayAllPlants();
                    Console.ReadLine();
                    break;

                case "3":
                    HarvestAllPlants();
                    Console.ReadLine();
                    break;

                case "4":
                    CareForAllPlants();
                    Console.ReadLine();
                    break;

                case "5":
                    PlayMusicForAllPlants();
                    Console.ReadLine();
                    break;

                case "0":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Неверный выбор, попробуйте еще раз!");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void AddPlantToList()
    {
        Console.Clear();
        Console.WriteLine("1. Лимонное дерево");
        Console.WriteLine("2. Арбуз");
        switch (Console.ReadLine())
        {
            case "1":
                plants.Add(new LemonTree(10, 3.0, 6, 85));
                Console.WriteLine("Лимонное дерево добавлено в список.");
                break;

            case "2":
                plants.Add(new Watermelon(12, 70));
                Console.WriteLine("Арбуз добавлен в список.");
                break;

            default:
                Console.WriteLine("Неверный выбор.");
                break;
        }
    }

    static void DisplayAllPlants()
    {
        foreach (var plant in plants)
        {
            if (plant is Tree tree)
            {
                Console.WriteLine(tree.GetTreeInfo());
            }
            else
            {
                Console.WriteLine(plant.ToString());
            }
        }
    }

    static void HarvestAllPlants()
    {
        foreach (var plant in plants)
        {
            plant.Harvest();
        }
    }

    static void CareForAllPlants()
    {
        foreach (var plant in plants)
        {
            plant.TakeCare();
        }
    }

    static void PlayMusicForAllPlants()
    {
        foreach (var plant in plants)
        {
            plant.PlayMusic();
        }
    }
}