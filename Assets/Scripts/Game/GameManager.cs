using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; }
    }

    private GameStateBase currentGameState;

    public readonly string CheckGameEndEvent = "CheckGameEndEvent";

    private Dictionary<GameStateEnum, GameStateBase> gameStateList = new Dictionary<GameStateEnum, GameStateBase>();

    public int currentLevel = 1;  //当前关卡等级

    private int _currentScore = 0;
    public int CurrentScore
    {
        get { return _currentScore; }
        set
        {
            _currentScore = value;
            UIManager.Instance.SetScore();
        }
    }

    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
        GameInit();
    }

    void GameInit()
    {
        UIManager.Instance.Init();
        FoodManager.Instance.Init();
        PlayerManager.Instance.Init();
        RegisterGameState();
        ChangeGameState(GameStateEnum.Init);
    }

    private void RegisterGameState()
    {
        gameStateList.Add(GameStateEnum.Init, new GameInitState());
        gameStateList.Add(GameStateEnum.Gaming, new GamingState());
        gameStateList.Add(GameStateEnum.Pause, new GamePauseState());
        gameStateList.Add(GameStateEnum.End, new GameEndState());
    }

    private GameStateBase GetGameState(GameStateEnum state)
    {
        return gameStateList[state];
    }

    public void ChangeGameState(GameStateEnum state)
    {
        if (currentGameState != null)
        {
            currentGameState.Exit();
        }
        currentGameState = GetGameState(state);
        currentGameState.Enter();
    }

    void Update()
    {
        currentGameState.UpdateProcess();
    }

    public void UpLevel()
    {
        currentLevel++;
        PlayerManager.Instance.Reset();
    }

    public void StopGame()
    {

    }

    public void Resume()
    {

    }

    public void GameEnd()
    {

    }

    public void GameStart()
    {

    }
}
