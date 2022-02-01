using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rb2d;

    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement=Input.GetAxis("Horizontal");
        float vertMovement=Input.GetAxis("Vertical");
        rb2d.AddForce(new Vector2(hozMovement*speed,vertMovement*speed));
    }

    void OnCOllisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag=="Ground")
        {
            if(Input.GetKey(KeyCode.X)||Input.GetKey(KeyCode.Space))
            {
                rb2d.AddForce(new Vector2(0,5), ForceMode2D.Impulse);
            }
        }
    }
}
