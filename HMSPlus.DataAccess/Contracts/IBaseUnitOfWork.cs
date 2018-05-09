﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSPlus.DataAccess.Contracts
{
    public interface IBaseUnitOfWork
    {
        int Commit();

        Task<int> CommitAsync();

        int SetIdnetityInsert<T>(bool state) where T : class;

        int ExecuteSql(string query);

        IEnumerable<dynamic> ExecuteSqlQuery<T>(string query, Dictionary<string, object> paramerters);

        IEnumerable<dynamic> ExecuteSqlStoreProcedure<T>(string procedureName, Dictionary<string, object> paramerters);

        IEnumerable<dynamic> ExecutePaginatedDataStoreProcedure<T>(string procedureName, Dictionary<string, object> paramerters, out int totalRecords);

        DbRawSqlQuery<T> StoredProcedure<T>(string procName, params SqlParameter[] parameters);
    }

}
