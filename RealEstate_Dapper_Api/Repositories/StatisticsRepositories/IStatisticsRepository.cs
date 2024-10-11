using RealEstate_Dapper_Api.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories
{
    public interface IStatisticsRepository
    {
        int CategoryCount();
        int ActiveCategoryCount();
        int PassiveCategoryCount();
        int ProductCount();
        //Toplam Daire Sayısı
        int ApartmenCount();
        string EmployeeNameByMaxProductCount();
        string CategoryNameByMaxProductCount();
        //Ortala Fiyat
        decimal AverageProductPriceByRent();
        decimal AverageProductPriceBySale();

      //  ilan içerisinde en fazla hangi şehir var
        string CityNameByMaxProductCount();

        //Kaç farklı şehirden ilan var
        int DifferentCityCount();

        //En son yüklenen ilan fiyatı
        decimal LastProductPrice();

        //En Yeni ve En eski Bina
        string NewestBuildingYear();
        string OldestBuildingYear();

        //ortalama oda sayısı
        int AverageRoomCount();

        int ActiveEmployeeCount();
    }
}
