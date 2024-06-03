using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleActBtns : MonoBehaviour
{
    public void EnterStage()
    {
        SceneManager.LoadScene("InGame");
    }
}
