namespace Sailing.Domain;

public sealed class ErrorResult : ValueObject
{
    private ErrorResult(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; }

    public string Message { get; }

    public static ErrorResult Empty(string? paramName = null) =>
        new ("value.must.not.be.empty",
            $"'{Humanize(paramName)}' must not be empty.");

    public static ErrorResult Invalid(string? paramName = null, string? message = null) =>
        new ("value.must.be.valid",
            $"'{Humanize(paramName)}' {message ?? "must be valid."}");

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }

    private static string Humanize(string? paramName = null) =>
        paramName?.Humanize().Transform(To.TitleCase) ?? "Value";
}