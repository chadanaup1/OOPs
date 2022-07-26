using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Lab1
{
    public enum Categories { STOMACH, BRAIN, BODY };
    
    class ProgramOrg
    {
        OrganicShop ogs;
        public static void Main(String[] args)
        {

            ProgramOrg pog = new ProgramOrg();
            pog.Work();
        }
        void  Work()
        {
           List<ShopItem > shops = new List<ShopItem>();
           

            XmlSerializer myDeserilizer = new XmlSerializer(typeof(OrganicShop));
            FileStream myfilestream = new FileStream("shopitemsdata.xml", FileMode.Open);
            shops = (List<ShopItem>)myDeserilizer.Deserialize(myfilestream);
            myfilestream.Close();

            ogs = new OrganicShop(shops);

            Console.WriteLine("Base Shop Catalog");
            SerializeShopItems();
            ogs.Sort();

            Console.WriteLine("Sorted shop catalog");
            SerializeShopItems();
            Console.WriteLine("Selection of the week");
            ogs.Selection();

            ItemSelect foodSelect = new ItemSelect(FoodUnder10);
            ogs.ProcessItem(foodSelect);

            ItemSelect foodeselect2 = new ItemSelect(ogs.Favorites);
            ogs.ProcessItem(foodeselect2);

        }
        void SerializeShopItems()
        {
            foreach (ShopItem os in ogs.Items)
            {
                Console.WriteLine(os.ToString());
            }
        }

        public bool BookOver100(ShopItem Item)
        {
            if (Item.Category == Categories.BRAIN && Item.Price >= 100)
            {
                return true;

            }
            else
                return false;

        }

        public bool FoodUnder10(ShopItem Item)
        {
            if (Item.Category == Categories.STOMACH && Item.Price <10)
            {
                return true;
            }
            else
                return false;

        }


    }
    
    public delegate bool ItemSelect(ShopItem Item);
    
    public class OrganicShop : IItelmSelect
    {
        private List<ShopItem> _Items = new List<ShopItem>();

        public OrganicShop(List<ShopItem> se)
        {
            this.Items = se;
            
        }

        public List<ShopItem> Items
        {
            get { return _Items; }
            set
            {
                this._Items = value;
            }
        }

        public OrganicShop()
        {

            DefaultInit();

        }

        void DefaultInit()
        {
            _Items.Add(new ShopItem("Tibetan Meditation", Categories.BRAIN, 140));
            _Items.Add(new ShopItem("Pure-Oath", Categories.STOMACH, 40));
            _Items.Add(new ShopItem("PeelMySkin", Categories.BODY, 20));
            _Items.Add(new ShopItem("Quino-Ice", Categories.STOMACH, 15));
            _Items.Add(new ShopItem("Mother Eath", Categories.BRAIN, 180));
            _Items.Add(new ShopItem("Acupuncture Set", Categories.BODY, 193));
            _Items.Add(new ShopItem("BirdSeeds", Categories.STOMACH, 11));
            _Items.Add(new ShopItem("Poo Shampoo", Categories.BODY, 22));
            _Items.Add(new ShopItem("Tofu", Categories.STOMACH, 9));
            _Items.Add(new ShopItem("Refined Tofu", Categories.STOMACH, 20));
            _Items.Add(new ShopItem("Mind Cristal", Categories.BRAIN, 130));
            _Items.Add(new ShopItem("BeetRoot", Categories.STOMACH, 3));
        }


        public void Selection()
        {
            foreach (ShopItem os in Items)
            {
                if (os.Price > 100)
                {
                    
                    Console.WriteLine(os.ToString());
                }
            }
        }

        public void Sort()
        {
            Items.Sort();
        }
       
        public void ProcessItem(ItemSelect selector)
        {
            foreach(ShopItem os in Items)
            {
                if (selector(os))
                {
                    Console.WriteLine(os.ToString());
                }
            }
        }
        
        public bool Favorites(ShopItem Item)
        {
            if (Item.Price > 150)
            {
                return true;
            }
            else
                return false;

        }

    }
    
    public class ShopItem : IComparable
    {
        private String m_title;
        private double m_price;

        public ShopItem(string title, Categories category, double price)
        {
            Title = title;
            Category = category;
            Price = price;
        }

        public String Title
        {
            get { return m_title; }
            set
            {
                this.m_title = value;
            }
        }

        public Categories Category { get; set; }


        public double Price
        {
            get { return m_price; }
            set
            {
                this.m_price = value;
            }
        }


        public override string ToString()
        {
            return "\tTitle=" + Title + ", Category=" + Category + ", Price=" + Price;
        }

        public int CompareTo(Object obj)
        {

            return this.Price.CompareTo((obj as ShopItem).Price);


        }

        
    }

    interface IItelmSelect
    {
        public void Selection();
    }

    
}
