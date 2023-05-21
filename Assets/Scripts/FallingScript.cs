using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingScript : MonoBehaviour
{
    public float speed; // ³«ÇÏ ¼Óµµ

    void Update()
    {
        transform.Translate(new Vector2(0f, -1f) * Time.deltaTime * speed); // ¿ÀºêÁ§Æ® ³«ÇÏ

        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }
}
