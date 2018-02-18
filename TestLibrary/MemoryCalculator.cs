using System;

namespace TestLibrary
{
    public class MemoryCalculator
    {
        public int CurrentValue { get; private set; }

        public void Add(int number)
        {
            CurrentValue += number;
        }

        public void Subtract(int number)
        {
            CurrentValue -= number;
        }

        public void Divide(int number)
        {
            CurrentValue = CurrentValue / number;
        }
    }
}
