using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Btn : MonoBehaviour
{
    public UnityAction listener;

    Button btn;
    public Image img;

    private void Start()
    {
        btn = GetComponent<Button>();
        img = GetComponent<Image>();
        btn.onClick.AddListener(() =>
        {
            if (ButtonManager.instance.currBtn == this)
            {
                ButtonManager.instance.BtnClear();
            }
            else
            {
                ButtonManager.instance.BtnChange(this);
            }
        });
    }
}
