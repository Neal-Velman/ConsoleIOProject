namespace CSC160_ConsoleMenu
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DemoInput();
        }

        private static void DemoInput()
        {
            string name = CIO.PromptForInput("Enter your name: ", false);
            // This is called string interpolation
            Console.WriteLine($"Howdy, {name}!");
        }
    }
}
