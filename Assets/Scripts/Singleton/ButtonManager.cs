using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;

    GameObject startContent;
    GameObject collContent1;
    GameObject collContent2;
    [SerializeField] Btn[] startEvents;
    [SerializeField] Btn[] collEvents1;
    [SerializeField] Btn[] collEvents2;

    Transform eventBtns;
    [SerializeField] GameObject[] eventBtnsArray;
    int curEBAIdx = 0;  // EBA = Event Buttons Array

    public int startLimitNum;
    public int collLimitNum1;
    public int collLimitNum2;

    public GameObject description;

    public Btn currBtn {get; private set;}

    private void Awake()
    {
        instance ??= this;
    }

    private void Start()
    {
        startContent = GameObject.Find("StartContent");
        collContent1 = GameObject.Find("CollContent1");
        collContent2 = GameObject.Find("CollContent2");
        startEvents = startContent.GetComponentsInChildren<Btn>(true);
        collEvents1 = collContent1.GetComponentsInChildren<Btn>(true);
        collEvents2 = collContent2.GetComponentsInChildren<Btn>(true);

        ShowBtn();

        eventBtns = GameObject.Find("EventBtns").transform;
        eventBtnsArray = new GameObject[eventBtns.childCount];

        for (int i = 0; i < eventBtnsArray.Length; i++)
            eventBtnsArray[i] = eventBtns.GetChild(i).gameObject;

        eventBtnsArray[0].SetActive(true);

        description = GameObject.Find("BtnDescription");
        description.SetActive(false);

        currBtn = startEvents[0];
        currBtn.img = currBtn.GetComponent<Image>();    // Get the current button image before gane start. (Because execution order issue for Btn and Button manager)
        currBtn.Outline = currBtn.GetComponentsInChildren<Image>(true)[1];
        currBtn.Outline.gameObject.SetActive(true);
    }

    public void ShowBtn()
    {
        int i;
        i = 0;
        foreach (Btn btn in startEvents)
        {
            if (i < startLimitNum)
            {
                btn.gameObject.SetActive(true);
                ++i;
                continue;
            }
            btn.gameObject.SetActive(false);
            ++i;
        }
        i = 0;
        foreach (Btn btn in collEvents1)
        {
            if (i < collLimitNum1)
            {
                btn.gameObject.SetActive(true);
                ++i;
                continue;
            }
            btn.gameObject.SetActive(false);
            ++i;
        }
        i = 0;
        foreach (Btn btn in collEvents2)
        {
            if (i < collLimitNum2)
            {
                btn.gameObject.SetActive(true);
                ++i;
                continue;
            }
            btn.gameObject.SetActive(false);
            ++i;
        }
    }

    public void BtnActChange(UnityAction listener, Sprite eventImage)
    {
        currBtn.img.sprite = eventImage;
        currBtn.listener = listener;
    }
    public void BtnActClear()
    {
        currBtn.img.sprite = null;
        currBtn.listener = null;
    }

    public void AllBtnActClear()
    {
        int i;
        i = 0;
        foreach (Btn btn in startEvents)
        {
            if (i < startLimitNum)
            {
                btn.img.sprite = null;
                btn.listener = null;
                ++i;
            }
            else
                break;
        }
        i = 0;
        foreach (Btn btn in collEvents1)
        {
            if (i < collLimitNum1)
            {
                btn.img.sprite = null;
                btn.listener = null;
                ++i;
            }
            else
                break;
        }
        i = 0;
        foreach (Btn btn in collEvents2)
        {
            if (i < collLimitNum2)
            {
                btn.img.sprite = null;
                btn.listener = null;
                ++i;
            }
            else
                break;
        }
    }

    public void BtnChange(Btn btn)
    {
        if (currBtn != null)
            currBtn.Outline.gameObject.SetActive(false);
        currBtn = btn;
        currBtn.Outline.gameObject.SetActive(true);
    }

    public void BtnClear()
    {
        currBtn.Outline.gameObject.SetActive(false);
        currBtn = null;
    }

    public void SelectBtn(Btn btn)
    {
        if (currBtn == btn)
        {
            BtnClear();
        }
        else
        {
            BtnChange(btn);
        }
    }

    public void AddEventBtnsArrayIdx(int addIdx)
    {
        eventBtnsArray[curEBAIdx].SetActive(false);
        curEBAIdx += addIdx;
        if (curEBAIdx > eventBtnsArray.Length - 1)
            curEBAIdx = 0;
        else if (curEBAIdx < 0)
            curEBAIdx = eventBtnsArray.Length - 1;

        eventBtnsArray[curEBAIdx].SetActive(true);
    }
}