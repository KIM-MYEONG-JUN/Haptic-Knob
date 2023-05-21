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

    public GameManager gm; // Game Manager ���԰���
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

        if (!inPlay) // ������ �������� �ʾ��� ��
            transform.position = paddle.position; // ���� ��ġ�� �е� ���� ����

        if (Input.GetKeyDown(KeyCode.Space) && !inPlay && it.isClose) // Space Bar �Է� ���� (One Time), ������ ���۵��� �ʾ��� ��
        {
            inPlay = true; // ���� ����
            rb.AddForce(Vector2.up * speed); // y�� �������� ���� Ƣ�� ����
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
