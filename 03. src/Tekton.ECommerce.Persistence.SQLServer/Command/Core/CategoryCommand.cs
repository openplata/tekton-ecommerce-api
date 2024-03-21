using OP.FK_Framework.SQLServer.Repository;
using Tekton.ECommerce.SQLServer.Configuration.Constants;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using Tekton.ECommerce.Domain.ICommand.ISQLServer.Core;
using Tekton.ECommerce.Domain.Entity.Core.Category;

namespace Tekton.ECommerce.SQLServer.DB.Command.Core
{
    public class CategoryCommand : QueryGeneric, ICategoryCommand
    {
        public CategoryCommand(string connectionString) : base(connectionString)
        {
        }

        public async Task<USP_CATEGORY_INS_Result> USP_CATEGORY_INS(USP_CATEGORY_INS_Request request)
        {
            var parm = new Parameter[]
            {
                new Parameter("@OWNER_ID", request.OWNER_ID),
                new Parameter("@COMPANY_ID", request.COMPANY_ID),

                new Parameter("@CODE", request.CODE),
                new Parameter("@ORDERING", request.ORDERING),
                new Parameter("@CATEGORY_NAME", request.CATEGORY_NAME),
                
                new Parameter("@COLOR", request.COLOR),
                new Parameter("@ICON", request.ICON),

                new Parameter("@DATA1", request.DATA1),
                new Parameter("@DATA2", request.DATA2),
                new Parameter("@ADDITIONAL", request.ADDITIONAL),
                new Parameter("@OBSERVATION", request.OBSERVATION),

                new Parameter("@PARENT_ID", request.PARENT_ID),

                new Parameter("@USER_ID", request.USER_ID),
                new Parameter("@HOST", request.HOST)
            };

            var result = await ExecuteReaderAsync<USP_CATEGORY_INS_Result>(
               UspNameConstants.core.CATEGORY.USP_CATEGORY_INS, CommandType.StoredProcedure, parm, _commandTimeOutSeconds);

            return result.FirstOrDefault();
        }

        public async Task<USP_CATEGORY_UPD_Result> USP_CATEGORY_UPD(USP_CATEGORY_UPD_Request request)
        {
            var parm = new Parameter[]
            {
                new Parameter("@OWNER_ID", request.OWNER_ID),
                new Parameter("@COMPANY_ID", request.COMPANY_ID),

                new Parameter("@CATEGORY_ID", request.CATEGORY_ID),
                new Parameter("@CODE", request.CODE),
                new Parameter("@ORDERING", request.ORDERING),
                new Parameter("@CATEGORY_NAME", request.CATEGORY_NAME),

                new Parameter("@COLOR", request.COLOR),
                new Parameter("@ICON", request.ICON),

                new Parameter("@DATA1", request.DATA1),
                new Parameter("@DATA2", request.DATA2),
                new Parameter("@ADDITIONAL", request.ADDITIONAL),
                new Parameter("@OBSERVATION", request.OBSERVATION),

                new Parameter("@PARENT_ID", request.PARENT_ID),

                new Parameter("@IS_ACTIVE", request.IS_ACTIVE),
                new Parameter("@USER_ID", request.USER_ID),
                new Parameter("@HOST", request.HOST)
            };

            var result = await ExecuteReaderAsync<USP_CATEGORY_UPD_Result>(
               UspNameConstants.core.CATEGORY.USP_CATEGORY_UPD, CommandType.StoredProcedure, parm, _commandTimeOutSeconds);

            return result.FirstOrDefault();
        }
    }
}