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

        if (transform.position.x <= leftScreenEdge) // x축을 기준으로 화면 왼쪽 밖으로 벗어날 때
        {
            transform.position = new Vector2(leftScreenEdge, transform.position.y); // leftScreenEdge의 좌표에 포지션 고정
            knob.OnclickBBumpy();
            isEdge = true;
            dummy = 1;
        }
        else if (transform.position.x >= rightScreenEdge) // x축을 기준으로 화면 오른쪽 밖으로 벗어날 때
        {
            transform.position = new Vector2(rightScreenEdge, transform.position.y); // rightScreenEdge의 좌표에 포지션 고정
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
            Debug.Log("Attacked!!!"); // 로그 출력
            Destroy(other.gameObject); // 공격 오브젝트 삭제
        }

        if (other.gameObject.CompareTag("Repair"))
        {
            audioSource.Play();
            Debug.Log("Repaired!!!"); // 로그 출력
            Destroy(other.gameObject); // 아이템 오브젝트 삭제
        }
    }
}
