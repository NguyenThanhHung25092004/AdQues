using UnityEngine;

public abstract class QuestionDataBase : ScriptableObject
{
    public string questionText;
    public abstract string getQuestionType();
    public abstract bool isCorrect(string answer);
    public abstract void setUpUI(QuestionManager manager);
}
