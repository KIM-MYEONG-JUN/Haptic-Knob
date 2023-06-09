using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    public GameObject Panel;
    public bool isClose = false;

    public void Next()
    {
        isClose = true;
        Panel.SetActive(false);
    }

    public void Prev1()
    {
        SceneManager.LoadScene("Intro");
    }

    public void Prev2()
    {
        SceneManager.LoadScene("Ch1.Space");
    }
}