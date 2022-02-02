using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinCounter coinCount;
    // Start is called before the first frame update
   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.gameObject.tag=="Player")
       {
           coinCount.AddCoin();
           Destroy(this.gameObject);
       }
   }
}
