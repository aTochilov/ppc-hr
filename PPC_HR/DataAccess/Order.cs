
namespace PPC_HR.DataAccess
{
    public class Order
    {
        public int orderId { get; set; }
        public short emplId { get; set; }
        public string emplName { get; set; }
        public string orderName { get; set; }
        public string orderTheme { get; set; }
        public int orderThemeId { get; set; }
        public string orderDate { get; set; }
        public byte[] orderScan { get; set; }
    }

    public class OrderTheme
    {
        public string orderTheme { get; set; }
        public int orderThemeId { get; set; }
    }
}
