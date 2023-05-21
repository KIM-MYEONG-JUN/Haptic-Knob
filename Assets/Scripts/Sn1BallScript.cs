using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sn1BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform paddle;
    public float speed;

    public bool inPlay;
    public bool isPaused;

    public GameManager gm; // Game Manager 포함관계
    public PaddleScript ps;
    public IntroScript it;

    public GameObject sunPanel;
    public GameObject mercuryPanel;
    public GameObject venusPanel;
    public GameObject earthPanel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ps = FindObjectOfType<PaddleScript>();
        it = FindObjectOfType<IntroScript>();
        it.Panel.SetActive(true);
    }

    void Update()
    {
        if (gm.gameOver)
        {
            transform.position = paddle.position;
            return;
        }

        if (!inPlay) // 게임이 시작하지 않았을 때
            transform.position = paddle.position; // 공의 위치를 패들 위로 고정

        if (Input.GetKeyDown(KeyCode.Space) && !inPlay && it.isClose) // Space Bar 입력 감지 (One Time), 게임이 시작되지 않았을 때
        {
            inPlay = true; // 게임 시작
            rb.AddForce(Vector2.up * speed); // y축 방향으로 공이 튀어 오름
        }

        if (isPaused && Input.GetKeyDown(KeyCode.Space))
        {
            isPaused = false;
            sunPanel.SetActive(false);
            mercuryPanel.SetActive(false);
            venusPanel.SetActive(false);
            earthPanel.SetActive(false);
            Time.timeScale = 1f;
        }

        if (!it.isClose) // isClose가 false일 때
            return; // 게임 시작하지 않도록 함수 종료
    }

    void OnTriggerEnter2D(Collider2D other) // 하단 트리거 박스 충돌 시 (공이 바닥으로 떨어졌을 때)
    {
        if (other.CompareTag("Bottom")) // Bottom 태그가 붙은 트리거 박스일 때
        {
            Debug.Log("Ball falls down the screen!"); // 메시지 출력
            rb.velocity = Vector2.zero; // 공의 속도 0으로 초기화
            inPlay = false; // 게임 종료
            gm.UpdateLife(1);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Brick"))
        {
            Destroy(other.gameObject);
            gm.UpdateNumberOfBricks();
        }
        else if (other.transform.CompareTag("Sun Brick"))
        {
            Destroy(other.gameObject);
            gm.UpdateNumberOfBricks();
            
            sunPanel.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
        }
        else if (other.transform.CompareTag("Mercury Brick"))
        {
            Destroy(other.gameObject);
            gm.UpdateNumberOfBricks();

            mercuryPanel.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
        }
        else if (other.transform.CompareTag("Venus Brick"))
        {
            Destroy(other.gameObject);
            gm.UpdateNumberOfBricks();

            venusPanel.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
        }
        else if (other.transform.CompareTag("Earth Brick"))
        {
            Destroy(other.gameObject);
            gm.UpdateNumberOfBricks();

            earthPanel.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
        }
    }
}
