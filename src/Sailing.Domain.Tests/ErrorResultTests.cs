using Xunit;

namespace Sailing.Domain.Tests;

public sealed class ErrorResultTests
{
    [Fact]
    public void EmptyErrorReturnsDefaultValues()
    {
        var error = ErrorResult.Empty();

        error.Code.Should().Be("value.must.not.be.empty");
        error.Message.Should().Be("'Value' must not be empty.");
    }

    [Theory]
    [InlineData("parameterName", "Parameter Name")]
    [InlineData("input", "Input")]
    [InlineData("variable", "Variable")]
    public void EmptyErrorDisplaysParameterNameInTitleCase(string parameterName, string expected)
    {
        var error = ErrorResult.Empty(parameterName);

        error.Message.Should().Be($"'{expected}' must not be empty.");
    }

    [Fact]
    public void TwoErrorsWithTheSameErrorCodeAreEqual()
    {
        var error1 = ErrorResult.Empty();
        var error2 = ErrorResult.Empty("ParameterName");

        error1.Should().Be(error2);
        error1.Should().BeRankedEquallyTo(error2);
    }

    [Fact]
    public void InvalidErrorReturnsDefaultValues()
    {
        var error = ErrorResult.Invalid();

        error.Code.Should().Be("value.must.be.valid");
        error.Message.Should().Be("'Value' must be valid.");
    }

    [Theory]
    [InlineData("parameterName", "Parameter Name")]
    [InlineData("input", "Input")]
    [InlineData("variable", "Variable")]
    public void InvalidErrorDisplaysParameterNameInTitleCase(string parameterName, string expected)
    {
        var error = ErrorResult.Invalid(parameterName);

        error.Message.Should().Be($"'{expected}' must be valid.");
    }

    [Theory]
    [InlineData("must be longer.")]
    [InlineData("try again.")]
    public void InvalidErrorDisplayCustomMessage(string message)
    {
        var error = ErrorResult.Invalid("Name", message);

        error.Message.Should().Be($"'Name' {message}");
    }
}