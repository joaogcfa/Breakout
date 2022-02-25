using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(0, -speed);
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            gm.vidas++;
            Destroy(gameObject);
        }
    }
}
