using OP.FK_Framework.SQLServer.Repository;

namespace Tekton.ECommerce.SQLServer.DB
{
    public abstract class QueryGeneric : BaseUnitOfWork
    {
        protected int? _commandTimeOutSeconds = 30;

        protected QueryGeneric(string connectionString) : base(connectionString)
        {
        }
    }
}