using Sailing.Domain.Tests.Helpers;
using Xunit;

namespace Sailing.Domain.Tests;

public class LongitudeTests
{
    [Theory]
    [InlineData(180)]
    [InlineData(0)]
    [InlineData(-180)]
    public void CanBeCreatedWithDecimal(decimal value)
    {
        var l = Longitude.FromDecimal(value);

        l.ShouldBeSuccess();
        l.Value.Value.Should().Be(value);
    }

    [Fact]
    public void MustNotBeGreaterThan180()
    {
        var l = Longitude.FromDecimal(180.000001m);

        l.ShouldBeFailure(
            ErrorResult.Invalid("Longitude", "must not be greater than 180 degrees."));
    }

    [Fact]
    public void MustNotBeLessThanMinus180()
    {
        var l = Longitude.FromDecimal(-180.000001m);

        l.ShouldBeFailure(
            ErrorResult.Invalid("Longitude", "must not be less than -180 degrees."));
    }

    [Fact]
    public void TwoLongitudesWithTheSameValueAreEqual()
    {
        var l1 = Longitude.FromDecimal(90m).Value;
        var l2 = Longitude.FromDecimal(90m).Value;

        l1.Should().Be(l2);
    }

    [Fact]
    public void TwoLongitudesWithDifferentValueAreNotEqual()
    {
        var l1 = Longitude.FromDecimal(90m).Value;
        var l2 = Longitude.FromDecimal(0m).Value;

        l1.Should().NotBe(l2);
    }
}