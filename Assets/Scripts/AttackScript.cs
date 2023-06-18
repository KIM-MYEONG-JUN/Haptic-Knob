using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject attack; // ������ ��Ÿ���� ������Ʈ
    private Vector2 start; // ���� ����
    public float interval; // ���� ����
    public float delay; // ���� ���� ������
    public bool isAttack;

    private Sn2BallScript b2;

    private void Start()
    {
        b2 = FindObjectOfType<Sn2BallScript >();
        start = new Vector2(transform.position.x, (float)(transform.position.y - 0.5)); // ���� ��ġ �ʱ�ȭ
        InvokeRepeating("LaunchAttack", delay, interval); // �ݺ� ȣ��
    }

    private void LaunchAttack()
    {
        if (b2.isOpenVideo == false)
        {
            GameObject newAttack = Instantiate(attack, start, transform.rotation); // ���� ������Ʈ ����
            StartCoroutine(MoveAttack(newAttack)); // �ڷ�ƾ ����
        }
    }

    private IEnumerator MoveAttack(GameObject attack)
    {
        isAttack = true;
        while (true) // ���� ����
        {
            if (attack == null) // ������ �ð��� �����ų� ���� ������Ʈ�� ������ ��
            {
                break; // ���� Ż��
            }
            yield return null; // ���� ���������� �̵�
        }
    }
}
