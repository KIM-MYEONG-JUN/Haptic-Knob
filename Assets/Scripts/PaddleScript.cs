using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float speed;
    public float rightScreenEdge;
    public float leftScreenEdge;
    public GameManager gm;
    public Function knob;

    public AudioSource audioSource;

    private bool isEdge;
    private int dummy = 0;

    private Sn2BallScript b2;

    void Start()
    {
        knob = FindObjectOfType<Function>();
        b2 = FindObjectOfType<Sn2BallScript>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }

        if (knob.count > 1)
        {
            transform.position += Vector3.right * speed;
            knob.count = 0;
        }
        if (knob.count < -1)
        {
            transform.position += Vector3.left * speed;
            knob.count = 0;
        }

        if (transform.position.x <= leftScreenEdge) // x���� �������� ȭ�� ���� ������ ��� ��
        {
            transform.position = new Vector2(leftScreenEdge, transform.position.y); // leftScreenEdge�� ��ǥ�� ������ ����
            knob.OnclickBBumpy();
            isEdge = true;
            dummy = 1;
        }
        else if (transform.position.x >= rightScreenEdge) // x���� �������� ȭ�� ������ ������ ��� ��
        {
            transform.position = new Vector2(rightScreenEdge, transform.position.y); // rightScreenEdge�� ��ǥ�� ������ ����
            knob.OnclickBBumpy();
            isEdge = true;
            dummy = 1;
        }

        if (transform.position.x < rightScreenEdge && transform.position.x > leftScreenEdge)
        {
            isEdge = false;
        }

        if (!isEdge && dummy != 0)
        {
            if (b2.num == 1)
            {
                knob.OnclickABumpy();
            }
            else if (b2.num == 2)
            {
                knob.OnclickBBumpy();
            }
            else if (b2.num == 3)
            {
                knob.OnclickCBumpy();
            }
            else
            {
                knob.OnclickOff();
            }
            
            dummy = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Attack"))
        {
            audioSource.Play();
            Debug.Log("Attacked!!!"); // �α� ���
            Destroy(other.gameObject); // ���� ������Ʈ ����
        }

        if (other.gameObject.CompareTag("Repair"))
        {
            audioSource.Play();
            Debug.Log("Repaired!!!"); // �α� ���
            Destroy(other.gameObject); // ������ ������Ʈ ����
        }
    }
}
