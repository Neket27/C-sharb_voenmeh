Console.WriteLine("Hello, World!");

Wine wine = new Wine("SPB",1.5,'4',2022,"White","Sweet");
Coffee coffee = new Coffee("SPB",0.4,'0',2022,"Latte",true);
Console.WriteLine(wine.ToString());

// coffee.Start();
// Console.WriteLine(wine.DrinkLittle());

class Wine : Drink
{
    public Wine() { }

    public Wine(string country,double volume,char degree,int year,string redOrWhite, string dryOrSweet)
    {
        this.country = country;
        this.volume = volume;
        this.degree = degree;
        this.year = year;
        this.redOrWhite = redOrWhite;
        this.dryOrSweet = dryOrSweet;
    }

    public string redOrWhite { get; set; }
    public string dryOrSweet { get; set; }


    public override void Start()
    {
        base.Start();
        Console.WriteLine(DrinkLittle());
    }

    public string ViewingLightReflection(string value)
    {
        return value;
    }

    public string DrinkLittle()
    {
        return "Выпьем немного";
    }

    public string EstimateSmell(string value)
    {
        return value;
    }

    static void ListenMinistryOfHealth()
    {
        Console.WriteLine("Слушайте минздрав");
    }
    
    public override string ToString()
    {

        return base.ToString()+ string.Format(" Тип вина: {0} \n Вкус вина: {1}",redOrWhite,dryOrSweet);
    }
}



class IcedTea:Drink
{
    public string typeTea { get; set; }
    
    public IcedTea(string country,double volume,char degree,int year,string typeTea)
    {
        this.country = country;
        this.volume = volume;
        this.degree = degree;
        this.year = year;
        this.typeTea = typeTea;
    }
}

class Beer:Drink
{
    public string bottleVolume { get; set; }
    public string lightAndDark { get; set; }
    
    public Beer(string country,double volume,char degree,int year,string bottleVolume, string lightAndDark)
    {
        this.country = country;
        this.volume = volume;
        this.degree = degree;
        this.year = year;
        this.bottleVolume = bottleVolume;
        this.lightAndDark = lightAndDark;
    }
}

class Champange:Drink
{
    public int alcohol { get; set; }
    public string excerpt { get; set; }
    
    public Champange(string country,double volume,char degree,int year,int alcohol, string excerpt)
    {
        this.country = country;
        this.volume = volume;
        this.degree = degree;
        this.year = year;
        this.alcohol = alcohol;
        this.excerpt = excerpt;
    }
}

class Cocktail:Drink
{
    public bool withMilk { get; set; }
    public bool alcoholic { get; set; }
    public string taste { get; set; }
    
    public Cocktail(string country,double volume,char degree,int year,bool withMilk, bool alcoholic, string taste)
    {
        this.country = country;
        this.volume = volume;
        this.degree = degree;
        this.year = year;
        this.withMilk = withMilk;
        this.alcoholic = alcoholic;
        this.taste = taste;
    }
}

class Coffee:Drink
{
    public string title { get; set; }
    public bool withLeker { get; set; }
    
    public Coffee(string country,double volume,char degree,int year, string title, bool withLeker)
    {
        this.country = country;
        this.volume = volume;
        this.degree = degree;
        this.year = year;
        this.title = title;
        this.withLeker = withLeker;
    }
}

public abstract class Drink
{
    public string country { get; set; }
    public double volume { get; set; }
    public char degree { get; set; }
    public int year { get; set; }


    public virtual void Start()
    {
        Console.WriteLine("Добро пожаловать в интерфейс напитков");
    }

    public override string ToString()
    {
        return string.Format("Вызван класс: {4} \n Страна: {0} \n Объём: {1} \n Процент алкоголя: {2} \n Год производства: {3} \n",country,volume,degree,year,GetType());
    }
    
}