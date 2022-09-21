// Coffee coffee = new Coffee("SPB", 0.4, '0', 2022, "Latte", true);
// Console.WriteLine(wine.ToString());
// Wine.ListenMinistryOfHealth("Не пейте много!");
// Console.WriteLine(coffee.ToString());

List<IReflector> drinks = new List<IReflector>();

int choosed = -1;
while (choosed != 0)
{
    choosed = Menu();
    switch (choosed)
    {
        case 1:
            foreach (var item in drinks)
            {
                Console.WriteLine(item);
            }

            break;
        case 2:
            if (drinks.Count == 0)
                throw new Exception("Ой, напитков нет");
            var drink = (Wine)drinks[0];
            Console.WriteLine(drink.ViewingLightReflection("Плохо, бутылка слишком тёмная"));
            break;
        case 3:
            Console.WriteLine("Напишите напиток из меню");
            Console.WriteLine("Меню:");
            Console.WriteLine("Напишиите номер номер напитка");
            Console.WriteLine("Вино(1), Холодный чай(2), Пиво(3), Шампанское(4), Коктель(5)");

            int drinkFromMenu = -1;
            Int32.TryParse(Console.ReadLine(), out drinkFromMenu);
            switch (drinkFromMenu)
            {
                case 1:
                    Wine wine = new Wine("SPB", 1.5, '4', 2022, "White", "Sweet");
                    Console.WriteLine(wine.DrinkLittle() +" "+ wine.GetType());
                    break;
                case 2:
                    IcedTea icedTea = new IcedTea();
                    Console.WriteLine(icedTea.DrinkLittle()+" "+ icedTea.GetType());
                    break;
                case 3:
                    Beer beer = new Beer();
                    Console.WriteLine(beer.DrinkLittle()+" "+ beer.GetType());
                    break;
                case 4:
                    Champange champange = new Champange();
                    Console.WriteLine(champange.DrinkLittle()+" "+ champange.GetType());
                    break;
                case 5:
                    Cocktail cocktail = new Cocktail();
                    Console.WriteLine(cocktail.DrinkLittle()+" "+ cocktail.GetType());
                    break;
            }

            break;
        case 4:
            Console.WriteLine(new Wine().EstimateSmell("Приятный запах и вкус вина !"));
            break;
        case 5:
            Wine.ListenMinistryOfHealth("Пить много вина вредно !");
            break;
        case 6:
            Wine wine2 = new Wine("MSK", 0.5, '0', 2022, "White", "Sweet");
            drinks.Add(wine2);
            break;
        case 0:
            choosed = 0;
            break;
    }
}

static int Menu()
{
    int choosed = -1;
    // Console.Clear();
    Console.WriteLine("Выберите действие");
    Console.WriteLine("1 - Вывести все напитки");
    Console.WriteLine("2 - Посмотреть как свет отражается в бутылке вина");
    Console.WriteLine("3 - Выпить немного");
    Console.WriteLine("4 - Оценить аромат винного напитка");
    Console.WriteLine("5 - Послушать Минздрав");
    Console.WriteLine("6 - Добавить напиток на склад");
    Console.WriteLine("0 - Выход");
    Int32.TryParse(Console.ReadLine(), out choosed);
    return choosed;
}

class Wine : Drink
{
    public string redOrWhite { get; set; }
    public string dryOrSweet { get; set; }

    public Wine()
    {
    }

    public Wine(string country, double volume, char degree, int year, string redOrWhite, string dryOrSweet)
    {
        this.country = country;
        this.volume = volume;
        this.degree = degree;
        this.year = year;
        this.redOrWhite = redOrWhite;
        this.dryOrSweet = dryOrSweet;
    }

    public override void Start()
    {
        base.Start();
        Console.WriteLine(DrinkLittle());
    }

    public string ViewingLightReflection(string value)
    {
        return value;
    }

    public string EstimateSmell(string value)
    {
        return value;
    }

    public static void ListenMinistryOfHealth(string text)
    {
        Console.WriteLine("Слушайте минздрав. \n Минздрав говорит: " + text);
    }

    public override string ToString()
    {
        return base.ToString() + string.Format(" Тип вина: {0} \n Вкус вина: {1}", redOrWhite, dryOrSweet);
    }
}


class IcedTea : Drink
{
    public string typeTea { get; set; }

    public IcedTea(string country, double volume, char degree, int year, string typeTea)
    {
        this.country = country;
        this.volume = volume;
        this.degree = degree;
        this.year = year;
        this.typeTea = typeTea;
    }

    public IcedTea()
    {
    }
}

class Beer : Drink
{
    private string bottleVolume { get; set; }
    public string lightAndDark { get; set; }

    public Beer(string country, double volume, char degree, int year, string bottleVolume, string lightAndDark)
    {
        this.country = country;
        this.volume = volume;
        this.degree = degree;
        this.year = year;
        this.bottleVolume = bottleVolume;
        this.lightAndDark = lightAndDark;
    }

    public Beer()
    {
    }
}

class Champange : Drink
{
    public int alcohol { get; set; }
    public string excerpt { get; set; }

    public Champange(string country, double volume, char degree, int year, int alcohol, string excerpt)
    {
        this.country = country;
        this.volume = volume;
        this.degree = degree;
        this.year = year;
        this.alcohol = alcohol;
        this.excerpt = excerpt;
    }

    public Champange()
    {
    }
}

class Cocktail : Drink
{
    public bool withMilk { get; set; }
    public bool alcoholic { get; set; }
    public string taste { get; set; }

    public Cocktail(string country, double volume, char degree, int year, bool withMilk, bool alcoholic, string taste)
    {
        this.country = country;
        this.volume = volume;
        this.degree = degree;
        this.year = year;
        this.withMilk = withMilk;
        this.alcoholic = alcoholic;
        this.taste = taste;
    }

    public Cocktail()
    {
    }
}

class Coffee : Drink
{
    public string title { get; set; }
    public bool withLeker { get; set; }

    public Coffee(string country, double volume, char degree, int year, string title, bool withLeker)
    {
        this.country = country;
        this.volume = volume;
        this.degree = degree;
        this.year = year;
        this.title = title;
        this.withLeker = withLeker;
    }
}

public abstract class Drink : IReflector
{
    public string country { get; set; }
    public double volume { get; set; }
    public char degree { get; set; }
    public int year { get; set; }


    public virtual void Start()
    {
        Console.WriteLine("Добро пожаловать в интерфейс напитков");
    }

    public string DrinkLittle()
    {
        return "Выпьем немного";
    }

    public override string ToString()
    {
        return string.Format(
            "\n Вызван класс: {4} \n Страна: {0} \n Объём: {1} \n Процент алкоголя: {2} \n Год производства: {3} \n",
            country, volume, degree, year, GetType());
    }
}

interface IReflector
{
    void Start();
}

class Prism : IReflector
{
    public void Start()
    {
        Console.WriteLine("Паралельны ли основания фигуры ?");
        string answerUser = Console.ReadLine();

        if (answerUser != "Yes" || answerUser != "Да")
            throw new Exception("Эй, это не призма !");
        else
            Console.WriteLine("Хорошо, возможно, это призма )))");
    }
}