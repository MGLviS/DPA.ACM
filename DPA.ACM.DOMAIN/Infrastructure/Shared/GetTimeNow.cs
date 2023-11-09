using System;
using DPA.ACM.DOMAIN.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DPA.ACM.DOMAIN.Infrastructure.Shared
{
	public class GetTimeNow
	{
		private readonly AutoCareManagerContext _dbContext;
        public GetTimeNow() { }
        public GetTimeNow(AutoCareManagerContext dbContext)
		{
            _dbContext = dbContext;
        }
        public DateTime GetSqlServerDate()
        {
            var sql = "SELECT GETDATE()";
            var connection = _dbContext.Database.GetDbConnection() as SqlConnection;

            if(connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            using (var command = new SqlCommand(sql, connection))
            {
                var result = (DateTime)command.ExecuteScalar();
                return result;
            }
        }
    }

}

