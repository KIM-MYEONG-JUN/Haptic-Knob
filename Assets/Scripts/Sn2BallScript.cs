using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sn2BallScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform paddle;
    private float speed = 550;

    private bool inPlay;

    public GameManager gm; // Game Manager 포함관계
    private PaddleScript ps;
    private AttackScript at;
    private IntroScript it;

    public Transform repair;

    public GameObject marsPanel;
    public GameObject jupiterPanel;
    public GameObject saturnPanel;

    public AudioSource audioSource;

    public GameObject knob;

    public Animation anim;

    public bool isOpenVideo = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        ps = FindObjectOfType<PaddleScript>();
        at = FindObjectOfType<AttackScript>();
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
        if (other.transform.CompareTag("Brick"))
        {
            audioSource.Play();
            Destroy(other.gameObject);
        }
        else if (other.transform.CompareTag("Mars Brick"))
        {
            audioSource.Play();
            Destroy(other.gameObject);
            if (at.isAttack) Instantiate(repair, transform.position, transform.rotation);

            isOpenVideo = true;
            inPlay = false;
            rb.velocity = Vector2.zero;

            //아래 세줄이 애니메이션 관련 부분 확인 필요
            marsPanel.SetActive(true);
            anim = marsPanel.GetComponent<Animation>();
            anim.Play("Open");
            StartCoroutine(PlayMarsVideo());
        }
        else if (other.transform.CompareTag("Saturn Brick"))
        {
            audioSource.Play();
            Destroy(other.gameObject);
            if (at.isAttack) Instantiate(repair, transform.position, transform.rotation);

            isOpenVideo = true;
            inPlay = false;
            rb.velocity = Vector2.zero;

            saturnPanel.SetActive(true);
            anim = saturnPanel.GetComponent<Animation>();
            anim.Play("Open");
            StartCoroutine(PlaySaturnVideo());
        }
        else if (other.transform.CompareTag("Jupiter Brick"))
        {
            audioSource.Play();
            Destroy(other.gameObject);
            if (at.isAttack) Instantiate(repair, transform.position, transform.rotation);

            isOpenVideo = true;
            inPlay = false;
            rb.velocity = Vector2.zero;

            jupiterPanel.SetActive(true);
            anim = jupiterPanel.GetComponent<Animation>();
            Debug.Log(anim);
            anim.Play("Open");
            StartCoroutine(PlayJupiterVideo());
        }
        else if (other.transform.CompareTag("Haptic Brick1"))
        {
            audioSource.Play();
            Destroy(other.gameObject);
            knob.GetComponent<Function>().OnclickABumpy();
            ps.speed = 7;
        }
        else if (other.transform.CompareTag("Haptic Brick2"))
        {
            audioSource.Play();
            Destroy(other.gameObject);
            knob.GetComponent<Function>().OnclickBBumpy();
            ps.speed = 5;
        }
        else if (other.transform.CompareTag("Haptic Brick3"))
        {
            audioSource.Play();
            Destroy(other.gameObject);
            knob.GetComponent<Function>().OnclickCBumpy();
            ps.speed = 3;
        }
    }

    private IEnumerator PlayMarsVideo()
    {
        // 비디오의 길이만큼 기다림
        yield return new WaitForSeconds(10f);

        gm.UpdateNumberOfBricks();

        // 비디오 재생 종료 후 실행될 코드
        anim = marsPanel.GetComponent<Animation>();
        anim.Play("Close");
        yield return new WaitForSeconds(1f);
        marsPanel.SetActive(false);
        isOpenVideo = false;
    }

    private IEnumerator PlaySaturnVideo()
    {
        // 비디오의 길이만큼 기다림
        yield return new WaitForSeconds(10f);

        gm.UpdateNumberOfBricks();

        // 비디오 재생 종료 후 실행될 코드
        anim = saturnPanel.GetComponent<Animation>();
        anim.Play("Close");
        yield return new WaitForSeconds(1f);
        saturnPanel.SetActive(false);
        isOpenVideo = false;
    }

    private IEnumerator PlayJupiterVideo()
    {
        // 비디오의 길이만큼 기다림
        yield return new WaitForSeconds(10f);

        gm.UpdateNumberOfBricks();

        // 비디오 재생 종료 후 실행될 코드
        anim = jupiterPanel.GetComponent<Animation>();
        anim.Play("Close");
        yield return new WaitForSeconds(1f);
        jupiterPanel.SetActive(false);
        isOpenVideo = false;
    }
}
