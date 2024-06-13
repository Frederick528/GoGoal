using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]
    public bool operable = true;

    [SerializeField]
    bool fastMode;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (fastMode)
        {
            Time.timeScale = 3f;
        }
        else { Time.timeScale = 1; }
    }
#endif
}
