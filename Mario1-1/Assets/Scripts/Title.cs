using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public string main;
    public void PlayGame()
    {
        SceneManager.LoadScene(main);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
