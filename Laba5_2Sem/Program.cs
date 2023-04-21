// Створити суперклас Кухонний прилад і підкласи Посуд, Вилка, Тарілка, Телевізор. За допомогою конструктора задати вагу кожного приладу.
// Реалізувати методи: увімкнути електроприлад, помити посуд. Вивести місцеперебування приладу, реалізувати можливість перекладення приладу в інше місце.
using Newtonsoft.Json;
using System;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

public class Program
{
    public static void Main()
    {
        Posud p = new Posud(5, 4);
        //  p.tv.ON_OFF();
        Console.WriteLine(p.AllInf());
    }
}
interface KitchenTool
{
    public double weight { get; set; }
    public int Place { get; set; }
    public string Info();

}
public class Posud
{
    public Wilka[] wilka;
    public Tarilka[] tarilka;
    public TV tv;
    public Posud(int wilka, int tarilka)
    {
        Random r = new Random();
        Wilka[] w = new Wilka[wilka];
        for (int i = 0; i < w.Length; i++)
        {
            w[i] = new Wilka((double)r.Next(0, 3), r.Next(r.Next(0, 10)));
        }
        this.wilka = w;
        Tarilka[] t = new Tarilka[tarilka];
        for (int i = 0; i < t.Length; i++)
        {
            t[i] = new Tarilka((double)r.Next(0, 3), r.Next(r.Next(0, 10)));
        }
        this.tarilka = t;
        tv = new TV((double)r.Next(0, 3), r.Next(r.Next(0, 10)));

    }
    public string AllInf()
    {
        string s = "";
        for (int i = 0; i < wilka.Length; i++)
        {
            s += wilka[i].Info() + "\n";
        }
        for (int i = 0; i < tarilka.Length; i++)
        {
            s += tarilka[i].Info() + "\n";
        }

        s += tv.Info();
        return s;
    }
}
public class Wilka : KitchenTool
{
    public double weight { get; set; }
    public int Place { get; set; }
    public bool wash { get; set; }
    public string Info() => $"Wilka, Place - {Place}, Weight - {weight}, State - {(wash == true ? "Washing" : "-")}";
    public void WashTools()
    {
        //...
    }
    public Wilka(double weight, int place)
    {
        this.weight = weight;
        Place = place;
        wash = true;
    }
}
public class Tarilka : KitchenTool
{
    public double weight { get; set; }
    public int Place { get; set; }
    public bool wash { get; set; }
    public string Info() => $"Tarilka, Place - {Place}, Weight - {weight}, State - {(wash == true ? "Washing" : "-")}";
    public void WashTools()
    {
        //...
    }
    public Tarilka(double weight, int place)
    {
        this.weight = weight;
        Place = place;
        wash = true;
    }
}
public class TV : KitchenTool
{
    public TV(double w, int pl)
    {
        weight = w;
        Place = pl;
    }
    public double weight { get; set; }
    public int Place { get; set; }

    public bool state = false;
    public void ON_OFF()
    {
        if (!state)
        {
            state = true;
        }
        else if (state)
        {
            state = false;
        }
    }
    public string Info() => $"TV, Place - {Place}, Weight - {weight}, State - {(state == true ? "ON" : "OFF")}";
}
