using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class ProfProg
    {
        private ArtPiece[] ArtPieces;

        //static void Main(string[] args)
        //{
            //ProfProg MainProg = new ProfProg();
            //MainProg.Work();  // cut the static rope...
        //}

        void Work()
        {
            // ask user for number ?
            Console.Write("How many ? ");
            int number = int.Parse(Console.ReadLine());

            this.ArtPieces = new ArtPiece[number];

            // generate content
            for (int i = 0; i < number; i++)
            {
                if (i % 2 == 0)
                    this.ArtPieces[i] = new Painting(
                                            "PAINT" + i,
                                            (number - i + 1) * 100000000,
                                            i * 100, i * 200);

                else
                    this.ArtPieces[i] = new Sculpture(
                                            "SCULPT" + i,
                                            (number - i + 1) * 300000000,
                                            i * 100, i * 200, i * 150,
                                            i * 10);
            }

            // display the whole content
            SerializeArtPieces();

            //sales (-10%)
            for (int i = 0; i < number; i++)
            {
                this.ArtPieces[i].Price -= this.ArtPieces[i].Price * 0.7;
                //this.ArtPieces[i].setPrice( this.ArtPieces[i].getPrice()*0.4 );
            }

            // display the sales content
            SerializeArtPieces();

            Array.Sort(ArtPieces);

            // display the sorted content
            SerializeArtPieces();

        }

        void SerializeArtPieces()
        {
            Console.WriteLine("\nArray content:");
            for (int i = 0; i < ArtPieces.Length; i++)
            {
                Console.WriteLine(ArtPieces[i].ToString());
            }
        }
    }
    public class ArtPiece : IComparable
    {
        // one value(name, ID, ...)
        private string _Title;

        // another value (Size, weight, ...)
        private double _Price;

        public string Title     // immutable
        {
            get { return this._Title; }
        }

        public double Price
        {
            get { return _Price; }
            set
            {
                if (value > (this._Price * 0.5)) // no sale bigger than 50%
                    this._Price = value;
                else
                    this._Price *= 0.5;
            }
        }

        // methods ?
        public ArtPiece(string nameValue, double priceValue)
        {
            _Title = nameValue;
            Price = priceValue;
        }

        public override string ToString()
        {
            return Title + "\tcost " + Price + "\t" + Transport();
        }

        public virtual string Transport()
        {
            return " no comment..";
        }

        public int CompareTo(object obj)
        {
            return Price.CompareTo((obj as ArtPiece).Price);
        }
    }

    public class Painting : ArtPiece
    {
        private int _Width;  // immutables
        private int _Height;

        public Painting(string s, double p, int w, int h) : base(s, p)
        {
            _Width = w;
            _Height = h;
        }

        public override string Transport()
        {
            return " I need a car";
        }
    }

    public class Sculpture : ArtPiece
    {
        private int _Width;  // immutables
        private int _Height;
        private int _Depth;
        private int _Weight;

        public Sculpture(string s, double p, int w, int h, int d, int wg) : base(s, p)
        {
            _Width = w;
            _Height = h;
            _Depth = d;
            _Weight = wg;
        }

        public override string Transport()
        {
            return " I need a Truck";
        }
    }
}
