using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sn2BallScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform paddle;
    private float speed = 550;

    public bool inPlay;

    public GameManager gm; // Game Manager ���԰���
    private PaddleScript ps;
    private AttackScript at;
    private IntroScript it;

    public Transform repair;

    public GameObject marsPanel;
    public GameObject jupiterPanel;
    public GameObject saturnPanel;

    public AudioSource audioSource;

    public Animation anim;

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
        else if (other.transform.CompareTag("Mars Brick"))
        {
            Destroy(other.gameObject);
            if (at.isAttack) Instantiate(repair, transform.position, transform.rotation);

            inPlay = false;
            rb.velocity = Vector2.zero;

            marsPanel.SetActive(true);
            anim.Play("Open");
            StartCoroutine(PlayMarsVideo());
        }
        else if (other.transform.CompareTag("Saturn Brick"))
        {
            Destroy(other.gameObject);
            if (at.isAttack) Instantiate(repair, transform.position, transform.rotation);

            inPlay = false;
            rb.velocity = Vector2.zero;

            saturnPanel.SetActive(true);
            anim.Play("Open");
            StartCoroutine(PlaySaturnVideo());
        }
        else if (other.transform.CompareTag("Jupiter Brick"))
        {
            Destroy(other.gameObject);
            if (at.isAttack) Instantiate(repair, transform.position, transform.rotation);

            inPlay = false;
            rb.velocity = Vector2.zero;

            jupiterPanel.SetActive(true);
            anim.Play("Open");
            StartCoroutine(PlayJupiterVideo());
        }
        else if (other.transform.CompareTag("Haptic Brick1"))
        {
            Destroy(other.gameObject);
            ps.speed = 7;
        }
        else if (other.transform.CompareTag("Haptic Brick2"))
        {
            Destroy(other.gameObject);
            ps.speed = 5;
        }
        else if (other.transform.CompareTag("Haptic Brick3"))
        {
            Destroy(other.gameObject);
            ps.speed = 3;
        }
    }

    private IEnumerator PlayMarsVideo()
    {
        // ������ ���̸�ŭ ��ٸ�
        yield return new WaitForSeconds(2f);

        gm.UpdateNumberOfBricks();

        // ���� ��� ���� �� ����� �ڵ�
        anim.Play("Close");
        marsPanel.SetActive(false);
    }

    private IEnumerator PlaySaturnVideo()
    {
        // ������ ���̸�ŭ ��ٸ�
        yield return new WaitForSeconds(2f);

        gm.UpdateNumberOfBricks();

        // ���� ��� ���� �� ����� �ڵ�
        anim.Play("Close");
        saturnPanel.SetActive(false);
    }

    private IEnumerator PlayJupiterVideo()
    {
        // ������ ���̸�ŭ ��ٸ�
        yield return new WaitForSeconds(2f);

        gm.UpdateNumberOfBricks();

        // ���� ��� ���� �� ����� �ڵ�
        anim.Play("Close");
        jupiterPanel.SetActive(false);
    }
}
