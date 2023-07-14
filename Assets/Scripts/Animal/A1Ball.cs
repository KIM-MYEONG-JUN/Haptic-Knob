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

    public GameManager gm; // Game Manager ���԰���
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
        // ������ ���̸�ŭ ��ٸ�
        yield return new WaitForSeconds(10f);

        gm.UpdateNumberOfBricks();

        // ���� ��� ���� �� ����� �ڵ�
        anim = lionPanel.GetComponent<Animation>();
        anim.Play("Close");
        Sound_HIgh();
        yield return new WaitForSeconds(1f);
        lionPanel.SetActive(false);
    }

    private IEnumerator PlayRabbitVideo()
    {
        Sound_low();
        // ������ ���̸�ŭ ��ٸ�
        yield return new WaitForSeconds(10f);

        gm.UpdateNumberOfBricks();

        // ���� ��� ���� �� ����� �ڵ�
        anim = rabbitPanel.GetComponent<Animation>();
        anim.Play("Close");
        Sound_HIgh();
        yield return new WaitForSeconds(1f);
        rabbitPanel.SetActive(false);
    }

    private IEnumerator PlayElephantVideo()
    {
        Sound_low();
        // ������ ���̸�ŭ ��ٸ�
        yield return new WaitForSeconds(10f);

        gm.UpdateNumberOfBricks();

        // ���� ��� ���� �� ����� �ڵ�
        anim = elephantPanel.GetComponent<Animation>();
        anim.Play("Close");
        Sound_HIgh();
        yield return new WaitForSeconds(1f);
        elephantPanel.SetActive(false);
    }

    private IEnumerator PlayRhinoVideo()
    {
        Sound_low();
        // ������ ���̸�ŭ ��ٸ�
        yield return new WaitForSeconds(10f);

        gm.UpdateNumberOfBricks();

        // ���� ��� ���� �� ����� �ڵ�
        anim = rhinoPanel.GetComponent<Animation>();
        anim.Play("Close");
        Sound_HIgh();
        yield return new WaitForSeconds(1f);
        rhinoPanel.SetActive(false);
    }

    private IEnumerator PlayMonkeyVideo()
    {
        Sound_low();
        // ������ ���̸�ŭ ��ٸ�
        yield return new WaitForSeconds(10f);

        gm.UpdateNumberOfBricks();

        // ���� ��� ���� �� ����� �ڵ�
        anim = monkeyPanel.GetComponent<Animation>();
        anim.Play("Close");
        Sound_HIgh();
        yield return new WaitForSeconds(1f);
        monkeyPanel.SetActive(false);
    }

    private IEnumerator PlayGiraffaVideo()
    {
        Sound_low();
        // ������ ���̸�ŭ ��ٸ�
        yield return new WaitForSeconds(10f);

        gm.UpdateNumberOfBricks();

        // ���� ��� ���� �� ����� �ڵ�
        anim = giraffaPanel.GetComponent<Animation>();
        anim.Play("Close");
        Sound_HIgh();
        yield return new WaitForSeconds(1f);
        giraffaPanel.SetActive(false);
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
