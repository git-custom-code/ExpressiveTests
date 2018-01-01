namespace CustomCode.Test.BehaviorDrivenDevelopment.Configuration.Tests
{
    using System;
    using Xunit;

    /// <summary>
    /// Test cases for the <see cref="MessageFormatter"/> type.
    /// </summary>
    [Trait("Category", "Configuration")]
    public sealed class MessageFormatterTest
    {
        [Fact(DisplayName = "FormatMessage (without reason)")]
        public void FormatMessageWithoutReasonSuccess()
        {
            // Given
            var formatter = new MessageFormatter();

            // When
            var actual = formatter.FormatMessage("1", "2", "be 3", null);

            // Then
            var rn = Environment.NewLine;
            Assert.Equal($"{rn}1{rn}is 2{rn}but was expected to be 3", actual);
        }

        [Fact(DisplayName = "FormatMessage (with reason)")]
        public void FormatMessageWithReasonSuccess()
        {
            // Given
            var formatter = new MessageFormatter();

            // When
            var actual = formatter.FormatMessage("1", "2", "be 3", "4");

            // Then
            var rn = Environment.NewLine;
            Assert.Equal($"{rn}1{rn}is 2{rn}but was expected to be 3{rn}because 4", actual);
        }
    }
}