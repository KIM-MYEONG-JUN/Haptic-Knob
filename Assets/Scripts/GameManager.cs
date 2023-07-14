using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int life; // 라이프
    public Text lifeText; // 라이프 텍스트

    public bool gameOver; // 게임 오버 판단

    public GameObject gameOverPanel; // 게임 오버 창
    public GameObject gameClearPanel; // 게임 클리어 창

    public int sumOfBricks; // 벽돌 개수 총합

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        lifeText.text = "LIFE : " + life; // 라이프 텍스트 초기화

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
        life -= damage; // 데미지에 따라 라이프 감소

        if(life <= 0) // 라이프가 0 이하가 되었을 때
        {
            life = 0; // 라이프 0으로 초기화
            GameOver(); // 게임 오버
        }

        lifeText.text = "LIFE : " + life; // 라이프 업데이트
    }

    public void UpdateNumberOfBricks()
    {
        sumOfBricks -= 1; // 벽돌 개수 감소
        if (sumOfBricks <= 0) // 벽돌 개수가 0 이하가 되었을 때
        {
            GameClear(); // 게임 클리어
        }
    }

    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true); // 게임 오버 패널 활성화
    }

    void GameClear()
    {
        gameOver = true;
        gameClearPanel.SetActive(true); // 게임 클리어 패널 활성화
    }

    public void Space1()
    {
        SceneManager.LoadScene("Ch1.Space"); // Scene 이동
    }

    public void Space2()
    {
        SceneManager.LoadScene("Ch2.Space"); // Scene 이동
    }

    public void Middle1()
    {
        SceneManager.LoadScene("Inner Planet"); // Scene 이동
    }

    public void Middle2()
    {
        SceneManager.LoadScene("Outer Planet"); // Scene 이동
    }

    public void Animal1()
    {
        SceneManager.LoadScene("Ch1.Animal"); // Scene 이동
    }
}
