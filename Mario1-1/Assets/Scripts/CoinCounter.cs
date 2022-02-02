using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public int coinCount;
    AudioSource audioS;
    public AudioClip coin;
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        audioS.clip=coin;
    }
    public void AddCoin()
    {
        audioS.Play();
       coinCount+=1; 
       if(coinCount>99)
       {
           coinCount-=100;
       }
    }
}
