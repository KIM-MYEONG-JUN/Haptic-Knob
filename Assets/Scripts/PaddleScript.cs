using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float speed;
    public float rightScreenEdge;
    public float leftScreenEdge;
    public GameManager gm;

    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }

        float horizontal = Input.GetAxis("Horizontal"); // Ű���� a, d /  <-, -> �Է�

        transform.Translate (Vector2.right * horizontal * Time.deltaTime * speed); // �ӵ� ���
        
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
            Destroy(other.gameObject); // ������ ������Ʈ ����
        }
    }
}
