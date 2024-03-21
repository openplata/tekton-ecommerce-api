
namespace Tekton.ECommerce.Api.Filters
{
    public class BusinessRuleValidationException : Exception
    {
        public IBusinessRule BrokenRule { get; }

        public string Details { get; }

        public BusinessRuleValidationException(IBusinessRule brokenRule)
            : base(brokenRule.Message)
        {
            BrokenRule = brokenRule;
            Details = brokenRule.Message;
            Source = brokenRule.Code ?? "";
        }

        public override string ToString()
        {
            return BrokenRule.GetType().FullName + ": " + BrokenRule.Message;
        }
    }
}