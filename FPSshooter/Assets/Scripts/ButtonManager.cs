using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(2);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void SettingsButton() 
    {
        SceneManager.LoadScene(6);


    }
    public void DeadScene() 
    {
        SceneManager.LoadScene(4);
    }
    public void QuitButton() 
    {
        Application.Quit();
    }
    
}
