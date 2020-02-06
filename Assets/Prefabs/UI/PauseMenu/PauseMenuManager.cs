using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour {

    public int mainMenuIndex;

    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void MainMenuPress()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenuIndex);
    }

}
