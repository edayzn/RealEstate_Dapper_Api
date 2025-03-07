﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepositories
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly Context _context;

        public TestimonialRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultTestimonialDto>> GetAllTestimonia()
        {

            string query = " Select * From Testimonial";
            using (var conncetion = _context.CreateConnection())
            {


                var values = await conncetion.QueryAsync<ResultTestimonialDto>(query);
                return values.ToList();
            }
        }
    }
}
