using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Btn : MonoBehaviour
{
    public UnityAction listener;

    public Image img;
    public Image Outline;
    Button btn;

    private void Start()
    {
        img = GetComponent<Image>();
        Outline = GetComponentsInChildren<Image>(true)[1];
        btn = GetComponent<Button>();
        btn.onClick.AddListener(() => ButtonManager.instance.SelectBtn(this));
    }
}
