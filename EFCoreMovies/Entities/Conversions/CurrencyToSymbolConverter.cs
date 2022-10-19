using EFCoreMovies.Entities.Enumerations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreMovies.Entities.Conversions;

public class CurrencyToSymbolConverter : ValueConverter<Currency, string>
{
    public CurrencyToSymbolConverter() : base(
        value => MapCurrencyToString(value),
        value => MapStringToCurrency(value))
    {
    }

    private static string MapCurrencyToString(Currency value)
    {
        return value switch
        {
            Currency.NepaleseRupee => "Npr",
            Currency.UsDollar => "$",
            Currency.CanadianDollar => "Cad",
            _ => ""
        };
    }

    private static Currency MapStringToCurrency(string value)
    {
        return value switch
        {
            "Npr" => Currency.NepaleseRupee,
            "$" => Currency.UsDollar,
            "Cad" => Currency.CanadianDollar,
            _ => Currency.Unknown
        };
    }
}