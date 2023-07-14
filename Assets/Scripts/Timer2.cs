using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer2 : MonoBehaviour
{
    public float timer;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SceneManager.LoadScene("Outer Planet");
        }
    }
}