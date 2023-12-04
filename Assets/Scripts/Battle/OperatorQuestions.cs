using System.Collections.Generic;


public class  OperatorQuestions: Questions{

    public OperatorQuestions(): base(
        new Dictionary<string, int>{
        {"The expression to check if the number num is even using the modulus operator is num % 2 _______.", 1},

        {"Write the conditional expression using the 'not equal to' operator that will evaluate to true if var1 is not equal to var2.", 4},

        {"To increment the value of an integer counter by 1 using the addition operator, you would write: counter = counter ______ 1;", 10},

        {"Write the arithmetic expression to double the value of x and then store the result back in x: x = x ______ 2;", 13},

        {"What is the arithmetic operator for multiplication? ", 16},

        {"What is the result of the following expression? int result = 4 % 2;", 22},

        {"What will be the result of the following expression?   int a = 5, b = 3; printf('%d', a > b && b < 5);", 26},

        {"What will be the output of the following code snippet? int a = 10; printf('%d', !a);", 31},

        {"Which expression will correctly evaluate whether x is both positive and less than 10?", 34},
        
        {"To check if a character c is a lowercase letter, the expression would be _______ && _______.", 37}
    },
        new List<string>(){
        "a. < 1", "b. == 0", "c. 0", "d. == 1",

        "a. var1 != var2", "b. var1 == var2", "c. var1 <> var2", "d. var1 < var2",

        "a. *", "b. /", "c. +", "d. %",

        "a. +", "b. *", "c. /", "d. %",

        "a. *", "b. ||", "c. +", "d. <",

        "a. 1", "b. 0", "c. 2", "d. 4",

        "a. 0", "b. 5", "c. 1", "d. 3",

        "a. 0", "b. 1", "c. 10", "d. -10",

        "a. x > 0 || x < 10", "b. x < 0 || x > 10", "c. x > 0 && x < 10", "d. x < 0 && x > 10",

        "a. c != 'a', c <= 'z'", "b. 'a' <=  c, c <= 'z'", "c. 'a' ==  c, z <= 'c'", "d. a <= 'c', 'c' <= z"
    }
    )
    {

    }
}