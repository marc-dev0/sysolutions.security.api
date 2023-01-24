﻿using Dapper;
using Sysolutions.Erp.Domain.Entities;
using Sysolutions.Erp.Infrastructure.Persistences.Contexts;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Infrastructure.Persistences.Repositories
{
    public  class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public SubCategoryRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<SubCategory>> GetByCategoryIdAsync(int categoryId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "SubCategoryGetByCategoryId";
                var parameters = new DynamicParameters();
                parameters.Add("CategoryId", categoryId);

                var account = await connection.QueryAsync<SubCategory>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return account;
            }
        }
    }
}
