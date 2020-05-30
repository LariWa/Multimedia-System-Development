using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class MenuManager : MonoBehaviour
{
    public GameObject PauseMenu;
    static bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            setPause();


        }
    }

    public void OnRestartButtonClicked()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        setPause();

    }
    public void OnReturnButtonClicked()
    {
        setPause();

    }  
    private void setPause()
    {
        Time.timeScale = Convert.ToInt32(paused);
        paused = !paused;
        PauseMenu.SetActive(paused);


    }
}
