using NUnit.Framework;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
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
    public TMP_InputField answerInput;
    public GameObject answerField;
    public GameObject buttons;

    private QuestionDataBase currentQuestion;
    private QuestionBlock block;
    private const string SCORE = "AdQuesScore";
    private const string LevelScore = "AdQuesLevelScore";

    [SerializeField] private CinemachineImpulseSource impulseSource;
    [SerializeField] private Text scoreText;
    [SerializeField] private SimpleCharacterMove player1;
    [SerializeField] private SimpleCharacterMove player2;
    private int currentScore = 0;
    private const int maxScore = 15;

    private void resetScore()
    {
        currentScore = 0;
        PlayerPrefs.SetInt(SCORE, 0);
        PlayerPrefs.Save();
        scoreText.text = $"{currentScore}/{maxScore}";
    }
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

    public void showQuestion(QuestionDataBase question, QuestionBlock senderBlock)
    {
        if (senderBlock.hasBeenAnswered)
            return;
        player1.setMovementEnabled(false);
        player2.setMovementEnabled(false);
        currentQuestion = question;
        block = senderBlock;
        questionPanel.SetActive(true);
        questionText.text = question.questionText;
        question.setUpUI(this);
        
    }

    public void buttonClickSound()
    {
        SoundLibrary.instance.PlaySound("AnswerButton");
    }

    public void submitAnswer(string answer)
    {
        block.hasBeenAnswered = true;       
        if (currentQuestion.isCorrect(answer))
        {
            updateScore();
        } else
        {
            CameraShake.instance.cameraShake(impulseSource);
        }
        player1.setMovementEnabled(true);
        player2.setMovementEnabled(true);
        block.showArea();
        questionPanel.SetActive(false);
    }

    public void processTypeQuestion()
    {
        string answer = answerInput.text;
        submitAnswer(answer);
    }

}
