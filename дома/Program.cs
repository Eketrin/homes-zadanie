using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace дома
{
    class City
    {
        public string NazvanieCity { get; set; }

        public City(string NazvanieCity1) //конструктор
        {
            NazvanieCity = NazvanieCity1;
        }
    }
    class Zdanie
    {
        public string NameOfStreet { get; set; }
        public int NumOfHouse { get; set; }
        public int AllPloshad { get; }
        public double BillForMonth { get; set; }

        public Zdanie(string NameOfStreet1, int NumOfHouse1,
                        int AllPloshad1, double BillForMonth1)//конструктор
        {
            NameOfStreet = NameOfStreet1;
            NumOfHouse = NumOfHouse1;
            AllPloshad = AllPloshad1;
            BillForMonth = BillForMonth1;
        }
        public List<Room> rooms = new List<Room>();

    }
    abstract class Room //помещение
    {
        public int NumOfRoom { get; set; }
        public int PloshadOfRoom { get; set; }
        public double BillForMonth { get; set; }

        public Room(int NumOfRoom1, int PloshadOfRoom1, double BillForMonth1)//конструктор
        {
            NumOfRoom = NumOfRoom1;
            PloshadOfRoom = PloshadOfRoom1;
            BillForMonth = BillForMonth1;
        }
        abstract public void CountBillForMonth();
    }

    class Kvartira : Room
    {
        public string FioOfOuner { get; set; }
        public int CountOfOuners { get; set; }


        public Kvartira(int NumOfRoom1, int PloshadOfRoom1, double BillForMonth1,
                        string FioOfOuner1, int CountOfOuners1)//конструктор
                        : base(NumOfRoom1, PloshadOfRoom1, BillForMonth1)
        {
            FioOfOuner = FioOfOuner1;
            CountOfOuners = CountOfOuners1;

        }
        public override void CountBillForMonth()
        {
            Console.WriteLine(BillForMonth * PloshadOfRoom * (1 + CountOfOuners * 0.1));
        }
    }
    class Ofis : Room
    {
        public string NameOfCompany { get; set; }
        public string ActivityOfCompany { get; set; }
        public Ofis(int NumOfRoom1, int PloshadOfRoom1,
                        double BillForMonth1, string NameOfCompany1, string ActivityOfCompany1)//конструктор
                        : base(NumOfRoom1, PloshadOfRoom1, BillForMonth1)
        {
            NameOfCompany = NameOfCompany1;
            PloshadOfRoom = PloshadOfRoom1;
        }
        public override void CountBillForMonth()
        {
            Console.WriteLine(BillForMonth * PloshadOfRoom * 2);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Zdanie z1 = new Zdanie("улица", 18, 40, 20);
            Kvartira kvartira1 = new Kvartira(1, 12, z1.BillForMonth, "фамилия", 4);
            Kvartira kvartira2 = new Kvartira(2, 10, z1.BillForMonth, "фамилия2", 2);
            Ofis ofis1 = new Ofis(3, 10, z1.BillForMonth, "kompany", "деятельность");
            kvartira1.CountBillForMonth();
            kvartira2.CountBillForMonth();
            ofis1.CountBillForMonth();
            Console.ReadLine();
        }
    }
}
