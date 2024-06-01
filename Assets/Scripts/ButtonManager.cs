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

        currBtn = startEvents[0];
        currBtn.img.color = Color.red;
    }

    public void BtnActChange(UnityAction listener)
    {
        currBtn.listener = listener;
    }
    public void BtnActClear()
    {
        currBtn.listener = null;
    }

    public void AllBtnActClear()
    {
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
        if (currBtn == null)
            return;
        currBtn.img.color = Color.white;
        currBtn = null;
    }
}