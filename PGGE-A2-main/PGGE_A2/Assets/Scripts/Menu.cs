using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Variables for the different button click sound effects.
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
        // Play Single Player button sound effect.
        buttonSinglePlayerAudioSource.Play();
    }

    public void OnClickMultiPlayer()
    {
        //Debug.Log("Loading multiplayer game");
        SceneManager.LoadScene("Multiplayer_Launcher");
        // Play Multi Player button sound effect.
        buttonMultiPlayerAudioSource.Play();
    }
    public void OnClickBackToMenu()
    {
        //Debug.Log("Going back to the menu...");
        SceneManager.LoadScene("Menu");
        // Play Back button sound effect.
        buttonBackAudioSource.Play();
    }

    public void OnClickJoinServer()
    {
        // Play Join button sound effect.
        buttonJoinAudioSource.Play();
    }

}
