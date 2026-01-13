using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionMenu;
    public GameObject inventoryMenu;
    public GameObject skillMenu;
    public GameObject journalMenu;

    public GameObject corruptionbar;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !inventoryMenu.activeSelf && !skillMenu.activeSelf && !journalMenu.activeSelf)
        {
            if(!pauseMenu.activeSelf)
            {
                corruptionbar.SetActive(true);
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
                Cursor.visible = true;
            }
            else
            {   corruptionbar.SetActive(false);
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
                Cursor.visible =false;
            } 
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Cursor.visible = false;
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenOptionsPanel()
    {
        optionMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void CloseOptionsPanel()
    {
        optionMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
