using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Video;

public class Sn1BallScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform paddle;
    private float speed = 550;

    public bool inPlay;

    public GameManager gm; // Game Manager 포함관계
    private PaddleScript ps;
    private IntroScript it;

    public GameObject sunPanel;
    public GameObject mercuryPanel;
    public GameObject venusPanel;
    public GameObject earthPanel;

    public AudioSource audioSource;

    public Animation anim;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        audioSource.Play();

        if (other.transform.CompareTag("Brick"))
        {
            Destroy(other.gameObject);
        }
        else if (other.transform.CompareTag("Sun Brick"))
        {
            Destroy(other.gameObject);

            inPlay = false;
            rb.velocity = Vector2.zero;

            sunPanel.SetActive(true);
            anim.Play("Open");
            StartCoroutine(PlaySunVideo());
        }
        else if (other.transform.CompareTag("Mercury Brick"))
        {
            Destroy(other.gameObject);

            inPlay = false;
            rb.velocity = Vector2.zero;

            mercuryPanel.SetActive(true);
            anim.Play("Open");
            StartCoroutine(PlayMercuryVideo());
        }
        else if (other.transform.CompareTag("Venus Brick"))
        {
            Destroy(other.gameObject);

            inPlay = false;
            rb.velocity = Vector2.zero;

            venusPanel.SetActive(true);
            anim.Play("Open");
            StartCoroutine(PlayVenusVideo());
        }
        else if (other.transform.CompareTag("Earth Brick"))
        {
            Destroy(other.gameObject);

            inPlay = false;
            rb.velocity = Vector2.zero;
          
            earthPanel.SetActive(true);
            anim.Play("Open");
            StartCoroutine(PlayEarthVideo());
        }
    }

    private IEnumerator PlaySunVideo()
    {
        // 비디오의 길이만큼 기다림
        yield return new WaitForSeconds(2f);

        gm.UpdateNumberOfBricks();

        // 비디오 재생 종료 후 실행될 코드
        anim.Play("Close");
        sunPanel.SetActive(false);
    }

    private IEnumerator PlayMercuryVideo()
    {
        // 비디오의 길이만큼 기다림
        yield return new WaitForSeconds(2f);

        gm.UpdateNumberOfBricks();

        // 비디오 재생 종료 후 실행될 코드
        anim.Play("Close");
        mercuryPanel.SetActive(false);
    }

    private IEnumerator PlayVenusVideo()
    {
        // 비디오의 길이만큼 기다림
        yield return new WaitForSeconds(2f);

        gm.UpdateNumberOfBricks();

        // 비디오 재생 종료 후 실행될 코드
        anim.Play("Close");
        venusPanel.SetActive(false);
    }

    private IEnumerator PlayEarthVideo()
    {
        // 비디오의 길이만큼 기다림
        yield return new WaitForSeconds(2f);

        gm.UpdateNumberOfBricks();

        // 비디오 재생 종료 후 실행될 코드
        anim.Play("Close");
        earthPanel.SetActive(false);
    }

    /*
     *     private IEnumerator PlayVideoAndWait()
    {
        // 비디오 재생
        // videoPlayer.Play();

        // 비디오의 길이를 가져옴
        // float videoLength = (float)videoPlayer.length;

        // 비디오의 길이만큼 기다림
        yield return new WaitForSeconds(2f);

        gm.UpdateNumberOfBricks();

        // 비디오 재생 종료 후 실행될 코드
        sunPanel.SetActive(false);
        mercuryPanel.SetActive(false);
        venusPanel.SetActive(false);
        earthPanel.SetActive(false);
    }
     */
}
