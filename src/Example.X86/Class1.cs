using System;
using Example.Animals;

namespace Example.X86
{
    public class HelloWorld
    {
        public string Message { get; set; }

        public HelloWorld()
        {
            // Adding the cat just to make sure we reference the base MSIL project.
            // Yes, I am a cat person :)
            Message = "Hello World with X86 architecture. " + new Cat();
        }
    }
}