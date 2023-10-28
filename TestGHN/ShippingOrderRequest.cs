namespace TestGHN
{
    public class ShippingOrderRequest
    {
        public int payment_type_id { get; set; }
        public string note { get; set; }
        public string required_note { get; set; }
        public string? client_order_code { get; set; }
        public string to_name { get; set; }
        public string to_phone { get; set; }
        public string to_address { get; set; }
        public string to_ward_name { get; set; }
        public string to_district_name { get; set; }
        public string to_province_name { get; set; }
        public decimal cod_amount { get; set; }
        public string content { get; set; }
        public decimal weight { get; set; }
        public decimal length { get; set; }
        public decimal width { get; set; }
        public decimal height { get; set; }
        public decimal cod_failed_amount { get; set; }
        public decimal insurance_value { get; set; }
        public int service_id { get; set; }
        public int service_type_id { get; set; }
        public List<Item> items { get; set; }
    }
}



