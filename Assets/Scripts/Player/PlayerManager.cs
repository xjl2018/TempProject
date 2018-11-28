using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    private static PlayerManager _instance;
    public static PlayerManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerManager();
            }
            return _instance;
        }
    }

    public List<PlayerBase> leftTeamFinishList = new List<PlayerBase>();    //左边队伍完成人数
    public List<PlayerBase> rightTeamFinishList = new List<PlayerBase>();	//右边队伍完成人数

    public PlayerBase currentLeftPlayer;	//左边当前玩家
    public PlayerBase currentRightPlayer;   //右边当前玩家

    public int leftTeamMaxPlayerCount = 5;
    public int rightTeamMaxPlayerCount = 5;

    public bool isFirstStart;

    private Dictionary<PlayerTypeEnum, PlayerFactory> playerFactories = new Dictionary<PlayerTypeEnum, PlayerFactory>();

    public void Init()
    {
        RegeditPlayerFactory();
        isFirstStart = true;
    }

    private void RegeditPlayerFactory()
    {
        playerFactories.Add(PlayerTypeEnum.Cat, new CatFactory());
        playerFactories.Add(PlayerTypeEnum.Rabbit, new RabbitFactory());

    }

    public void AddLeftTeamFinishPlayer(PlayerBase player)
    {
        leftTeamFinishList.Add(player);
        if (leftTeamFinishList.Count == leftTeamMaxPlayerCount)
        {
            GameManager.Instance.UpLevel();
        }
    }

    public void AddRightTeamFinishPlayer(PlayerBase player)
    {
        rightTeamFinishList.Add(player);
        if (rightTeamFinishList.Count == rightTeamMaxPlayerCount)
        {
            GameManager.Instance.UpLevel();
        }
    }

    public void Reset()
    {
        Clear();
        if (isFirstStart)
        {
            var leftPlayer = GetPlayerFactory(PlayerTypeEnum.Cat).ProducePlayer();
            var rightPlayer = GetPlayerFactory(PlayerTypeEnum.Rabbit).ProducePlayer();
            SetCurrentLeftPlayer(leftPlayer);
            SetCurrentRightPlayer(rightPlayer);
            leftPlayer.SetCurrentFood(FoodManager.Instance.ProduceFood(typeof(MilkFactory)));
            rightPlayer.SetCurrentFood(FoodManager.Instance.ProduceFood(typeof(HamburgerFactory)));
            isFirstStart = false;
        }
        else
        {
            //todo
            var leftPlayer = GetPlayerFactory(PlayerTypeEnum.Cat).ProducePlayer();
            var rightPlayer = GetPlayerFactory(PlayerTypeEnum.Rabbit).ProducePlayer();
            SetCurrentLeftPlayer(leftPlayer);
            SetCurrentRightPlayer(rightPlayer);
            leftPlayer.SetCurrentFood(FoodManager.Instance.ProduceFood());
            rightPlayer.SetCurrentFood(FoodManager.Instance.ProduceFood());
        }
    }

    public void SetCurrentLeftPlayer(PlayerBase player)
    {
        player.isLeftTeam = true;
        UIManager.Instance.SetLeftPlayer(player);

    }

    public void SetCurrentRightPlayer(PlayerBase player)
    {
        player.isLeftTeam = false;
        UIManager.Instance.SetRightPlayer(player);
    }

    public PlayerFactory GetPlayerFactory(PlayerTypeEnum playerType)
    {
        return playerFactories[playerType];
    }

    public void Clear()
    {
        foreach (var player in leftTeamFinishList)
        {
            player.Clear();
        }
        foreach (var player in rightTeamFinishList)
        {
            player.Clear();
        }
        leftTeamFinishList.Clear();
        rightTeamFinishList.Clear();
    }
}

public enum PlayerTypeEnum
{
    Cat,
    Rabbit,
}