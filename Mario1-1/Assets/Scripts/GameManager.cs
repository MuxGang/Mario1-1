using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerScript player;
    private Vector2 playerStart;
    public GameObject victoryScreen;
    public GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        playerStart=player.transform.position;
    }

    // Update is called once per frame
    public void Victory()
    {
        victoryScreen.SetActive(true);
        player.gameObject.SetActive(false);
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        player.gameObject.SetActive(false);
    }
    public void Reset()
    {
        victoryScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        player.gameObject.SetActive(true);
        player.transform.position=playerStart;
    }
}
