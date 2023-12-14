using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    private string key = "Level";
    public void Level1()
    {
        if (PlayerPrefs.GetInt(key) != 1 && PlayerPrefs.GetInt(key) != 0)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt(key));
        }
        else
        {
            PlayerPrefs.SetInt(key, 1);
            SceneManager.LoadScene("Level1");
        }
    }
    public void Level2()
    {
        PlayerPrefs.SetInt(key, 3);
        SceneManager.LoadScene("Level2");
    }
     public void Before2()
    {
        SceneManager.LoadScene("Before2");
    }
     public void Hint2()
    {
        SceneManager.LoadScene("Hint2");
    }
    public void ScavengerHunt()
    {
        PlayerPrefs.SetInt(key, 4);
        SceneManager.LoadScene("ScavengerHunt");
    }
    public void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void About()
    {
        SceneManager.LoadScene("About");
    }
    public void Rules()
    {
        SceneManager.LoadScene("Rules");
    }
    public void Pause()
    {
        SceneManager.LoadScene("Pause");
    }
    public void Win()
    {
        PlayerPrefs.SetInt(key, 1);
        SceneManager.LoadScene("Win");
    }
    public void Lose()
    {
        PlayerPrefs.SetInt(key, 1);
        SceneManager.LoadScene("Lose");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

