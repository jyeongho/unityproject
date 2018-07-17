using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour {

    public AudioClip playclip;
    public AudioSource playsource;
    public AudioClip quitclip;
    public AudioSource quitsource;

    private void Start()
    {
        playsource.clip = playclip;
        quitsource.clip = quitclip;
    }

    public void PlayGame()
    {
        playsource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
    }

    public void QuitGame()
    {
        quitsource.Play();
        Application.Quit();

    }
}
