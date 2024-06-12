using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventBtn : MonoBehaviour
{
    Image img;
    Button btn;
    Handler handler;

    private void Start()
    {
        img = GetComponent<Image>();
        btn = GetComponent<Button>();

        handler = FindObjectOfType<Handler>();

        btn.onClick.AddListener(() => handler.AddEvent(btn.name, img.sprite));
    }

    private void OnMouseEnter()
    {
        ButtonManager.instance.DesWindowOn(gameObject.name);
    }

    private void OnMouseExit()
    {
        ButtonManager.instance.DesWindowOff();
    }
}
