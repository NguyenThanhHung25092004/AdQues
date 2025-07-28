using NUnit.Framework;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.Cinemachine;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager instance;

    public GameObject questionPanel;
    public Text questionText;
    public List<Button> choiceButtons = new List<Button>();

    private QuestionData currentQuestion;
    private QuestionBlock block;
    private const string SCORE = "AdQuesScore";
    private const string LevelScore = "AdQuesLevelScore";

    [SerializeField] private CinemachineImpulseSource impulseSource;
    [SerializeField] private Text scoreText;
    private int currentScore = 0;
    private const int maxScore = 17;
    private void Awake()
    {
#if UNITY_EDITOR
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            resetScore(); 
        }
#endif
        instance = this;
        impulseSource = GetComponent<CinemachineImpulseSource>();
        currentScore = PlayerPrefs.GetInt(SCORE, 0);
        scoreText.text = $"{currentScore}/{maxScore}";

        PlayerPrefs.SetInt(LevelScore, currentScore);
        PlayerPrefs.Save();
    }

    private void updateScore()
    {   
        currentScore += 1;
        PlayerPrefs.SetInt(SCORE, currentScore);
        scoreText.text = $"{currentScore}/{maxScore}";
    }

    public void showQuestion(QuestionData question, QuestionBlock senderBlock)
    {
        if (senderBlock.hasBeenAnswered)
            return;

        currentQuestion = question;
        block = senderBlock;
        questionPanel.SetActive(true);
        questionText.text = question.questionText;
        
        for(int i = 0; i < choiceButtons.Count; i++)
        {
            choiceButtons[i].gameObject.SetActive(true);
            string selectedAnswer = question.choices[i];
            choiceButtons[i].GetComponentInChildren<Text>().text = selectedAnswer;

            choiceButtons[i].onClick.RemoveAllListeners();
            choiceButtons[i].onClick.AddListener(() => { submitAnswer(selectedAnswer);
                buttonClickSound();
            });
        }
    }

    private void buttonClickSound()
    {
        SoundLibrary.instance.PlaySound("AnswerButton");
    }

    public void submitAnswer(string answer)
    {
        block.hasBeenAnswered = true;
        if(answer.Equals(currentQuestion.correctAnswer, System.StringComparison.OrdinalIgnoreCase))
        {
            updateScore();
        } else
        {
            CameraShake.instance.cameraShake(impulseSource);
        }
        block.showArea();
        questionPanel.SetActive(false);
    }

    private void resetScore()
    {
        currentScore = 0;
        PlayerPrefs.SetInt(SCORE, 0);
        PlayerPrefs.Save();
        scoreText.text = $"{currentScore}/{maxScore}";
    }

  

}
