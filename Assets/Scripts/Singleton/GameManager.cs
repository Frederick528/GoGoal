using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]
    public bool operable = true;

    void Awake()
    {
        instance ??= this;
        //if (instance != null)
        //{
        //    Destroy(gameObject);
        //    return;
        //}
        //instance = this;
        //DontDestroyOnLoad(gameObject);
    }
}
