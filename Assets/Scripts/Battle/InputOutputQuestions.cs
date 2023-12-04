using System.Collections.Generic;
using UnityEngine;

public class InputOutputQuestions: Questions {


    public InputOutputQuestions() : base(
        new Dictionary<string, int>{
        {"Which data type should you choose to store the character 'A'?", 1},

        {"What is the correct way to declare a variable for storing whole numbers in C?", 4},

        {"If you want to read a string from the user, which of the following format specifiers should you use with scanf?", 10},

        {"If you want to declare a variable that can store decimal numbers up to 15 decimal places, you would write: _________ myVariable;", 13},

        {"What is the output of the following C code? printf('%d\n', (int)sizeof(double));", 16},

        {"The printf function returns the number of characters successfully written to the output. If you want to store this value, you would write: int charsPrinted = printf('Learning C is fun!\n');", 22},

        {"Complete the following code to print the phrase 'Hello World' in C: ____________('Hello World\n');", 26},
		

        {"What is the standard function in C used to read character input from the standard input stream? ", 31},
		

        {"To read an integer value from the user, you would use _______ function with the format specifier _______.", 34},
        
        {"To print a floating-point number with two decimal places, you would use the printf function like this: printf('_____', ______);", 37}
        },
        new List<string>{
        "a. float", "b. char", "c. int", "d.double",

        "a. int whole_number;", "b. number int;", "c. whole_number var;", "d. int number whole;",

        "a. %d", "b. %c", "c. %s", "d. %f",

        "a. float", "b. double", "c. int", "d. char",

        "a. 8", "b. 4", "c. 2", "d. Depends on the system",

        "a. 18", "b. 19", "c. You cannot store a printf function to a variable", "d. No output",

        "a. scanf", "b. System.out.println", "c. printf", "d. display",

        "a. printf", "b. get", "c. read", "d. scanf",

        "a. printf, %.2f", "b. input, %d", "c. scanf, %d", "d. read, int32",

        "a. %2f, variable_name", "b. %.2f, variable_name", "c. %d, variable_name", "d. %2d, variable_name"
    }
    )
    {
        
    }
    
}
