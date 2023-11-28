namespace Composite_After
{

    public interface ICanPriced
    {
        public double getPrice();
    }

    //public class NewYear_Collection : ICanPriced
    //{
    //    private string name;
    //    private List<Mehsul> mehsulList;

    //    public NewYear_Collection(string name_)
    //    {
    //        this.name = name_;
    //        this.mehsulList = new List<Mehsul>();
    //    }
    //    public List<Mehsul> getMehsulList() { return mehsulList; }

    //    public double getPrice()
    //    {
    //        double totalMehsul = SumPrice.getTotalMehsulPrice(mehsulList);

    //        return totalMehsul;
    //    }
    //}

    public class Mehsul : ICanPriced
    {
        private string name;
        private double price;

        public Mehsul(string name_, double price_)
        {
            this.name = name_;
            this.price = price_;
        }
        public double getPrice()
        {
            return price;
        }



    }

    public class SumPrice
    {
        public static double getTotalMehsulPrice(List<Mehsul> mehsullist)
        {
            double totalPrice = 0;

            foreach(Mehsul mehsul in mehsullist)
            {
                totalPrice = totalPrice + mehsul.getPrice();
            }

            return totalPrice;
        }

        public static double getTotalPacketPrice(List<Packet> packets)
        {
            double totalPrice = 0;

            foreach (Packet packet in packets)
            {
                totalPrice = totalPrice+packet.getPrice();
            }
            return totalPrice;
        }
    }

    public class Packet : ICanPriced
    {
        private string name;
        private List<Mehsul> mehsulList;

        public double getPrice()
        {
            return SumPrice.getTotalMehsulPrice(mehsulList);
        }
        public Packet(string name_)
        {
            this.name = name_;
            this.mehsulList = new List<Mehsul>();
        }
        public List<Mehsul > getMehsulList() { return mehsulList; }
    }

    public class Basket
    {
        private List<ICanPriced> canpics;
        private string name;

        public Basket(string name_)
        {
            this.name = name_;
            this.canpics = new List<ICanPriced>();
        }

        public double getTotalPrice()
        {
            double totalPrice = 0;

            foreach(ICanPriced canPriced in canpics)
            {
                totalPrice = totalPrice + canPriced.getPrice();
            }
            return totalPrice;
        }
        public string getName() { return name; }

        public List<ICanPriced> getCanpics() { return canpics; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //NewYear_Collection newYear_c = new NewYear_Collection("New Year Collection");

            //Mehsul yolka = new Mehsul("Yolka", 200);
            //Mehsul toy = new Mehsul("Toy", 5.40);
            //newYear_c.getMehsulList().Add(yolka);
            //newYear_c.getMehsulList().Add(toy);


            Mehsul tomato = new Mehsul("Tomato", 5);
            Mehsul potato = new Mehsul("Potato", 3);

            Packet V_packet = new Packet("Vegetable Packet");
            V_packet.getMehsulList().Add(potato);
            V_packet.getMehsulList().Add(tomato);

            Mehsul computer = new Mehsul("HP Victus", 1500);
            Mehsul phone = new Mehsul("Iphone 15 Pro", 2350);

            Packet T_packet = new Packet("Technology Packet");
            T_packet.getMehsulList().Add(computer);
            T_packet.getMehsulList().Add(phone);

            Mehsul bread = new Mehsul("Bread", 1);

            Basket basket = new Basket("My Basket");
            basket.getCanpics().Add(V_packet);
            basket.getCanpics().Add(T_packet);
            basket.getCanpics().Add(bread);
            //basket.getCanpics().Add(newYear_c);

            double totalprice = basket.getTotalPrice();
            Console.WriteLine($"Total Price: {totalprice}");
        }
    }
}