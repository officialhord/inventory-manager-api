namespace Models
{   
    public class Inventory
    {
        public long id { get; set; }
        public string name { get; set; } = string.Empty;
        public int quantity { get; set; }
        public decimal price { get; set; }
        public long vendorId { get; set; }
        public string description { get; set; } = string.Empty;
        public DateTime dateCreated { get; set; }
        public DateTime lastModified { get; set; }
        public string remarks { get; set; } = string.Empty;
    }
}
