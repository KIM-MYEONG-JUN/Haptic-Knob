using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Video;

public class A1Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform paddle;
    private float speed = 550;

    public bool inPlay;

    public GameManager gm; // Game Manager 포함관계
    private PaddleScript ps;
    private IntroScript it;

    public GameObject lionPanel;
    public GameObject rabbitPanel;
    public GameObject elephantPanel;
    public GameObject rhinoPanel;
    public GameObject monkeyPanel;
    public GameObject giraffaPanel;

    public AudioSource audioSource;

    public GameObject knob;

    public Animation anim;

    private GameObject camera;

    public int num = 0;

    void Start()
    {
        camera = GameObject.Find("Main Camera");
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

    private void Sound_low()
    {
        camera.GetComponent<AudioSource>().volume = 0.4f;
    }

    private void Sound_HIgh()
    {
        camera.GetComponent<AudioSource>().volume = 1.0f;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Brick"))
        {
            audioSource.Play();
            Destroy(other.gameObject);
        }
        else if (other.transform.CompareTag("Lion Brick"))
        {
            audioSource.Play();
            Destroy(other.gameObject);

            inPlay = false;
            rb.velocity = Vector2.zero;

            lionPanel.SetActive(true);
            anim = lionPanel.GetComponent<Animation>();
            anim.Play("Open");
            StartCoroutine(PlayLionVideo());
        }
        else if (other.transform.CompareTag("Rabbit Brick"))
        {
            audioSource.Play();
            Destroy(other.gameObject);

            inPlay = false;
            rb.velocity = Vector2.zero;

            rabbitPanel.SetActive(true);
            anim = rabbitPanel.GetComponent<Animation>();
            anim.Play("Open");
            StartCoroutine(PlayRabbitVideo());
        }
        else if (other.transform.CompareTag("Elephant Brick"))
        {
            audioSource.Play();
            Destroy(other.gameObject);

            inPlay = false;
            rb.velocity = Vector2.zero;

            elephantPanel.SetActive(true);
            anim = elephantPanel.GetComponent<Animation>();
            anim.Play("Open");
            StartCoroutine(PlayElephantVideo());
        }
        else if (other.transform.CompareTag("Rhino Brick"))
        {
            audioSource.Play();
            Destroy(other.gameObject);

            inPlay = false;
            rb.velocity = Vector2.zero;

            rhinoPanel.SetActive(true);
            anim = rhinoPanel.GetComponent<Animation>();
            anim.Play("Open");
            StartCoroutine(PlayRhinoVideo());
        }
        else if (other.transform.CompareTag("Monkey Brick"))
        {
            audioSource.Play();
            Destroy(other.gameObject);

            inPlay = false;
            rb.velocity = Vector2.zero;

            monkeyPanel.SetActive(true);
            anim = monkeyPanel.GetComponent<Animation>();
            anim.Play("Open");
            StartCoroutine(PlayMonkeyVideo());
        }
        else if (other.transform.CompareTag("Giraffa Brick"))
        {
            audioSource.Play();
            Destroy(other.gameObject);

            inPlay = false;
            rb.velocity = Vector2.zero;

            giraffaPanel.SetActive(true);
            anim = giraffaPanel.GetComponent<Animation>();
            anim.Play("Open");
            StartCoroutine(PlayGiraffaVideo());
        }
        else if (other.transform.CompareTag("Haptic Brick1"))
        {
            audioSource.Play();
            Destroy(other.gameObject);
            anim = camera.GetComponent<Animation>();
            anim.Play("Camera");
            knob.GetComponent<Function>().OnclickABumpy();
            num = 1;
        }
        else if (other.transform.CompareTag("Haptic Brick2"))
        {
            audioSource.Play();
            Destroy(other.gameObject);
            anim = camera.GetComponent<Animation>();
            anim.Play("Camera");
            knob.GetComponent<Function>().OnclickBBumpy();
            num = 2;
        }
        else if (other.transform.CompareTag("Haptic Brick3"))
        {
            audioSource.Play();
            Destroy(other.gameObject);
            anim = camera.GetComponent<Animation>();
            anim.Play("Camera");
            knob.GetComponent<Function>().OnclickCBumpy();
            num = 3;
        }
    }

    private IEnumerator PlayLionVideo()
    {
        Sound_low();
        // 비디오의 길이만큼 기다림
        yield return new WaitForSeconds(10f);

        gm.UpdateNumberOfBricks();

        // 비디오 재생 종료 후 실행될 코드
        anim = lionPanel.GetComponent<Animation>();
        anim.Play("Close");
        Sound_HIgh();
        yield return new WaitForSeconds(1f);
        lionPanel.SetActive(false);
    }

    private IEnumerator PlayRabbitVideo()
    {
        Sound_low();
        // 비디오의 길이만큼 기다림
        yield return new WaitForSeconds(10f);

        gm.UpdateNumberOfBricks();

        // 비디오 재생 종료 후 실행될 코드
        anim = rabbitPanel.GetComponent<Animation>();
        anim.Play("Close");
        Sound_HIgh();
        yield return new WaitForSeconds(1f);
        rabbitPanel.SetActive(false);
    }

    private IEnumerator PlayElephantVideo()
    {
        Sound_low();
        // 비디오의 길이만큼 기다림
        yield return new WaitForSeconds(10f);

        gm.UpdateNumberOfBricks();

        // 비디오 재생 종료 후 실행될 코드
        anim = elephantPanel.GetComponent<Animation>();
        anim.Play("Close");
        Sound_HIgh();
        yield return new WaitForSeconds(1f);
        elephantPanel.SetActive(false);
    }

    private IEnumerator PlayRhinoVideo()
    {
        Sound_low();
        // 비디오의 길이만큼 기다림
        yield return new WaitForSeconds(10f);

        gm.UpdateNumberOfBricks();

        // 비디오 재생 종료 후 실행될 코드
        anim = rhinoPanel.GetComponent<Animation>();
        anim.Play("Close");
        Sound_HIgh();
        yield return new WaitForSeconds(1f);
        rhinoPanel.SetActive(false);
    }

    private IEnumerator PlayMonkeyVideo()
    {
        Sound_low();
        // 비디오의 길이만큼 기다림
        yield return new WaitForSeconds(10f);

        gm.UpdateNumberOfBricks();

        // 비디오 재생 종료 후 실행될 코드
        anim = monkeyPanel.GetComponent<Animation>();
        anim.Play("Close");
        Sound_HIgh();
        yield return new WaitForSeconds(1f);
        monkeyPanel.SetActive(false);
    }

    private IEnumerator PlayGiraffaVideo()
    {
        Sound_low();
        // 비디오의 길이만큼 기다림
        yield return new WaitForSeconds(10f);

        gm.UpdateNumberOfBricks();

        // 비디오 재생 종료 후 실행될 코드
        anim = giraffaPanel.GetComponent<Animation>();
        anim.Play("Close");
        Sound_HIgh();
        yield return new WaitForSeconds(1f);
        giraffaPanel.SetActive(false);
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
