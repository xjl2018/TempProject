using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UIManager();
            }
            return _instance;
        }
    }

    Transform uiRoot;
    Button startBtn;
    Button endBtn;
    Button pauseBtn;

    Text leftFood;
    Text rightFood;

    public Transform leftPlayer;
    public Transform rightPlayer;

    public GameObject foodTemplate;

    public PausePanelView pausePanelView;

    Text score;

    public void Init()
    {
        uiRoot = GameObject.Find("Root").transform;

        startBtn = uiRoot.Find("startBtn").GetComponent<Button>();
        startBtn.onClick.AddListener(OnStartBtn);

        endBtn = uiRoot.Find("endBtn").GetComponent<Button>();
        endBtn.onClick.AddListener(OnEndBtn);

        pauseBtn = uiRoot.Find("pauseBtn").GetComponent<Button>();
        pauseBtn.onClick.AddListener(OnPauseBtn);

        foodTemplate = uiRoot.Find("mainGamePanel/foodTemplate").gameObject;

        leftFood = uiRoot.Find("mainGamePanel/leftFood").GetComponent<Text>();
        rightFood = uiRoot.Find("mainGamePanel/rightFood").GetComponent<Text>();

        leftPlayer = uiRoot.Find("mainGamePanel/leftPlayer");
        rightPlayer = uiRoot.Find("mainGamePanel/rightPlayer");

        score = uiRoot.Find("mainGamePanel/score").GetComponent<Text>();

        pausePanelView = uiRoot.Find("pausePanel").GetComponent<PausePanelView>();

    }

    private void OnStartBtn()
    {
        GameManager.Instance.ChangeGameState(GameStateEnum.Gaming);
    }

    private void OnEndBtn()
    {
        GameManager.Instance.ChangeGameState(GameStateEnum.End);
    }

    private void OnPauseBtn()
    {
        GameManager.Instance.ChangeGameState(GameStateEnum.Pause);
    }

    public void SetStartBtnVisible(bool isShow)
    {
        startBtn.gameObject.SetActive(isShow);
    }

    public void SetEndBtnVisible(bool isShow)
    {
        endBtn.gameObject.SetActive(isShow);
    }

    public void SetpauseBtnVisible(bool isShow)
    {
        pauseBtn.gameObject.SetActive(isShow);
    }

    public void SetLeftPlayer(PlayerBase player)
    {
        leftPlayer.Find("name").GetComponent<Text>().text = player.GetType().Name;

    }

    public void SetRightPlayer(PlayerBase player)
    {
        rightPlayer.Find("name").GetComponent<Text>().text = player.GetType().Name;
    }

    public void SetLeftPlayerFood(FoodBase food)
    {
<<<<<<< HEAD
=======
        Debug.Log("set food");
>>>>>>> 1313a608ca8631b839fd8dfcc1c304822cf49b8e
        leftFood.text = food.foodName;
    }

    public void SetRightPlayerFood(FoodBase food)
    {
        rightFood.text = food.foodName;
    }

    public void SetScore()
    {
        score.text = GameManager.Instance.CurrentScore.ToString();
    }

    public void SetPausePanelVisible(bool isShow)
    {
        pausePanelView.SetVisible(isShow);
    }
}
