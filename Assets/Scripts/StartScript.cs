using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public void Space()
    {
        SceneManager.LoadScene("Ch1.Space"); // Scene �̵�
        Debug.Log("����");
    }

    public void Animal()
    {
        SceneManager.LoadScene("Ch1.Animal"); // Scene �̵�
        Debug.Log("����");
    }

    public void Dino()
    {
        SceneManager.LoadScene("Ch1.Dino"); // Scene �̵�
        Debug.Log("����");
    }

    public void Intro()
    {
        SceneManager.LoadScene("Intro"); // Scene �̵�
        Debug.Log("��Ʈ��");
    }
}
