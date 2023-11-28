
namespace Composite
{
    //public class NewYear_Collection
    //{
    //    private string name;
    //    private List<Mehsul> mehsulList;

    //    public NewYear_Collection(string name_)
    //    {
    //        this.name = name_;
    //        this.mehsulList = new List<Mehsul>();
    //    }

    //    public string getName() { return name; }
    //    public List<Mehsul> getMehsulList() { return mehsulList; }
    //}

    public class Mehsul
    {
        private string name;
        private double price;

        public Mehsul(string name_, double price_)
        {
            this.name = name_;
            this.price = price_;
        }

        public double getPrice() { return price; }
    }

    public class Packet
    {
        private string name;
        private List<Mehsul> mehsulList;

        public Packet(string name_)
        {
            this.name = name_;
            this.mehsulList = new List<Mehsul>();
        }
        public List<Mehsul> getMehsulList() {  return mehsulList; }
        
    }

    public class Basket
    {
        private string name;
        private List<Mehsul> mehsulList;
        private List<Packet> packetList;
        //private List<NewYear_Collection> newYearList;

        public Basket(string name_)
        {
            this .name = name_;
            this.mehsulList = new List<Mehsul>();
            this.packetList = new List<Packet>();
            //this.newYearList = new List<NewYear_Collection>();
        }

        public string getName() { return name; }
        public List<Mehsul> GetMehsulList() { return mehsulList; }
        public List<Packet> getPacketList() {  return packetList; }
        //public List<NewYear_Collection> getNewYear_Collections() { return newYearList; }

        public double getTotalPrice()
        {
            double totalPrice = 0;

            foreach(Mehsul mehsul in mehsulList)
            {
                totalPrice = totalPrice + mehsul.getPrice();

            }

            foreach(Packet packet in packetList)
            {
                List<Mehsul> mehsulList = packet.getMehsulList();

                foreach (Mehsul mehsul in mehsulList)
                {
                    totalPrice = totalPrice + mehsul.getPrice();

                }
            }

            //foreach (NewYear_Collection newYear in newYearList)
            //{
            //    List<Mehsul> newyearList = newYear.getMehsulList();

            //    foreach (Mehsul mehsul in mehsulList)
            //    {
            //        totalPrice = totalPrice + mehsul.getPrice();

            //    }
            //}
            return totalPrice;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
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
            basket.getPacketList().Add(V_packet);
            basket.getPacketList().Add(T_packet);
            basket.GetMehsulList().Add(bread);

            double totalprice = basket.getTotalPrice();
            Console.WriteLine($"Total Price: {totalprice}");
        }
    }
}