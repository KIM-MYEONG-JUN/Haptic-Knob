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

    void Start()
    {
        knob = FindObjectOfType<Function>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }

        if (knob.count >= 1)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (knob.count <= -1)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (transform.position.x < leftScreenEdge) // x���� �������� ȭ�� ���� ������ ��� ��
        {
            transform.position = new Vector2(leftScreenEdge, transform.position.y); // leftScreenEdge�� ��ǥ�� ������ ����
        }

        if (transform.position.x > rightScreenEdge) // x���� �������� ȭ�� ������ ������ ��� ��
        {
            transform.position = new Vector2(rightScreenEdge, transform.position.y); // rightScreenEdge�� ��ǥ�� ������ ����
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Attack"))
        {
            audioSource.Play();
            Debug.Log("Attacked!!!"); // �α� ���
            speed = 5; // ���� �޾��� ���� ����
            Destroy(other.gameObject); // ���� ������Ʈ ����
        }

        if (other.gameObject.CompareTag("Repair"))
        {
            audioSource.Play();
            Debug.Log("Repaired!!!"); // �α� ���
            speed = 10; // �������� ȹ������ ���� ����
            knob.OnclickOff();
            Destroy(other.gameObject); // ������ ������Ʈ ����
        }
    }
}
