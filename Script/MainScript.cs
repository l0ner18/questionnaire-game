using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using YG;

public class MainScript : MonoBehaviour
{
    //Текст вопросов
    public string[] arrayOfQuestionText = new string[15];
    //Спрайты вопросов
    public Sprite[] arrayOfQuestionSprite = new Sprite[15];
    //Текст кнопок ответов 
    public string[] arrayOfAnswerButtonsText = new string[60];

    public Text gameObjectQuestionText;
    public Image gameObjectQuestionImage;
    public Text[] gameObjectAnswerButton;

    public int score;

    public int id = 0;
    public int but_id = 0;

    public Text EndText;
    public string EndResultFull;
    public GameObject QuestionPanel;
    public GameObject EndPanel;

    public GameObject NextQuestionButton;

    public int wrongAnswers;

    public YandexGame sdk;

    public Color greenColor = new Color(0.4706f, 0.7490f, 0.4706f);
    public Color redColor = new Color(1f, 0.2f, 0.2f);
    public Color normalColor = new Color(0.2118f, 0.2157f, 0.2196f);
    private Button onClickButton;
    public Button[] allButtons = new Button[4];
    public Button Answer_1;
    public Button Answer_2;
    public Button Answer_3;
    public Button Answer_4;

    public GameObject ExitPanel;

    public Button rightButtonOnClick;
    public void СountWrongAnswers()
    {
        wrongAnswers++;
        CheckWrong();
    }
    public void CheckWrong()
    {
        if (wrongAnswers == 3)
        {
            wrongAnswers = 0;
            sdk._RewardedShow(1);
        }
    }

    public void ChangeQuestion()
    {
        id++;
        but_id = but_id + 4;

        gameObjectQuestionText.text = arrayOfQuestionText[id];
        gameObjectQuestionImage.sprite = arrayOfQuestionSprite[id];

        gameObjectAnswerButton[0].text = arrayOfAnswerButtonsText[but_id];
        gameObjectAnswerButton[1].text = arrayOfAnswerButtonsText[but_id + 1];
        gameObjectAnswerButton[2].text = arrayOfAnswerButtonsText[but_id + 2];
        gameObjectAnswerButton[3].text = arrayOfAnswerButtonsText[but_id + 3];

        for (int i = 0; i < allButtons.Length; i++)
        {
            int buttonIndex = i;

            onClickButton = allButtons[i];

            onClickButton.image.color = normalColor;
        }
        NextQuestionButton.SetActive(false);
        
    }

    public void SetActiveButton()
    {
        NextQuestionButton.SetActive(true);
    }

    public void SetActiveTrueExitMenuButton()
    {
        ExitPanel.SetActive(true);
    }
    public void SetActiveFalseExitMenuButton()
    {
        ExitPanel.SetActive(false);
    }

    public void Start()
    {
        QuestionPanel.SetActive(true);
        EndPanel.SetActive(false);
        NextQuestionButton.SetActive(false);
        gameObjectQuestionText.text = arrayOfQuestionText[id];
        gameObjectQuestionImage.sprite = arrayOfQuestionSprite[id];

        gameObjectAnswerButton[0].text = arrayOfAnswerButtonsText[but_id];
        gameObjectAnswerButton[1].text = arrayOfAnswerButtonsText[but_id + 1];
        gameObjectAnswerButton[2].text = arrayOfAnswerButtonsText[but_id + 2];
        gameObjectAnswerButton[3].text = arrayOfAnswerButtonsText[but_id + 3];

    }


    public void Update()
    {

        if (id == 15)
        {
            EndResultFull = "Вы ответили верно на " + score + " из 15";

            EndText.text = EndResultFull;
            QuestionPanel.SetActive(false);
            EndPanel.SetActive(true);

        }
        ChangeRightButtonColor(Answer_1);
        ChangeButtonColor(Answer_2);
        ChangeButtonColor(Answer_3);
        ChangeButtonColor(Answer_4);

        if (NextQuestionButton.activeSelf)
        {
            for (int i = 0; i < allButtons.Length; i++)
            {
                onClickButton = allButtons[i];
                onClickButton.interactable = false;
            }
        }
        else
        {
            for (int i = 0; i < allButtons.Length; i++)
            {
                onClickButton = allButtons[i];
                onClickButton.interactable = true;
            }
        }

    }
    public void ChangeButtonColor(Button buttonOnClick)
    {
        buttonOnClick.onClick.AddListener(() =>
        {
            buttonOnClick.image.color = redColor;
            rightButtonOnClick.image.color = greenColor;


        });
    }
    public void ChangeRightButtonColor(Button buttonOnClick)
    {
        buttonOnClick.onClick.AddListener(() =>
        {
            buttonOnClick.image.color = greenColor;

        });
    }

    public void CheckClickButton()
    {

        for (int i = 0; i < allButtons.Length; i++)
        {
            onClickButton = allButtons[i];
            onClickButton.interactable = false;
        }
    }
    public void RightAnwer()
    {
        score++;
      
    }
}
