using OP.FK_Framework.SQLServer.Repository;
using Tekton.ECommerce.SQLServer.Configuration.Constants;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using Tekton.ECommerce.Domain.ICommand.ISQLServer.Core;
using Tekton.ECommerce.Domain.Entity.Core.Product;

namespace Tekton.ECommerce.SQLServer.DB.Command.Core
{
    public class ProductCommand : QueryGeneric, IProductCommand
    {
        public ProductCommand(string connectionString) : base(connectionString)
        {
        }

        public async Task<USP_PRODUCT_INS_Result> USP_PRODUCT_INS(USP_PRODUCT_INS_Request request)
        {
            var parm = new Parameter[]
            {
                new Parameter("@OWNER_ID", request.OWNER_ID),
                new Parameter("@COMPANY_ID", request.COMPANY_ID),

                new Parameter("@CODE", request.CODE),
                new Parameter("@EXTERNAL_CODE", request.EXTERNAL_CODE),
                new Parameter("@PRODUCT_NAME", request.PRODUCT_NAME),
                new Parameter("@PRODUCT_DESCRIPTION", request.PRODUCT_DESCRIPTION),

                new Parameter("@ORDERING", request.ORDERING),

                new Parameter("@BARCODE", request.BARCODE),
                new Parameter("@BRAND_ID", request.BRAND_ID),
                new Parameter("@CATEGORY_ID", request.CATEGORY_ID),
                new Parameter("@SUBCATEGORY_ID", request.SUBCATEGORY_ID),

                new Parameter("@STOCK", request.STOCK),
                new Parameter("@PRICE", request.PRICE),

                new Parameter("@COLOR", request.COLOR),
                new Parameter("@ICON", request.ICON),

                new Parameter("@DATA1", request.DATA1),
                new Parameter("@DATA2", request.DATA2),
                new Parameter("@ADDITIONAL", request.ADDITIONAL),
                new Parameter("@OBSERVATION", request.OBSERVATION),

                new Parameter("@STATUS", request.STATUS),

                new Parameter("@USER_ID", request.USER_ID),
                new Parameter("@HOST", request.HOST)
            };

            var result = await ExecuteReaderAsync<USP_PRODUCT_INS_Result>(
               UspNameConstants.core.PRODUCT.USP_PRODUCT_INS, CommandType.StoredProcedure, parm, _commandTimeOutSeconds);

            return result.FirstOrDefault();
        }

        public async Task<USP_PRODUCT_UPD_Result> USP_PRODUCT_UPD(USP_PRODUCT_UPD_Request request)
        {
            var parm = new Parameter[]
            {
                new Parameter("@OWNER_ID", request.OWNER_ID),
                new Parameter("@COMPANY_ID", request.COMPANY_ID),

                new Parameter("@PRODUCT_ID", request.PRODUCT_ID),
                new Parameter("@CODE", request.CODE),
                new Parameter("@EXTERNAL_CODE", request.EXTERNAL_CODE),
                new Parameter("@PRODUCT_NAME", request.PRODUCT_NAME),
                new Parameter("@PRODUCT_DESCRIPTION", request.PRODUCT_DESCRIPTION),

                new Parameter("@ORDERING", request.ORDERING),

                new Parameter("@BARCODE", request.BARCODE),
                new Parameter("@BRAND_ID", request.BRAND_ID),
                new Parameter("@CATEGORY_ID", request.CATEGORY_ID),
                new Parameter("@SUBCATEGORY_ID", request.SUBCATEGORY_ID),

                new Parameter("@STOCK", request.STOCK),
                new Parameter("@PRICE", request.PRICE),

                new Parameter("@COLOR", request.COLOR),
                new Parameter("@ICON", request.ICON),

                new Parameter("@DATA1", request.DATA1),
                new Parameter("@DATA2", request.DATA2),
                new Parameter("@ADDITIONAL", request.ADDITIONAL),
                new Parameter("@OBSERVATION", request.OBSERVATION),

                new Parameter("@STATUS", request.STATUS),

                new Parameter("@IS_ACTIVE", request.IS_ACTIVE),

                new Parameter("@USER_ID", request.USER_ID),
                new Parameter("@HOST", request.HOST)
            };

            var result = await ExecuteReaderAsync<USP_PRODUCT_UPD_Result>(
               UspNameConstants.core.PRODUCT.USP_PRODUCT_UPD, CommandType.StoredProcedure, parm, _commandTimeOutSeconds);

            return result.FirstOrDefault();
        }
    }
}