using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Lab1
{
    public enum Category { COUNTRY, SHORE, URBAN };
    class ProgramRents
    {
        RealEstateAgency realEstate;
        public static void Main(String[] args)
        {
            ProgramRents pog = new ProgramRents();
            pog.Work();
        }
        void Work()
        {
            realEstate = new RealEstateAgency();

            Console.WriteLine("Base shop catalog");
            SerializeRealEstates();

            realEstate.Sort();
            Console.WriteLine("Sorted shop catalog");
            SerializeRealEstates();

            realEstate.Selection();

            Rentalselect StudioSelect = new Rentalselect(StudioUnder800);
            realEstate.ProcessItem(StudioSelect);
            Console.WriteLine("studio");
            SerializeRealEstates();

            Rentalselect HouseSelect = new Rentalselect(HouseOver1000);
            realEstate.ProcessItem(HouseSelect);
            Console.WriteLine("house");
            SerializeRealEstates();

            Rentalselect StudioSelect2 = new Rentalselect(realEstate.Favorites);
            Console.WriteLine("Favorites");
            realEstate.ProcessItem(StudioSelect2);



        }
        void SerializeRealEstates()
        {
            Console.WriteLine(realEstate.ToString());
        }

        public bool StudioUnder800(PropertyToRent Item)
        {

            if (Item is Studio && Item.Price <= 800)
            {
                return true;

            }

            else
                return false;
        }

        public bool HouseOver1000(PropertyToRent Item)
        {

            if (Item is Studio && Item.Price > 1000)
            {
                return true;

            }
            else
                return false;
        }


    }
    public delegate bool Rentalselect(PropertyToRent Item);
    public abstract class PropertyToRent : IComparable
    {
        private String _name;
        private int m_surface;
        private int m_price;
        private Category m_category;

        protected PropertyToRent(string name, Category category, int surface, int price)
        {
            _name = name;
            m_surface = surface;
            m_price = price;
            m_category = category;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public int Surface
        {
            get => m_surface;
            set => m_surface = value;
        }
        public int Price
        {
            get => m_price;
            set => m_price = value;
        }
        public Category category
        {
            get => m_category;
            set => m_category = value;
        }

        public abstract double Taxes();

        public int CompareTo(Object obj)
        {

            return m_price.CompareTo((obj as PropertyToRent).m_price);

        }

        public override string ToString()
        {
            return "\tCategory=" + category + " Price=" + Price + ", @=" + Name + ", Surface=" + Surface;
        }

    }
    public class House : PropertyToRent
    {
        public House(string name, Category category, int surface, int price) : base(name, category, surface, price)
        {
            this.Name = name;
            this.Surface = surface;
            this.Price = price;
            this.category = category;
        }

        public override double Taxes()
        {
            if (category.Equals(Category.COUNTRY))
                return Surface * 15;
            else if (category.Equals(Category.URBAN))
                return Surface * 25;
            else return Surface * 35;
        }
    }

    public class Studio : PropertyToRent
    {
        public Studio(string name, Category category, int surface, int price) : base(name, category, surface, price)
        {
            this.Name = name;
            this.Surface = surface;
            this.Price = price;
            this.category = category;
        }

        public override double Taxes()
        {
            if (category.Equals(Category.COUNTRY))
                return Surface * 10;
            else if (category.Equals(Category.URBAN))
                return Surface * 15;
            else return Surface * 20;
        }

    }

    public class Mansion : PropertyToRent
    {
        public Mansion(string name, Category category, int surface, int price) : base(name, category, surface, price)
        {
            this.Name = name;
            this.Surface = surface;
            this.Price = price;
            this.category = category;
        }

        public override double Taxes()
        {
            if (category.Equals(Category.COUNTRY))
                return Surface * 20;
            else if (category.Equals(Category.URBAN))
                return Surface * 30;
            else return Surface * 40;
        }

    }

    public class RealEstateAgency : IRentalSelect
    {
        private List<PropertyToRent> _Rentals = new List<PropertyToRent>();


        public RealEstateAgency()
        {
            //String fileName = "Rentals.xml";
            //if (File.Exists(fileName))
            //{
            //    XmlInit(fileName);
            //}
            //else
            //{
            DefaultInit();
            // }
        }
        public void XmlInit(String fileName)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(PropertyToRent));
            using (Stream reader = new FileStream(fileName, FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                _Rentals.Add((PropertyToRent)serializer.Deserialize(reader));
            }


        }
        void DefaultInit()
        {
            _Rentals.Add(new Studio("Les Raisins, flat 5", Category.COUNTRY, 300, 30));
            _Rentals.Add(new House("Mon Abri Cotier", Category.COUNTRY, 1200, 300));
            _Rentals.Add(new Mansion("Les Grands Platanes", Category.URBAN, 3000, 1000));
            _Rentals.Add(new Studio("Les Hautes Grarennes, flat 56", Category.URBAN, 250, 25));
            _Rentals.Add(new House("La Brise", Category.SHORE, 960, 200));
            _Rentals.Add(new House("La Chaumiere", Category.COUNTRY, 800, 150));
            _Rentals.Add(new Mansion("Les Ratelieres", Category.SHORE, 2800, 1200));
            _Rentals.Add(new Studio("Les basses plaines", Category.URBAN, 700, 47));
            _Rentals.Add(new Mansion("La Lanterne", Category.URBAN, 3500, 600));
            _Rentals.Add(new Studio("La Courvieille, flat 34", Category.COUNTRY, 340, 26));
            _Rentals.Add(new House("Ici chez moi", Category.URBAN, 780, 230));
            _Rentals.Add(new Studio("Les Saules, flat 135", Category.SHORE, 390, 30));
        }

        public override string ToString()
        {
            return string.Join("\n ", _Rentals.Select(x => x.ToString()).ToArray());
        }
        public void Sort()
        {
            _Rentals.Sort();
        }

        public void Selection()
        {
            foreach (PropertyToRent os in _Rentals)
            {
                if (os.Price > 1000)
                {
                    Console.WriteLine("SELECTION OF THE WEEK");
                    Console.WriteLine(os.ToString());
                }
            }
        }
        public void ProcessItem(Rentalselect selector)
        {
            foreach (PropertyToRent os in _Rentals)
            {
                if (selector(os))
                {
                    Console.WriteLine(os.ToString());
                }
            }
        }
        public bool Favorites(PropertyToRent item)
        {

            if (item.Price > 150)
            {
                return true;
            }
            else
                return false;
        }

    }
  
    interface IRentalSelect
    {
        public void Selection();
    }
}

