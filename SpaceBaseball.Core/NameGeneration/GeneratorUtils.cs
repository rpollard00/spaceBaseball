namespace SpaceBaseball.Core.NameGeneration;

public static class GeneratorUtils
{
    public static char WheelSelect(Dictionary<char, int> charFrequencyDict, int totalCount)
    {
        Random rng = new();
        int selectedIndex = rng.Next(totalCount + 1);
        int currentIndex = 0;

        foreach (var (k, v) in charFrequencyDict)
        {
            if (selectedIndex <= currentIndex + v)
            {
                return k;
            }

            currentIndex += v;
        }

        throw new IndexOutOfRangeException("Provided totalCount was incorrect");
    }

    public static int DiceRoller(int numDice, int diceSides, int discardDice = 0)
    {
        if (numDice <= 0)
        {
            throw new ArgumentOutOfRangeException($"Invalid argument value provided for numDice: {numDice}.");
        }
        if (diceSides < 2)
        {
            throw new ArgumentOutOfRangeException($"Invalid argument value provided for diceSides: {diceSides}.");
        }
        if (discardDice >= numDice)
        {
            throw new ArgumentOutOfRangeException($"Invalid argument value provided for discardDice: {discardDice}.");
        }
        
        Random rng = new();

        PriorityQueue<int, int> rolls = new();

        for (int i = 0; i < numDice; i++)
        {
            int currentRoll = 1 + rng.Next(diceSides);
            Console.WriteLine($"DiceRoller: Rolled: {currentRoll}");
            rolls.Enqueue(currentRoll, currentRoll);
             
        }

        while (discardDice > 0)
        {
            var discard = rolls.Dequeue();
            Console.WriteLine($"Discarded {discard} from diceRoller. Discards remaining: {discardDice}");
            discardDice--;
        }

        int sum = 0;
        while (rolls.Count > 0)
        {
            sum += rolls.Dequeue();
        }

        return sum;

    }
}