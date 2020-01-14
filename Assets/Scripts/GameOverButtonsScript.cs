using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverButtonsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        FindObjectOfType<GameHandler>().Restart();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
