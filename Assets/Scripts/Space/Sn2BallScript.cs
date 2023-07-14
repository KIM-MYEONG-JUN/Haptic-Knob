using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sn2BallScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform paddle;
    private float speed = 550;

    private bool inPlay;

    public GameManager gm; // Game Manager ���԰���
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

    private GameObject camera;

    public int num = 0;

    void Start()
    {
        camera = GameObject.Find("Main Camera");
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
        else if (other.transform.CompareTag("Mars Brick"))
        {
            audioSource.Play();
            Destroy(other.gameObject);
            if (at.isAttack) Instantiate(repair, transform.position, transform.rotation);

            isOpenVideo = true;
            inPlay = false;
            rb.velocity = Vector2.zero;

            //�Ʒ� ������ �ִϸ��̼� ���� �κ� Ȯ�� �ʿ�
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

    private IEnumerator PlayMarsVideo()
    {
        Sound_low();
        // ������ ���̸�ŭ ��ٸ�
        yield return new WaitForSeconds(36f);

        // ���� ��� ���� �� ����� �ڵ�
        anim = marsPanel.GetComponent<Animation>();
        anim.Play("Close");
        Sound_HIgh();
        yield return new WaitForSeconds(1f);
        gm.UpdateNumberOfBricks();
        marsPanel.SetActive(false);
        isOpenVideo = false;
    }

    private IEnumerator PlaySaturnVideo()
    {
        Sound_low();
        // ������ ���̸�ŭ ��ٸ�
        yield return new WaitForSeconds(21.8f);

        // ���� ��� ���� �� ����� �ڵ�
        anim = saturnPanel.GetComponent<Animation>();
        anim.Play("Close");
        Sound_HIgh();
        yield return new WaitForSeconds(1f);
        gm.UpdateNumberOfBricks();
        saturnPanel.SetActive(false);
        isOpenVideo = false;
    }

    private IEnumerator PlayJupiterVideo()
    {
        Sound_low();
        // ������ ���̸�ŭ ��ٸ�
        yield return new WaitForSeconds(36f);

        // ���� ��� ���� �� ����� �ڵ�
        anim = jupiterPanel.GetComponent<Animation>();
        anim.Play("Close");
        Sound_HIgh();
        yield return new WaitForSeconds(1f);
        gm.UpdateNumberOfBricks();
        jupiterPanel.SetActive(false);
        isOpenVideo = false;
    }
}