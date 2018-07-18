using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour {

    public AudioClip MusicClip;
    public AudioSource MusicSource;
    public AudioClip MusicClip1;
    public AudioSource MusicSource1;

    private void Start()
    {
        MusicSource.clip = MusicClip;
        MusicSource1.clip = MusicClip1;
    }
    public void reload()
    {
        MusicSource.Play();
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void quit()
    {
        MusicSource1.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
