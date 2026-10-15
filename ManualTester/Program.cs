namespace CSC160_ConsoleMenu
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //DemoInput();
            //DemoBoolean();
            //DemoInt();
            DemoMenu();
        }

        private static void DemoInput()
        {
            string name = CIO.PromptForInput("Enter your name: ", false);
            // This is called string interpolation
            Console.WriteLine($"Howdy, {name}!");
        }

        private static void DemoBoolean()
        {
            bool result = CIO.PromptForBool("Type \"Yes\", or \"No\" ", "yes", "no");
            Console.WriteLine($"You entered: {result}");
        }

        private static void DemoInt()
        {
            int result = CIO.PromptForInt("Enter and integer between 1 and 100: ", 1, 100);
            Console.WriteLine($"You entered: {result}");
        }

        private static void DemoMenu()
        {
            string[] options = { "Play", "Options", "Credits", "Extras", "Achievements" };
            int choice = CIO.PromptForMenuSelection(options, true);
            if (choice > 0)
            {
                Console.WriteLine($"You chose #{choice}: {options[choice - 1]}");
            }
            else
            {
                Console.WriteLine($"You chose #{choice}: Have a great day!");
            }
        }
    }
}
