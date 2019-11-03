namespace Vidly.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public bool IsSubscribedToNewsLatter { get; set; }
        public MemberShipType MemberShipType { get; set; }
        public int MemberShipId{ get; set; }
    }
}