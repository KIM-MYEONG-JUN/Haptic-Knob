using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingScript : MonoBehaviour
{
    public float speed; // ���� �ӵ�

    void Update()
    {
        transform.Translate(new Vector2(0f, -1f) * Time.deltaTime * speed); // ������Ʈ ����

        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }
}
