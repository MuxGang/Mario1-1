using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlockScript : MonoBehaviour
{
    public float bounceHeight=.5f;
    public float bounceSpeed=4f;
    private Vector2 originalPosition;
    private bool canBounce=true;
   public int enemyHP;
    private int currentHP;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition=transform.localPosition;
        currentHP=enemyHP;
    }
    public void QuestionBlockBounce()
    {
        if(canBounce)
        {
            canBounce=false;
            StartCoroutine(Bounce());
        }
    }

    // Update is called once per frame
    void Update()
    {
         if(currentHP<=0)
        {
            Destroy(transform.parent.gameObject);
        }
    }


    public void TakeDamage(int damage)
    {
        currentHP-=damage;
    }
    public IEnumerator Bounce()
    {
        while(true)
        {
            transform.localPosition=new Vector2 (transform.localPosition.x,transform.localPosition.y+bounceSpeed*Time.deltaTime);
            if(transform.localPosition.y>=originalPosition.y+bounceHeight)
            break;
            yield return null;
        }
        while(true)
        {
            transform.localPosition=new Vector2(transform.localPosition.x, transform.localPosition.y-bounceSpeed*Time.deltaTime);
            if(transform.localPosition.y<=originalPosition.y)
            {
                transform.localPosition=originalPosition;
                break;
            }
            yield return null;
        }
    }
}
