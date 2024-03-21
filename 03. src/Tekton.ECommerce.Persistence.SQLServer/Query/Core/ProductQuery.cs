using OP.FK_Framework.SQLServer.Repository;
using Tekton.ECommerce.SQLServer.Configuration.Constants;
using System.Data;
using Tekton.ECommerce.Domain.IQuery.ISQLServer.Core;
using System.Threading.Tasks;
using System.Collections.Generic;
using Tekton.ECommerce.Domain.Entity.Core.Product;
using System.Linq;

namespace Tekton.ECommerce.SQLServer.DB.Query.Core
{
    public class ProductQuery : QueryGeneric, IProductQuery
    {
        public ProductQuery(string connectionString) : base(connectionString)
        {
        }

        public async Task<USP_PRODUCT_SEL_BY_ID_Result> USP_PRODUCT_SEL_BY_ID(USP_PRODUCT_SEL_BY_ID_Request request)
        {
            var parm = new Parameter[]
                       {
                    new Parameter("@OWNER_ID", request.OWNER_ID),
                    new Parameter("@COMPANY_ID", request.COMPANY_ID),
                    new Parameter("@PRODUCT_ID", request.PRODUCT_ID)
                       };

            var result = await ExecuteReaderAsync<USP_PRODUCT_SEL_BY_ID_Result>(
               UspNameConstants.core.PRODUCT.USP_PRODUCT_SEL_BY_ID, CommandType.StoredProcedure, parm, _commandTimeOutSeconds);

            return result.FirstOrDefault();
        }

    }
}
