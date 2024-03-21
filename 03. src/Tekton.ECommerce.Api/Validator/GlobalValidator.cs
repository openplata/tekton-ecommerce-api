using System.Globalization;
using System.Text.RegularExpressions;

namespace Tekton.ECommerce.Api.Validator
{
    public class GlobalValidator<T>
    {
        private static string patternTexto = @"^[a-zA-Z0-9àáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð \-.'’´,°º#(/)]+$";

        public static readonly Predicate<string> IsName = (d) => (d != null && new Regex(@"^[A-Za-z0-9ñÑäÄëËïÏöÖüÜáéíóúÁÉÍÓÚ\s]+$").IsMatch(d));

        public static readonly Predicate<string> IsNotNullOrEmpty = (d) => (!string.IsNullOrEmpty(d));
        public static readonly Predicate<string> IsNumber = (d) => (d == null || d == "" || new Regex(@"^\d+$").IsMatch(d));
        public static readonly Predicate<int?> IsNumeroPositivo = (d) => (d != null && d.Value > 0);
        public static readonly Predicate<int> IsNumeroPositivoEntero = (d) => (d != null && d >= 0);
        public static readonly Predicate<decimal> IsNumeroPositivoDecimal = (d) => (d != null && d >= 0);
        public static readonly Predicate<string> IsNumberLetter = (d) => d != null && (d == "" || (new Regex(@"^[a-zA-Z\d]+$").IsMatch(d)));

        public static readonly Predicate<string> IsDocumentoTipo = (d) => d != null && new Regex(@"^[2569]{1}$").IsMatch(d);
        public static readonly Predicate<string> IsText = (d) => d != null && (d == "" || new Regex(patternTexto).IsMatch(d));

        public static readonly Predicate<short?> IsValidStatus = (d) => (d != null && d >= 0 && d <= 1);

        //internal static bool (PeriodoEvaluacionRequestDto p)
        //{
        //    throw new NotImplementedException();
        //}
        public static readonly Predicate<string> IsUsuario = (d) => d != null && (new Regex(@"^[a-zA-Z\d]{3,20}$").IsMatch(d));

        
        public static readonly Predicate<DateTime?> IsDateNotNull = (d) => (d != null && d.HasValue);

        public static readonly Predicate<short?> IsShortNotNull = (d) => (d != null && d.HasValue);
        public static readonly Predicate<int?> IsIntNotNull = (d) => (d != null && d.HasValue);

        public static readonly Predicate<string> IsDate = (d) => (d == null || IsValidDate(d));

        private static bool IsValidDate(string value)
        {
            DateTime date;
            return DateTime.TryParse(value, out date);
        }
        private static bool IsValidDate(DateTime? value)
        {
            var valor = (DateTime)value;

            return valor.Year != 1;
        }
        public static bool IsValidLength(string value, short min = 1, short max = 100)
        {
            if (value == null) return false;
            return (value.Length >= min && value.Length <= max);
        }

        public static bool IsValidRangeNumber(int value, short min = 0, short max = 1000)
        {
            return (value >= min && value <= max);
        }

        public static bool IsValidRangeDate(DateTime value, DateTime? min = null, DateTime? max = null)
        {
            if (min == null) return value.Date <= max?.Date;
            if (max == null) return value.Date >= min?.Date;
            return (value.Date >= min?.Date && value.Date <= max?.Date);
        }

    }
}