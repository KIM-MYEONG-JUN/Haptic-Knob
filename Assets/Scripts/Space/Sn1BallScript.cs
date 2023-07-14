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

    public GameManager gm; // Game Manager ���԰���
    private PaddleScript ps;
    private IntroScript it;

    public GameObject sunPanel;
    public GameObject mercuryPanel;
    public GameObject venusPanel;
    public GameObject earthPanel;

    public AudioSource audioSource;

    public Animation anim;

    private GameObject camera;

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

        if (!inPlay) // ������ �������� �ʾ��� ��
            transform.position = paddle.position; // ���� ��ġ�� �е� ���� ����

        if (Input.GetKeyDown(KeyCode.Space) && !inPlay && it.isClose) // Space Bar �Է� ���� (One Time), ������ ���۵��� �ʾ��� ��
        {
            inPlay = true; // ���� ����
            rb.AddForce(Vector2.up * speed); // y�� �������� ���� Ƣ�� ����
        }

        if (!it.isClose) // isClose�� false�� ��
            return; // ���� �������� �ʵ��� �Լ� ����
    }

    void OnTriggerEnter2D(Collider2D other) // �ϴ� Ʈ���� �ڽ� �浹 �� (���� �ٴ����� �������� ��)
    {
        if (other.CompareTag("Bottom")) // Bottom �±װ� ���� Ʈ���� �ڽ��� ��
        {
            Debug.Log("Ball falls down the screen!"); // �޽��� ���
            rb.velocity = Vector2.zero; // ���� �ӵ� 0���� �ʱ�ȭ
            inPlay = false; // ���� ����
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
        else if (other.transform.CompareTag("Sun Brick"))
        {
            audioSource.Play();
            Destroy(other.gameObject);

            inPlay = false;
            rb.velocity = Vector2.zero;

            sunPanel.SetActive(true);
            anim = sunPanel.GetComponent<Animation>();
            anim.Play("Open");
            StartCoroutine(PlaySunVideo());
        }
        else if (other.transform.CompareTag("Mercury Brick"))
        {
            audioSource.Play();
            Destroy(other.gameObject);

            inPlay = false;
            rb.velocity = Vector2.zero;

            mercuryPanel.SetActive(true);
            anim = mercuryPanel.GetComponent<Animation>();
            anim.Play("Open");
            StartCoroutine(PlayMercuryVideo());
        }
        else if (other.transform.CompareTag("Venus Brick"))
        {
            audioSource.Play();
            Destroy(other.gameObject);

            inPlay = false;
            rb.velocity = Vector2.zero;

            venusPanel.SetActive(true);
            anim = venusPanel.GetComponent<Animation>();
            anim.Play("Open");
            StartCoroutine(PlayVenusVideo());
        }
        else if (other.transform.CompareTag("Earth Brick"))
        {
            audioSource.Play();
            Destroy(other.gameObject);

            inPlay = false;
            rb.velocity = Vector2.zero;
          
            earthPanel.SetActive(true);
            anim = earthPanel.GetComponent<Animation>();
            anim.Play("Open");
            StartCoroutine(PlayEarthVideo());
        }
    }

    private IEnumerator PlaySunVideo()
    {
        Sound_low();
        // ������ ���̸�ŭ ��ٸ�
        yield return new WaitForSeconds(35f);

        gm.UpdateNumberOfBricks();

        // ���� ��� ���� �� ����� �ڵ�
        anim = sunPanel.GetComponent<Animation>();
        anim.Play("Close");
        Sound_HIgh();
        yield return new WaitForSeconds(1f);
        sunPanel.SetActive(false);
    }

    private IEnumerator PlayMercuryVideo()
    {
        Sound_low();
        // ������ ���̸�ŭ ��ٸ�
        yield return new WaitForSeconds(19f);

        gm.UpdateNumberOfBricks();

        // ���� ��� ���� �� ����� �ڵ�
        anim = mercuryPanel.GetComponent<Animation>();
        anim.Play("Close");
        Sound_HIgh();
        yield return new WaitForSeconds(1f);
        mercuryPanel.SetActive(false);
    }

    private IEnumerator PlayVenusVideo()
    {
        Sound_low();
        // ������ ���̸�ŭ ��ٸ�
        yield return new WaitForSeconds(10f);

        gm.UpdateNumberOfBricks();

        // ���� ��� ���� �� ����� �ڵ�
        anim = venusPanel.GetComponent<Animation>();
        anim.Play("Close");
        Sound_HIgh();
        yield return new WaitForSeconds(1f);
        venusPanel.SetActive(false);
    }

    private IEnumerator PlayEarthVideo()
    {
        Sound_low();
        // ������ ���̸�ŭ ��ٸ�
        yield return new WaitForSeconds(30f);

        gm.UpdateNumberOfBricks();

        // ���� ��� ���� �� ����� �ڵ�
        anim = earthPanel.GetComponent<Animation>();
        anim.Play("Close");
        Sound_HIgh();
        yield return new WaitForSeconds(1f);
        earthPanel.SetActive(false);
    }

    /*
     *     private IEnumerator PlayVideoAndWait()
    {
        // ���� ���
        // videoPlayer.Play();

        // ������ ���̸� ������
        // float videoLength = (float)videoPlayer.length;

        // ������ ���̸�ŭ ��ٸ�
        yield return new WaitForSeconds(2f);

        gm.UpdateNumberOfBricks();

        // ���� ��� ���� �� ����� �ڵ�
        sunPanel.SetActive(false);
        mercuryPanel.SetActive(false);
        venusPanel.SetActive(false);
        earthPanel.SetActive(false);
    }
     */
}
