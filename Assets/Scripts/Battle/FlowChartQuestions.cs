
using System.Collections.Generic;

public class FlowChartQuestions: Questions {

    public FlowChartQuestions() : base (

    new Dictionary<string, int>{
        {"What shape is commonly used to represent a decision-making process in flowcharts?", 1},

        {"Which flowchart symbol is used to represent a processing function such as mathematical operations?", 4},

        {"Which flowchart symbol would you use to depict a subroutine or a predefined process?", 10},

        {"Which symbol in a flowchart is typically used to show the input or output of data?", 13},

        {"Flowlines with arrowheads in a flowchart indicate what?", 16},

        {"What does the terminal symbol in a flowchart represent?", 22},

        {"The diamond symbol in a flowchart is used for which of the following?", 26},

        {"In a flowchart, what is the purpose of the arrow symbol?", 31},

        {"A parallelogram in a flowchart typically signifies which of the following?", 34},

        {"What is the correct sequence of flow in a flowchart?", 37}
    },

    new List<string>{
        "a. Rectangle", "b. Diamond", "c. Circle", "d.Triangle",

        "a. Oval", "b. Rectangle", "c. Parallelogram", "d. Arrow",

        "a. Rectangle with double-struck vertical sides", "b. Diamond", "c. Parallelogram", "d. Rectangle",

        "a. Rectangle", "b. Parallelogram", "c. Diamond", "d. Arrow",

        "a. The flow of data", "b. The order of operations", "c. The termination of the program", "d. The processing of information",

        "a. A processing step", "b. A decision input", "c. The beginning or end of a program", "d. Data input or output",

        "a. indicating a process", "b. Marking the start or end", "c. Decision making", "d. Displaying data",

        "a. To represent data", "b. To represent processing", "c. To represent decision making", "d. To show the direction of flow",

        "a. A decision needs to be made", "b. The beginning or end of the program", "c. An input or an output", "d. A manual operation",

        "a. Terminal->Process->Decision->Data", "b. Process->Terminal->Decision->Data", "c. Data->Decision->Process->Terminal", "d. Terminal->Data->Decision->Process"
    }
    )
    {
        
    }
}