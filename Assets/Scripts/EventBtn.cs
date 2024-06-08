using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventBtn : MonoBehaviour
{
    Image img;
    Button btn;
    Handler handler;
    
    GameObject des;

    private void Start()
    {
        img = GetComponent<Image>();
        btn = GetComponent<Button>();

        handler = FindObjectOfType<Handler>();
        
        des = ButtonManager.instance.description;

        btn.onClick.AddListener(() => handler.AddEvent(btn.name, img.sprite));
    }

    private void OnMouseEnter()
    {
        des.SetActive(true);
    }

    private void OnMouseExit()
    {
        des.SetActive(false);
    }
}
