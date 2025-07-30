using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "MultipleChoiceQuesition", menuName = "Scriptable Objects/MultipleChoiceQuesition")]
public class MultipleChoiceQuesition : QuestionDataBase
{
    public List<string> choices = new List<string>();
    public string correctAnswer;

    public override string getQuestionType()
    {
        return "MCQ";
    }

    public override bool isCorrect(string answer)
    {
        return answer.Equals(correctAnswer, System.StringComparison.OrdinalIgnoreCase);
    }

    public override void setUpUI(QuestionManager manager)
    {
        manager.answerField.SetActive(false);
        manager.buttons.SetActive(true);
        for (int i = 0; i < manager.choiceButtons.Count; i++)
        {           
            var button = manager.choiceButtons[i];
            string selectedAnswer = choices[i];
            button.GetComponentInChildren<Text>().text = selectedAnswer;

            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => {
                manager.submitAnswer(selectedAnswer);
                manager.buttonClickSound();
            });
        }
    }
}
