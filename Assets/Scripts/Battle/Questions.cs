using System.Collections.Generic;

public class Questions{
    public Dictionary<string, int> questions {get; set;}
    public List<string> answers{get; set;}

    public Questions(Dictionary<string, int> questionList, List<string> answerList){
        questions = questionList;
        answers = answerList;
    }
}