namespace ConsoleApp3
{
    internal class Program
    {
        internal struct CollectibleBottle
        {
            public string name;
            public double percentageOfGrapeJuice;
            public int yearRelease;
            public double price;
            public string countryManufacturer;

            public override string ToString()
            {
                return $"|{this.name}\t\t|{percentageOfGrapeJuice}\t\t|{yearRelease}\t|{price}\t|{countryManufacturer}";
            }
        }

        public static int CompareCollectibleBottlesListByName(CollectibleBottle bottle, CollectibleBottle bottle2)
        {
            return String.Compare(bottle.name, bottle2.name);
        }

        static int Menu()
        {
            int choosed = -1;
            Console.WriteLine("Выберите действие");
            Console.WriteLine("1 - Добавить напиток");
            Console.WriteLine("2 - Убрать напиток из начала");
            Console.WriteLine("3 - Найти напиток с большим содержанием виноградного сока");
            Console.WriteLine("4 - Вывод всех напитков");
            Console.WriteLine("5 - Сортировка напитков по названию");
            Console.WriteLine("6 - Заменить напиток");
            Console.WriteLine("7 - Вывести бутылки без виноградного сока, выпущенные в этом году");
            Console.WriteLine("8 - Вывести бутылки, выпущенные в указанной стране в указанном году");
            Int32.TryParse(Console.ReadLine(), out choosed);
            return choosed;
        }

