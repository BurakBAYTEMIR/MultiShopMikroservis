using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos.Coupon;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons (CouponCode,CouponRate,CouponIsActive,CouponValidDate) values (@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.CouponCode);
            parameters.Add("@rate", createCouponDto.CouponRate);
            parameters.Add("@isActive", createCouponDto.CouponIsActive);
            parameters.Add("@validDate", createCouponDto.CouponValidDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "Delete From Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
            string query = "Select * From Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            string query = "Select * From Coupons Where CouponId=@couponId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@couponId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query, paramaters);
                return values;
            }
        }

        public async Task<ResultCouponDto> GetCodeDetailByCodeAsync(string code)
        {
            string query = "Select * From Coupons Where CouponCode=@couponCode";
            var parameters = new DynamicParameters();
            parameters.Add("@couponCode", code);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultCouponDto>(query, parameters);
                return values;
            }
        }

        public async Task<int> GetDiscountCouponCount()
        {
            string query = "Select Count(*) From Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);
                return values;
            }
        }

        public int GetDiscountCouponCountRate(string code)
        {
            string query = "Select Rate From Coupons Where CouponCode=@couponCode";
            var parameters = new DynamicParameters();
            parameters.Add("@couponCode", code);
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set CouponCode=@code,CouponRate=@rate,CouponIsActive=@isActive,CouponValidDate=@validDate where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", updateCouponDto.CouponId);
            parameters.Add("@code", updateCouponDto.CouponCode);
            parameters.Add("@rate", updateCouponDto.CouponRate);
            parameters.Add("@isActive", updateCouponDto.CouponIsActive);
            parameters.Add("@validDate", updateCouponDto.CouponValidDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
