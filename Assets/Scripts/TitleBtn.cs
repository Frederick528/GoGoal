using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleBtn : MonoBehaviour
{
    public void EnterStage()
    {
        SceneManager.LoadScene("InGame");
    }
}
