using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Windows;

[CreateAssetMenu(fileName = "TypeAnswerQuestion", menuName = "Scriptable Objects/TypeAnswerQuestion")]
public class TypeAnswerQuestion : QuestionDataBase
{
    public List<string> correctAnswers;
    public override string getQuestionType()
    {
        return "TAQ";
    }

    public override bool isCorrect(string answer)
    {
        foreach (var ca in correctAnswers)
        {
            if (answer.Equals(ca, System.StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }

    public override void setUpUI(QuestionManager manager)
    {
        manager.buttons.SetActive(false);
        manager.answerField.SetActive(true);    
        var answer = manager.answerInput;
        answer.ActivateInputField();
    }

}
