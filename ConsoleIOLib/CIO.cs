using System;
using System.Collections.Generic;

namespace CSC160_ConsoleMenu
{
    public static class CIO
    {
        /// <summary>
        /// Generates a prompt that allows the user to enter any response and returns the string.
        /// When allowEmpty is true, empty responses are valid. When false, responses must contain
        /// at least one character (including whitespace). Null is never a valid user input for this method.
        /// </summary>
        /// <param name="prompt">the prompt to be displayed to the user.</param>
        /// <param name="allowEmpty">when true, makes empty responses valid</param>
        /// <returns>the input from the user as a string</returns>
        /// <exception cref="ArgumentException">
        ///     prompt is null
        ///     prompt is empty
        ///     prompt is just whitespace
        /// </exception>
        public static string PromptForInput(string prompt, bool allowEmpty)
        {
            if (string.IsNullOrWhiteSpace(prompt))
            {
                throw new ArgumentException("The prompt cannot be null, empty, or whitespace");
            }

            string? input = null;
            bool isInvalid = true;

            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();
                isInvalid = input == null || (string.IsNullOrEmpty(input) && !allowEmpty);

                if (isInvalid)
                {
                    Console.WriteLine("Input was invalid. Please try again.\n");
                }
            }while(isInvalid);

            return input!;
        }

        /// <summary>
        /// Generates a prompt that expects the user to enter one of two responses that will equate
        /// to a boolean value. The trueString represents the case-insensitive response that will equate to true. 
        /// The falseString acts similarly, but for a false boolean value.
        ///     <para>
        ///         Example: Assume this method is called with a trueString argument of "yes" and a falseString
        ///         argument of "no". If the user enters "YES", the method returns true. If the user enters "no",
        ///         the method returns false. All other inputs are considered invalid, the user will be informed, 
        ///         and the prompt will repeat.
        ///     </para>
        /// </summary>
        /// <param name="prompt">the prompt to be displayed to the user</param>
        /// <param name="trueString">the case-insensitive value that will evaluate to true</param>
        /// <param name="falseString">the case-insensitive value that will evaluate to false</param>
        /// <returns>the boolean result based on the user's input</returns>
        /// <exception cref="ArgumentException">
        ///     prompt, trueString, or falseString is null
        ///     prompt is empty
        ///     prompt is just whitespace
        ///     trueString and falseString are case-insensitively equal
        /// </exception>
        public static bool PromptForBool(string prompt, string trueString, string falseString)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generates a prompt that expects a numeric input representing an int value.
        /// This method loops until valid input is given.
        /// </summary>
        /// <param name="prompt">the prompt to be displayed to the user</param>
        /// <param name="min">the inclusive minimum boundary</param>
        /// <param name="max">the inclusive maximum boundary</param>
        /// <returns>the user's valid int value</returns>
        /// <exception cref="ArgumentException">
        ///     prompt is null
        ///     prompt is empty
        ///     prompt is just whitespace
        ///     min is greater than max
        /// </exception>
        public static int PromptForInt(string prompt, int min, int max)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generates a console-based menu using the strings in options as the menu items.
        /// Automatically numbers each option starting at 1 and incrementing by 1.
        /// Reserves the number 0 for the "quit" option when withQuit is true.
        /// </summary>
        /// <param name="options">strings representing the menu options</param>
        /// <param name="withQuit">adds option 0 for "quit" when true</param>
        /// <returns>the int of the selection made by the user</returns>
        /// <exception cref="ArgumentException">
        ///     options is null
        ///     options is empty and withQuit is false
        /// </exception>
        public static int PromptForMenuSelection(IEnumerable<string> options, bool withQuit)
        {
            throw new NotImplementedException();
        }
    }
}
