using Sailing.Domain.Tests.Helpers;
using Xunit;

namespace Sailing.Domain.Tests;

public class LatitudeTests
{
    [Theory]
    [InlineData(90)]
    [InlineData(0)]
    [InlineData(-90)]
    public void CanBeCreatedWithDecimal(decimal value)
    {
        var lat = Latitude.FromDecimal(value);

        lat.ShouldBeSuccess();
        lat.Value.Value.Should().Be(value);
    }

    [Fact]
    public void MustNotBeGreaterThan90()
    {
        var lat = Latitude.FromDecimal(90.000001m);

        lat.ShouldBeFailure(
            ErrorResult.Invalid("latitude", "must not be greater than 90 degrees."));
    }

    [Fact]
    public void MustNotBeLessThanMinus90()
    {
        var lat = Latitude.FromDecimal(-90.000001m);

        lat.ShouldBeFailure(
            ErrorResult.Invalid("latitude", "must not be less than -90 degrees."));
    }

    [Fact]
    public void TwoLatitudesWithTheSameValueAreEqual()
    {
        var lat1 = Latitude.FromDecimal(90m).Value;
        var lat2 = Latitude.FromDecimal(90m).Value;

        lat1.Should().Be(lat2);
    }

    [Fact]
    public void TwoLatitudesWithDifferentValueAreNotEqual()
    {
        var lat1 = Latitude.FromDecimal(90m).Value;
        var lat2 = Latitude.FromDecimal(0m).Value;

        lat1.Should().NotBe(lat2);
    }
}
