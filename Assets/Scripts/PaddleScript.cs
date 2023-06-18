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

        float horizontal = Input.GetAxis("Horizontal"); // 키보드 a, d /  <-, -> 입력

        transform.Translate (Vector2.right * horizontal * Time.deltaTime * speed); // 속도 계산
        
        if (transform.position.x < leftScreenEdge) // x축을 기준으로 화면 왼쪽 밖으로 벗어날 때
        {
            transform.position = new Vector2(leftScreenEdge, transform.position.y); // leftScreenEdge의 좌표에 포지션 고정
        }

        if (transform.position.x > rightScreenEdge) // x축을 기준으로 화면 오른쪽 밖으로 벗어날 때
        {
            transform.position = new Vector2(rightScreenEdge, transform.position.y); // rightScreenEdge의 좌표에 포지션 고정
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Attack"))
        {
            audioSource.Play();
            Debug.Log("Attacked!!!"); // 로그 출력
            speed = 5; // 공격 받았을 때의 동작
            Destroy(other.gameObject); // 공격 오브젝트 삭제
        }

        if (other.gameObject.CompareTag("Repair"))
        {
            audioSource.Play();
            Debug.Log("Repaired!!!"); // 로그 출력
            speed = 10; // 아이템을 획득했을 때의 동작
            Destroy(other.gameObject); // 아이템 오브젝트 삭제
        }
    }
}
