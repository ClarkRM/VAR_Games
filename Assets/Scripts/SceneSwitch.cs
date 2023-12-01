using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void Rules()
    {
        SceneManager.LoadScene("Rules");
    }
    public void Pause()
    {
        SceneManager.LoadScene("Pause");
    }public void Win()
    {
        SceneManager.LoadScene("Win");
    }public void Lose()
    {
        SceneManager.LoadScene("Lose");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

