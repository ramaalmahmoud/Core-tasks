namespace _28_8_2024.DTO
{
    public class cartDTO
    {
        public int CartId { get; set; }

        public int? UserId { get; set; }

        public cartItemResponseDTO cartItem {  get; set; }
    }
}
