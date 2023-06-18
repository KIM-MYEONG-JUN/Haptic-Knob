using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject attack; // 공격을 나타내는 오브젝트
    private Vector2 start; // 시작 지점
    public float interval; // 공격 간격
    public float delay; // 공격 시작 딜레이
    public bool isAttack;

    private Sn2BallScript b2;

    private void Start()
    {
        b2 = FindObjectOfType<Sn2BallScript >();
        start = new Vector2(transform.position.x, (float)(transform.position.y - 0.5)); // 시작 위치 초기화
        InvokeRepeating("LaunchAttack", delay, interval); // 반복 호출
    }

    private void LaunchAttack()
    {
        if (b2.isOpenVideo == false)
        {
            GameObject newAttack = Instantiate(attack, start, transform.rotation); // 공격 오브젝트 복제
            StartCoroutine(MoveAttack(newAttack)); // 코루틴 시작
        }
    }

    private IEnumerator MoveAttack(GameObject attack)
    {
        isAttack = true;
        while (true) // 무한 루프
        {
            if (attack == null) // 지정한 시간이 지나거나 공격 오브젝트가 없어질 때
            {
                break; // 루프 탈출
            }
            yield return null; // 다음 프레임으로 이동
        }
    }
}
