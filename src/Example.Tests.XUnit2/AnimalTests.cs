using Example.Animals;
using Xunit;

namespace Example.Tests.XUnit2
{
    [Trait("Category","TraitOnClass")]
    public class AnimalTests
    {
        [Fact]
        [Trait("Category","TraitOnMethod")]
        public void The_Cat_Should_Meow()
        {
            // Given
            var cat = new Cat();

            // When
            var result = cat.Talk();

            // Then
            Assert.Equal("Meow", result);
        }

        [Fact]
        [Trait("Category","TraitOnMethod")]
        [Trait("RefSpec","SomeRandomValue")]
        public void The_Dog_Should_Bark()
        {
            // Given
            var dog = new Dog();

            // When
            var result = dog.Talk();

            // Then
            Assert.Equal("Woof", result);
        }
    }
}
