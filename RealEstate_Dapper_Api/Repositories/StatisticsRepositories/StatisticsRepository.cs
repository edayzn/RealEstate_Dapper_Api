
using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly Context _context;

        public StatisticsRepository(Context context)
        {
            _context = context;
        }
        public int  ActiveCategoryCount()
        {
            string query = " Select Count(*) From Category where CategoryStatus=1";
            using (var conncetion = _context.CreateConnection())
            {
                var values =  conncetion.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ActiveEmployeeCount()
        {
            string query = " Select Count(*) From Employee where Status=1";
            using (var conncetion = _context.CreateConnection())
            {
                var values = conncetion.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ApartmenCount()
        {
            string query = "Select Count(*) From Product where Title Like '%Daire%'";
            using (var conncetion = _context.CreateConnection())
            {
                var values = conncetion.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public decimal AverageProductPriceByRent()
        {
            string query = "Select AVG(Price) From Product where Type='Kiralık'";
            using (var conncetion = _context.CreateConnection())
            {
                var values = conncetion.QueryFirstOrDefault<decimal>(query);
                return values;
            };
        }

        public decimal AverageProductPriceBySale()
        {
            string query = "Select AVG(Price) From Product where Type='Satılık'";
            using (var conncetion = _context.CreateConnection())
            {
                var values = conncetion.QueryFirstOrDefault<decimal>(query);
                return values;
            };
        }

        public int AverageRoomCount()
        {
            string query = "Select Avg(RoomCount) From ProductDetails";
            using (var conncetion = _context.CreateConnection())
            {
                var values = conncetion.QueryFirstOrDefault<int>(query);
                return values;
            };
        }

        public int CategoryCount()
        {
            string query = "Select Count(*) From Category";
            using (var conncetion = _context.CreateConnection())
            {
                var values = conncetion.QueryFirstOrDefault<int>(query);
                return values;
            };
        }

        public string CategoryNameByMaxProductCount()
        {
            string query = "Select top(1) CategoryName,Count(*) From Product inner join Category On Product.ProductCategory=Category.CategoryID Group By CategoryName order By Count(*) Desc";
            using (var conncetion = _context.CreateConnection())
            {
                var values = conncetion.QueryFirstOrDefault<string>(query);
                return values;
            };
        }

        public string CityNameByMaxProductCount()
        {
            string query = "Select top(1) City,Count(*) From Product Group By City order By Count(*) Desc";
            using (var conncetion = _context.CreateConnection())
            {
                var values = conncetion.QueryFirstOrDefault<string>(query);
                return values;
            };
        }

        public int DifferentCityCount()
        {
            string query = "Select Count(Distinct( City)) From Product ";
            using (var conncetion = _context.CreateConnection())
            {
                var values = conncetion.QueryFirstOrDefault<int>(query);
                return values;
            };
        }

        public string EmployeeNameByMaxProductCount()
        {
            string query = "Select Name,Count(*) 'product_count' From Product inner join Employee On Product.AppUserId=Employee.EmployeeID Group By Name Order By product_count Desc";
            using (var conncetion = _context.CreateConnection())
            {
                var values = conncetion.QueryFirstOrDefault<string>(query);
                return values;
            };
        }

        public decimal LastProductPrice()
        {
            string query = "Select top(1) Price From Product Order By ProductID Desc";
            using (var conncetion = _context.CreateConnection())
            {
                var values = conncetion.QueryFirstOrDefault<decimal>(query);
                return values;
            };
        }

        public string NewestBuildingYear()
        {
            string query = "Select top(1) BuildYear From ProductDetails Order By BuildYear Desc";
            using (var conncetion = _context.CreateConnection())
            {
                var values = conncetion.QueryFirstOrDefault<string>(query);
                return values;
            };
        }

        public string OldestBuildingYear()
        {
            string query = "Select top(1) BuildYear From ProductDetails Order By BuildYear";
            using (var conncetion = _context.CreateConnection())
            {
                var values = conncetion.QueryFirstOrDefault<string>(query);
                return values;
            };
        }

        public int PassiveCategoryCount()
        {
            
            string query = "Select Count(*) From Category Where CategoryStatus=0";
            using (var conncetion = _context.CreateConnection())
            {
                var values = conncetion.QueryFirstOrDefault<int>(query);
                return values;
            };
        }

        public int ProductCount()
        {

            string query = "Select Count(*) From Product";
            using (var conncetion = _context.CreateConnection())
            {
                var values = conncetion.QueryFirstOrDefault<int>(query);
                return values;
            };
        }
    }
}
