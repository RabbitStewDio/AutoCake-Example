using Example.Animals;
using NUnit.Framework;

namespace Example.Tests.NUnit3
{
	[TestFixture]
	[Category("TraitOnClass")]
	[Property("RefSpec","ClassValue")]
    public sealed class AnimalTests
    {
        [Test]
        [Category("TraitOnMethod")]
        public void The_Cat_Should_Meow()
        {
            // Given
            var cat = new Cat();

            // When
            var result = cat.Talk();

            // Then
            Assert.AreEqual("Meow", result);
        }

        [Test]
        [Category("TraitOnMethod")]
        [Property("RefSpec","SomeRandomValue")]
        public void The_Dog_Should_Bark()
        {
            // Given
            var dog = new Dog();

            // When
            var result = dog.Talk();

            // Then
            Assert.AreEqual("Woof", result);
        }
    }
}
