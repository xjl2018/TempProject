using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanelView : MonoBehaviour
{
    void Awake()
    {
        transform.Find("homeBtn").GetComponent<Button>().onClick.AddListener(OnHomeBtn);
        transform.Find("resumeBtn").GetComponent<Button>().onClick.AddListener(OnResumeBtn);
    }

    void OnHomeBtn()
    {
        GameManager.Instance.ChangeGameState(GameStateEnum.Init);
    }

    void OnResumeBtn()
    {
        GameManager.Instance.ChangeGameState(GameStateEnum.Gaming);
    }

    public void SetVisible(bool isShow)
    {
        gameObject.SetActive(isShow);
    }
}
