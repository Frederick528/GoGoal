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
    [SerializeField] Btn[] colltEvents2;

    Transform eventBtns;
    [SerializeField] GameObject[] eventBtnsArray;
    int curEBAIdx = 0;  // EBA = Event Buttons Array


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
        startEvents = startContent.GetComponentsInChildren<Btn>();
        collEvents1 = collContent1.GetComponentsInChildren<Btn>();
        colltEvents2 = collContent2.GetComponentsInChildren<Btn>();

        eventBtns = GameObject.Find("EventBtns").transform;
        eventBtnsArray = new GameObject[eventBtns.childCount];

        for (int i = 0; i < eventBtnsArray.Length; i++)
        {
            eventBtnsArray[i] = eventBtns.GetChild(i).gameObject;
            //eventBtnsArray[i].SetActive(false);
        }

        //eventBtnsArray[0].SetActive(true);

        currBtn = startEvents[0];
        currBtn.img = currBtn.GetComponent<Image>();    // Get the current button image before gane start. (Because execution order issue for Btn and Button manager)
        currBtn.img.color = Color.red;
    }

    public void BtnActChange(UnityAction listener)
    {
        // Add Change Button Image Script
        currBtn.listener = listener;
    }
    public void BtnActClear()
    {
        // Add Change Button Image Script
        currBtn.listener = null;
    }

    public void AllBtnActClear()
    {
        // Add Change Button Image Script
        foreach (Btn btn in startEvents)
            btn.listener = null;
        foreach (Btn btn in collEvents1)
            btn.listener = null;
        foreach (Btn btn in colltEvents2)
            btn.listener = null;
    }

    public void BtnChange(Btn btn)
    {
        if (currBtn != null)
            currBtn.img.color = Color.white;
        currBtn = btn;
        currBtn.img.color = Color.red;
    }

    public void BtnClear()
    {
        currBtn.img.color = Color.white;
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