        static void Main(string[] args)
        {
            Queue<CollectibleBottle> collectibleBottles = new Queue<CollectibleBottle>();
            
            Console.WriteLine("Введите имя файла:");
            string fileName = "collectibleBottlesList.dat";
            // string fileName =Console.ReadLine() +".dat";

            if (File.Exists(fileName))
            {
                using (BinaryReader sr = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    while (sr.PeekChar() != -1)
                    {
                        CollectibleBottle collectibleBottle = new CollectibleBottle();
                        collectibleBottle.name = sr.ReadString();
                        collectibleBottle.percentageOfGrapeJuice = sr.ReadDouble();
                        collectibleBottle.yearRelease = sr.ReadInt32();
                        collectibleBottle.price = sr.ReadDouble();
                        collectibleBottle.countryManufacturer = sr.ReadString();
                        collectibleBottles.Enqueue(collectibleBottle);
                    }
                }
            }

            int num;
            int choosed = -1;
            while (choosed != 0)
            {
                choosed = Menu();
                switch (choosed)
                {
                    case 0:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Error...");
                        break;

                    case 1:
                    {
                        CollectibleBottle bottle = new CollectibleBottle();
                        Console.WriteLine("Введите название напитка");
                        bottle.name = Console.ReadLine();
                        Console.WriteLine("Введите процентное содержание виноградного сока");
                        double.TryParse(Console.ReadLine(), out bottle.percentageOfGrapeJuice);
                        Console.WriteLine("Введите год выпуска");
                        Int32.TryParse(Console.ReadLine(), out bottle.yearRelease);
                        Console.WriteLine("Введите цену");
                        double.TryParse(Console.ReadLine(), out bottle.price);
                        Console.WriteLine("Введите страну изготовления");
                        bottle.countryManufacturer = Console.ReadLine();
                        collectibleBottles.Enqueue(bottle);
                    }
                        break;

                    case 2:
                        collectibleBottles.Dequeue();
                        break;

                    case 3:
                    {
                        List<CollectibleBottle> listBottle = new List<CollectibleBottle>(collectibleBottles.ToArray());
                        double maxGrapeJuice = collectibleBottles.Max(maXpercentageOfGrapeJuice =>
                            maXpercentageOfGrapeJuice.percentageOfGrapeJuice);
                        Console.WriteLine(listBottle.Find(bottles =>
                            bottles.percentageOfGrapeJuice.Equals(maxGrapeJuice)));
                    }
                        break;
                    case 4:
                        num = 1;
                        Console.WriteLine("Номер\t|Название\t|Процент\t|Год\t|Цена\t|Страна_производства\t");
                        foreach (CollectibleBottle bottle in collectibleBottles.ToArray())
                        {
                            Console.WriteLine($"{num++}\t{bottle.ToString()}");
                        }

                        break;
                    case 5:
                    {
                        List<CollectibleBottle> listBottle = new List<CollectibleBottle>(collectibleBottles.ToArray());
                        listBottle.Sort(CompareCollectibleBottlesListByName);
                        num = 1;
                        Console.WriteLine("Номер\t|Название\t|Процент\t|Год\t|Цена\t|Страна_производства\t");
                        foreach (CollectibleBottle bottle in listBottle)
                        {
                            Console.WriteLine($"{num++}\t{bottle.ToString()}");
                        }
                    }
                        break;
                    case 6:
                    {
                        List<CollectibleBottle> listBottle = new List<CollectibleBottle>(collectibleBottles.ToArray());
                        Console.WriteLine("Введите номер напитка:");
                        int.TryParse(Console.ReadLine(), out num);
                        CollectibleBottle collectibleBottle;
                        Console.WriteLine("Введите название напитка:");
                        collectibleBottle.name = Console.ReadLine();
                        Console.WriteLine("Введите процентное содержание виноградного сока");
                        double.TryParse(Console.ReadLine(), out collectibleBottle.percentageOfGrapeJuice);
                        Console.WriteLine("Введите год выпуска");
                        Int32.TryParse(Console.ReadLine(), out collectibleBottle.yearRelease);
                        Console.WriteLine("Введите цену");
                        double.TryParse(Console.ReadLine(), out collectibleBottle.price);
                        Console.WriteLine("Введите страну изготовления");
                        collectibleBottle.countryManufacturer = Console.ReadLine();
                        listBottle[num - 1] = collectibleBottle;
                        collectibleBottles.Clear();
                        listBottle.ForEach(bottle => collectibleBottles.Enqueue(bottle));
                    }
                        break;
                    case 7:
                    {
                        {
                            List<CollectibleBottle> listBottle = new List<CollectibleBottle>(collectibleBottles.ToArray());
                            num = 1;
                            Console.WriteLine("Номер\t|Название\t|Процент\t|Год\t|Цена\t|Страна_производства\t");
                            var bottles =
                                listBottle.FindAll(bottle => (bottle.percentageOfGrapeJuice.Equals(0)));
                            bottles.FindAll(bottle => bottle.yearRelease.Equals(2022)).ForEach(bottle =>
                                Console.WriteLine($"{num++}\t{bottle.ToString()}"));
                        }
                    }
                        break;
                    case 8:
                    {
                        {
                            List<CollectibleBottle> listBottle =
                                new List<CollectibleBottle>(collectibleBottles.ToArray());
                            Console.WriteLine("Введите страну напитка");
                            string country = Console.ReadLine();
                            Console.WriteLine("Введите год производства");
                            int year;
                            Int32.TryParse(Console.ReadLine(), out year);
                            num = 1;
                            Console.WriteLine("Номер\t|Название\t|Процент\t|Год\t|Цена\t|Страна_производства\t");
                            var bottles =
                                listBottle.FindAll(bottle => (bottle.countryManufacturer.Equals(country)));
                            bottles.FindAll(bottle => bottle.yearRelease.Equals(year)).ForEach(bottle =>
                                Console.WriteLine($"{num++}\t{bottle.ToString()}"));
                        }
                    }
                        break;
                }

                using (BinaryWriter sr = new BinaryWriter(File.Open(fileName, FileMode.Create)))
                {
                    foreach (CollectibleBottle c in collectibleBottles.ToArray())
                    {
                        sr.Write(c.name);
                        sr.Write(c.percentageOfGrapeJuice);
                        sr.Write(c.yearRelease);
                        sr.Write(c.price);
                        sr.Write(c.countryManufacturer);
                    }
                }
            }
        }
    }
}