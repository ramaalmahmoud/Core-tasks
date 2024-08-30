namespace _29_30_2024.DTO
{
    public class cartItemResponseDTO
    {
        public int CartItemId { get; set; }

        public int? CartId { get; set; }
        public int Quantity { get; set; }

        public productDTO Product { get; set; }
    }
}
