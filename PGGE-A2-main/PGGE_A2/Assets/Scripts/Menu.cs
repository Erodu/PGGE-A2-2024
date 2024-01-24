using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource buttonMultiPlayerAudioSource;
    public AudioSource buttonSinglePlayerAudioSource;
    public AudioSource buttonBackAudioSource;
    public AudioSource buttonJoinAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickSinglePlayer()
    {
        //Debug.Log("Loading singleplayer game");
        SceneManager.LoadScene("SinglePlayer");
        buttonSinglePlayerAudioSource.Play();
    }

    public void OnClickMultiPlayer()
    {
        //Debug.Log("Loading multiplayer game");
        SceneManager.LoadScene("Multiplayer_Launcher");
        buttonMultiPlayerAudioSource.Play();
    }
    public void OnClickBackToMenu()
    {
        //Debug.Log("Going back to the menu...");
        SceneManager.LoadScene("Menu");
        buttonBackAudioSource.Play();
    }

    public void OnClickJoinServer()
    {
        buttonJoinAudioSource.Play();
    }

}
