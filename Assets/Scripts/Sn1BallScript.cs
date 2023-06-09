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
        // ������ ���̸�ŭ ��ٸ�
        yield return new WaitForSeconds(2f);

        gm.UpdateNumberOfBricks();

        // ���� ��� ���� �� ����� �ڵ�
        anim.Play("Close");
        sunPanel.SetActive(false);
    }

    private IEnumerator PlayMercuryVideo()
    {
        // ������ ���̸�ŭ ��ٸ�
        yield return new WaitForSeconds(2f);

        gm.UpdateNumberOfBricks();

        // ���� ��� ���� �� ����� �ڵ�
        anim.Play("Close");
        mercuryPanel.SetActive(false);
    }

    private IEnumerator PlayVenusVideo()
    {
        // ������ ���̸�ŭ ��ٸ�
        yield return new WaitForSeconds(2f);

        gm.UpdateNumberOfBricks();

        // ���� ��� ���� �� ����� �ڵ�
        anim.Play("Close");
        venusPanel.SetActive(false);
    }

    private IEnumerator PlayEarthVideo()
    {
        // ������ ���̸�ŭ ��ٸ�
        yield return new WaitForSeconds(2f);

        gm.UpdateNumberOfBricks();

        // ���� ��� ���� �� ����� �ڵ�
        anim.Play("Close");
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
