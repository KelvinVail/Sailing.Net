namespace Sailing.Domain;

public class Longitude : ValueObject
{
    private Longitude(decimal value) =>
        Value = value;

    public decimal Value { get; }

    public static Result<Longitude, ErrorResult> FromDecimal(decimal value)
    {
        if (value > 180m)
            return ErrorResult.Invalid(nameof(Longitude), "must not be greater than 180 degrees.");
        if (value < -180m)
            return ErrorResult.Invalid(nameof(Longitude), "must not be less than -180 degrees.");

        return new Longitude(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}