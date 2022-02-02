using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stomper : MonoBehaviour
{
    public int damageToDeal;
private Rigidbody2D rigidBody;
public float bounceForce;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody=transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
  private void OnTriggerEnter2D(Collider2D other)
  {
      if(other.gameObject.tag=="Hurtbox")
      {
          other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damageToDeal);
          rigidBody.AddForce(transform.up*bounceForce, ForceMode2D.Impulse);
      }
  }
}
