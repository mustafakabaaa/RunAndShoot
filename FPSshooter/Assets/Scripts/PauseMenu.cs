using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject stopCanvas;

    private bool gameStopped=false;
    // Start is called before the first frame update
    void Start()
    {
        stopCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameStopped)
            {
                ContinueFNC();

            }
            else
            {
                StopedFNC();
            }
        }
        
    }
    void StopedFNC()
    {
        Time.timeScale = 0f;

        stopCanvas.SetActive(true);

        gameStopped = true;

        Cursor.visible = true;
        Cursor.lockState= CursorLockMode.None;
    }
    void ContinueFNC()
    {
        Time.timeScale=1f;

        stopCanvas.SetActive(false );

        gameStopped = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
