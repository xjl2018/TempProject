using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class FoodBase : MonoBehaviour
{
    public string foodName;
    public Image image;
    private FoodState _state;
    public FoodState State
    {
        get { return _state; }
        set { _state = value; }
    }

    private readonly Vector2 StartPostion = new Vector2(6, 270);
    private readonly Vector2 EndPosition = new Vector2(6, 0);

    private const float dropSpeed = -5f;    //食物下落速度

    public float produceTime;  //食物生产日期

    private bool _isFinish;
    public bool IsFinish
    {
        get { return _isFinish; }
        set { _isFinish = value; }
    }

    RectTransform rectTransform;

    public virtual void Awake()
    {
        Init();
    }

    public virtual void Init()
    {
        gameObject.name = this.GetType().Name;
        gameObject.AddComponent<FoodDragHandle>();
        rectTransform = gameObject.GetComponent<RectTransform>();
        transform.SetParent(UIManager.Instance.foodTemplate.transform.parent);
        rectTransform.localScale = Vector3.one;
        rectTransform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.Find("name").GetComponent<Text>().text = foodName;
        Reset();
    }

    public virtual void Reset()
    {
        produceTime = Time.time;
        State = FoodState.Dropping;
        IsFinish = false;
        rectTransform.anchoredPosition = StartPostion;
        Debug.Log("produce food: " + this.GetType().Name);
    }

    public virtual void Update()
    {
        if (IsFinish)
            return;
        HandleDrop();
        HandleEat();
    }

    private void HandleDrop()
    {
        if (State != FoodState.Dropping)
        {
            return;
        }
        var value = rectTransform.anchoredPosition.y + dropSpeed;
        rectTransform.anchoredPosition = new Vector2(6, value);
        if (value <= EndPosition.y)
        {
            rectTransform.anchoredPosition = EndPosition;
            State = FoodState.Drag;
        }
    }

    private void HandleEat()
    {
        if (State != FoodState.Drag)
        {
            return;
        }
        var leftPlayerRect = UIManager.Instance.leftPlayer.GetComponent<RectTransform>();
        var leftDistance = Vector2.Distance(rectTransform.anchoredPosition, leftPlayerRect.anchoredPosition);
        if (leftDistance < 100)
        {
            PlayerManager.Instance.currentLeftPlayer.Eat(this);
            return;
        }

        var rightPlayerRect = UIManager.Instance.rightPlayer.GetComponent<RectTransform>();
        var rightDistance = Vector2.Distance(rectTransform.anchoredPosition, rightPlayerRect.anchoredPosition);
        if (rightDistance < 100)
        {
            PlayerManager.Instance.currentRightPlayer.Eat(this);
        }
    }

    public void SetVisible(bool isShow)
    {
        if (gameObject)
        {
            gameObject.SetActive(isShow);
        }
    }

    public void SetEndPosition()
    {
        rectTransform.anchoredPosition = EndPosition;
    }
}

public enum FoodState
{
    Dropping,
    Drag,
    Expire
}