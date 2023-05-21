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
}
