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
        public static string PromptForInput(string prompt, bool allowEmpty = false)
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
            } 
            while(isInvalid);

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
            if (string.IsNullOrWhiteSpace(prompt))
            {
                throw new ArgumentException("The prompt cannot be null, empty, or whitespace");
            }

            if (trueString == null || falseString == null)
            {
                throw new ArgumentException("The trueString and falseString aren't allowed to be null.");
            }

            if (trueString.ToLower() == falseString.ToLower())
            {
                throw new ArgumentException("The trueString and falseString aren't allowed to be equal to each other");
            }

            bool isInvalid = true;
            do

            {
                string? output = PromptForInput(prompt);
                if(output?.ToLower() == trueString.ToLower() )
                {
                    return true;
                } 
                else if (output?.ToLower() == falseString.ToLower())
                {
                    return false;
                } 
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }
            } while(isInvalid);

            return false;
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
            if (string.IsNullOrWhiteSpace(prompt))
            {
                throw new ArgumentException("The prompt cannot be null, empty, or whitespace");
            }

            if (min > max)
            {
                throw new ArgumentException("min may not be greater than max");
            }

            bool isInvalid = true;
            int parsedNum = min - 1;
            

            do
            {
                string? output = PromptForInput(prompt);
                if (Int32.TryParse(output, out int parsedInput)) {
                    parsedNum = parsedInput;
                    if (parsedNum >= min && parsedNum <= max)
                    {
                        isInvalid = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please try again.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.\n");
                    continue;
                }
            } while (isInvalid);

            return parsedNum;
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
            
            for (int i = 0; i < options.Count(); i++)
            {
                if (options.ElementAt(i) == null)
                {
                    throw new ArgumentException("No string in 'options' may be null.");
                }
                //if (string.IsNullOrWhiteSpace(options.ElementAt(i)))
                //{
                //    throw new ArgumentException("No string in 'options' may be null, empty, or contain whitespace.");
                //}
            }
            if (options.Count() == 0 && !withQuit)
            {
                throw new ArgumentException("If 'options' is empty, then withQuit MUST be true so that user has at least one choice.");
            }

            bool isInvalid = true;
            int choice = -1;

            do
            {
                for (int i = 0; i < options.Count(); i++)
                {
                    Console.WriteLine((i + 1) + ": " + options.ElementAt(i));
                }
                if (withQuit)
                {

                    Console.WriteLine("\n\n0: Quit");
                }
                if (options.Count() > 0 && withQuit)
                {
                    choice = PromptForInt( "========================="/*"Choose a number between 1 and " + options.Count()*/, 0, options.Count());
                    isInvalid = false;
                }
                else if (options.Count() > 0 && !withQuit)
                {
                    choice = PromptForInt("========================="/*"Choose a number between 1 and " + options.Count()*/, 1, options.Count());
                    isInvalid = false;
                }
                else
                {
                    choice = PromptForInt("Choose 0 to quit", 0, 0);
                    isInvalid = false;
                }
            } while (isInvalid);

            return choice;
        }
    }
}
