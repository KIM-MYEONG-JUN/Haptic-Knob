using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public void Space()
    {
        SceneManager.LoadScene("Ch1.Space"); // Scene 이돌
        Debug.Log("우주");
    }

    public void Animal()
    {
        SceneManager.LoadScene("Ch1.Animal"); // Scene 이돌
        Debug.Log("동물");
    }

    public void Dino()
    {
        SceneManager.LoadScene("Ch1.Dino"); // Scene 이돌
        Debug.Log("공룡");
    }

    public void Intro()
    {
        SceneManager.LoadScene("Intro"); // Scene 이돌
        Debug.Log("인트로");
    }
}
