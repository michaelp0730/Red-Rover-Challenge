using RedRoverChallenge.Helpers;

namespace RedRoverUnitTests;

public class OutputHelperTests
{
    [Test]
    public void AlphabetizeInputString_ShouldAlphabetizeSampleStringCorrectly()
    {
        // Arrange
        const string input = "(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)";
        const string expected = "(email, externalId, id, name, type(customFields(c1, c2, c3), id, name))";

        // Act
        var result = OutputHelper.AlphabetizeInputString(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void AlphabetizeInputString_ShouldAlphabetizeAnotherStringCorrectly()
    {
        // Arrange
        const string input = "(charlie, bravo, alpha, foxtrot(india, golf, customFields(c3, c2, c1)), delta)";
        const string expected = "(alpha, bravo, charlie, delta, foxtrot(customFields(c1, c2, c3), golf, india))";

        // Act
        var result = OutputHelper.AlphabetizeInputString(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void AlphabetizeInputString_ShouldHandleEmptyInput()
    {
        // Arrange
        const string input = "()";
        const string expected = "()";

        // Act
        var result = OutputHelper.AlphabetizeInputString(input);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
