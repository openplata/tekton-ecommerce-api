using OP.FK_Framework.SQLServer.Repository;
using Tekton.ECommerce.SQLServer.Configuration.Constants;
using System.Data;
using Tekton.ECommerce.Domain.IQuery.ISQLServer.Core;
using System.Threading.Tasks;
using System.Collections.Generic;
using Tekton.ECommerce.Domain.Entity.Core.Category;
using System.Linq;

namespace Tekton.ECommerce.SQLServer.DB.Query.Core
{
    public class CategoryQuery : QueryGeneric, ICategoryQuery
    {
        public CategoryQuery(string connectionString) : base(connectionString)
        {
        }

        public async Task<USP_CATEGORY_SEL_BY_ID_Result> USP_CATEGORY_SEL_BY_ID(USP_CATEGORY_SEL_BY_ID_Request request)
        {
            var parm = new Parameter[]
                       {
                    new Parameter("@OWNER_ID", request.OWNER_ID),
                    new Parameter("@COMPANY_ID", request.COMPANY_ID),
                    new Parameter("@CATEGORY_ID", request.CATEGORY_ID)
                       };

            var result = await ExecuteReaderAsync<USP_CATEGORY_SEL_BY_ID_Result>(
               UspNameConstants.core.CATEGORY.USP_CATEGORY_SEL_BY_ID, CommandType.StoredProcedure, parm, _commandTimeOutSeconds);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<USP_CATEGORY_SEL_ALL_Result>> USP_CATEGORY_SEL_ALL(USP_CATEGORY_SEL_ALL_Request request)
        {
            var parm = new Parameter[]
                       {
                    new Parameter("@OWNER_ID", request.OWNER_ID),
                    new Parameter("@COMPANY_ID", request.COMPANY_ID)
                       };

            var result = await ExecuteReaderAsync<USP_CATEGORY_SEL_ALL_Result>(
               UspNameConstants.core.CATEGORY.USP_CATEGORY_SEL_ALL, CommandType.StoredProcedure, parm, _commandTimeOutSeconds);

            return result;
        }

        public async Task<IEnumerable<USP_CATEGORY_SEL_ALL_BY_PARENT_ID_Result>> USP_CATEGORY_SEL_ALL_BY_PARENT_ID(USP_CATEGORY_SEL_ALL_BY_PARENT_ID_Request request)
        {
            var parm = new Parameter[]
                       {
                    new Parameter("@OWNER_ID", request.OWNER_ID),
                    new Parameter("@COMPANY_ID", request.COMPANY_ID),
                    new Parameter("@PARENT_ID", request.PARENT_ID)
                       };

            var result = await ExecuteReaderAsync<USP_CATEGORY_SEL_ALL_BY_PARENT_ID_Result>(
               UspNameConstants.core.CATEGORY.USP_CATEGORY_SEL_ALL_BY_PARENT_ID, CommandType.StoredProcedure, parm, _commandTimeOutSeconds);

            return result;
        }
    }
}
