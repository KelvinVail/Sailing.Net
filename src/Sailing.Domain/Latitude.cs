namespace Sailing.Domain;

public class Latitude : ValueObject
{
    private Latitude(decimal value) =>
        Value = value;

    public decimal Value { get; }

    public static Result<Latitude, ErrorResult> FromDecimal(decimal value)
    {
        if (value > 90m)
            return ErrorResult.Invalid(nameof(Latitude), "must not be greater than 90 degrees.");
        if (value < -90m)
            return ErrorResult.Invalid(nameof(Latitude), "must not be less than -90 degrees.");

        return new Latitude(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
