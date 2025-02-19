namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class GetProductIdByAppUserDto
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string CoverImage { get; set; }
       
        public string City { get; set; }
        public int AppUserId { get; set; }
        public int Price { get; set; }

    }
}
