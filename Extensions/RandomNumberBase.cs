namespace CoopSimilation.Extensions
{
    public static class RandomNumberBase
    {



        public static int Next(this Random random, int[] numbers)
        {
            return random.Next(numbers[0], numbers[1]);
        }
    }
}