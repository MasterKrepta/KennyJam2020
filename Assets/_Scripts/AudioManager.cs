using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public GameObject howtoScreen;
    private static AudioManager instance = null;
    public static AudioManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void StartGameplay()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadHowTo()
    {
        howtoScreen.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
