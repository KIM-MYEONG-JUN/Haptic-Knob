using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int life; // ������
    public Text lifeText; // ������ �ؽ�Ʈ

    public bool gameOver; // ���� ���� �Ǵ�

    public GameObject gameOverPanel; // ���� ���� â
    public GameObject gameClearPanel; // ���� Ŭ���� â

    public int sumOfBricks; // ���� ���� ����

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        lifeText.text = "LIFE : " + life; // ������ �ؽ�Ʈ �ʱ�ȭ

        if (sceneName == "Ch1.Space")
        {
            sumOfBricks = 3;
        }
        else if (sceneName == "Ch2.Space")
        {
            sumOfBricks = 3;
        }
        else if (sceneName == "Ch1.Animal")
        {
            sumOfBricks = 6;
        }
    }

    public void UpdateLife(int damage)
    {
        life -= damage; // �������� ���� ������ ����

        if(life <= 0) // �������� 0 ���ϰ� �Ǿ��� ��
        {
            life = 0; // ������ 0���� �ʱ�ȭ
            GameOver(); // ���� ����
        }

        lifeText.text = "LIFE : " + life; // ������ ������Ʈ
    }

    public void UpdateNumberOfBricks()
    {
        sumOfBricks -= 1; // ���� ���� ����
        if (sumOfBricks <= 0) // ���� ������ 0 ���ϰ� �Ǿ��� ��
        {
            GameClear(); // ���� Ŭ����
        }
    }

    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true); // ���� ���� �г� Ȱ��ȭ
    }

    void GameClear()
    {
        gameOver = true;
        gameClearPanel.SetActive(true); // ���� Ŭ���� �г� Ȱ��ȭ
    }

    public void Space1()
    {
        SceneManager.LoadScene("Ch1.Space"); // Scene �̵�
    }

    public void Space2()
    {
        SceneManager.LoadScene("Ch2.Space"); // Scene �̵�
    }

    public void Middle1()
    {
        SceneManager.LoadScene("Inner Planet"); // Scene �̵�
    }

    public void Middle2()
    {
        SceneManager.LoadScene("Outer Planet"); // Scene �̵�
    }

    public void Animal1()
    {
        SceneManager.LoadScene("Ch1.Animal"); // Scene �̵�
    }
}
