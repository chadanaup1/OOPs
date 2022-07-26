//using system;
//using system.collections.generic;
//using system.linq;
//using system.text;
//using system.threading.tasks;


//// todo
////
//// 1. create a class hierarchy (abstract or virtual)
////
//// 2. chain class constructors
////
//// 3. make the classes comparable
////
//// 4. in program, populate an array with instances from all classes of the hierarchy
////
//// 5. sort the array and display the list
////



//namespace Lab1

//{
//    //enum month { jan, feb, mar, aug };
//    //foreach (month i in month  )


//    class Example
//    {

//        account[] accountinfo;

//        static void main(string[] args)
//        {
//            program prg = new program();
//            prg.process();//cut the static rope
//        }
//        void process()
//        {

//            string s = "hello";
//            console.writeline(s);
//            s = "world";
//            console.writeline(s);
//            s = s + "i am the best";

//            stringbuilder s1 = new stringbuilder();
//            s1.append("i");
//            stringbuilder s2 = s1;
//            console.writeline(s2);
//            s1.append("the");
//            s2.append("best");

//            console.writeline(s2);
//            console.writeline(s1);

//            // ask user for number of banks
//            console.write("how many banks? ");

//            //reading number of banks from user and assigning as array size
//            accountinfo = new account[5];


//            // ask user for content of each
//            int counter = 0;
//            for (int i = 0; i < accountinfo.length; i++)
//            {
//                counter += 1;
//                if (i % 2 == 0)
//                {
//                    accountinfo[i] = new savingsaccount("bank" + counter, (i + 0.3) * 0.2, 2000000, 2.5);

//                }
//                else
//                {
//                    accountinfo[i] = new investmentaccount("bank" + counter, (i + 0.3) * 0.2, 2000000, 2.5);
//                }
//            }

//            //display the whole content
//            serializebanks();

//            //interest increased to 2.5%
//            for (int i = 0; i < accountinfo.length; i++)
//            {
//                accountinfo[i].rtofinterest += accountinfo[i].rtofinterest * 0.25;
//            }

//            //interest after increase
//            serializebanks();

//            //sort the array
//            array.sort(accountinfo);

//            // display the sorted content
//            serializebanks();

//        }
//        void serializebanks()
//        {
//            for (int i = 0; i < accountinfo.length; i++)
//            {
//                console.writeline(accountinfo[i].tostring());
//            }
//        }
//    }

//    abstract class account : icomparable
//    {

//        private string bankname;

//        private double rateofinterest;

//        public string bkname
//        {
//            get { return bankname; }
//            set
//            {
//                this.bankname = value;
//            }
//        }
//        public double rtofinterest
//        {
//            get { return rateofinterest; }
//            set
//            {
//                if (value < (this.rateofinterest * 10.5)) //no change if rate of interest is >10.5
//                    this.rateofinterest = value;
//                else
//                    this.rateofinterest *= 0.25;
//            }
//        }

//        //constructor
//        public account(string bkname, double rt)
//        {
//            this.bankname = bkname;
//            this.rateofinterest = rt;
//        }


//        public override string tostring()
//        {
//            return bankname + " " + "rateofinterest " + rateofinterest;
//        }

//        public int compareto(object obj)
//        {
//            return rateofinterest.compareto((obj as account).rateofinterest);
//        }
//    }
//    class savingsaccount : account
//    {
//        private double savingsbalance;
//        private double savingsrateofinterest;

//        public savingsaccount(string bkname, double rt, double svngsbal, double svngsrtintrst) : base(bkname, rt)
//        {
//            this.bkname = bkname;
//            this.rtofinterest = rt;
//            this.savingsbalance = svngsbal;
//            this.savingsrateofinterest = svngsrtintrst;
//        }

//        public void withdrawamount()
//        {
//            savingsbalance *= savingsrateofinterest;
//        }
//    }
//    class investmentaccount : account
//    {
//        private double investmentbalance;
//        private double investmentrateofinterest;

//        public investmentaccount(string bkname, double rt, double invstbal, double invstrtintrst) : base(bkname, rt)
//        {
//            this.bkname = bkname;
//            this.rtofinterest = rt;
//            this.investmentbalance = invstbal;
//            this.investmentrateofinterest = invstrtintrst;
//        }

//        public void withdrawamount()
//        {
//            investmentbalance *= investmentrateofinterest;
//        }
//    }
//}




//}
