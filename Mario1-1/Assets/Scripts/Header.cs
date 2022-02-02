using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Header : MonoBehaviour
{
        public int damageToDeal;

    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody=transform.parent.GetComponent<Rigidbody2D>();
    }

   private void OnTriggerEnter2D(Collider2D other)
  {
      if(other.gameObject.tag=="MysteryBox")
      {
          other.gameObject.GetComponent<QuestionBlockScript>().TakeDamage(damageToDeal);
        // rigidBody.AddForce(transform.up*bounceForce, ForceMode2D.Impulse);
        
      }
  }
}
