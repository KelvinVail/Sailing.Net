namespace Sailing.Domain;

public class Latitude : ValueObject
{
    private Latitude(decimal value) =>
        Value = value;

    public decimal Value { get; }

    public static Result<Latitude, ErrorResult> FromDecimal(decimal lat)
    {
        if (lat > 90m)
            return ErrorResult.Invalid(nameof(Latitude), "must not be greater than 90 degrees.");
        if (lat < -90m)
            return ErrorResult.Invalid(nameof(Latitude), "must not be less than -90 degrees.");

        return new Latitude(lat);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
