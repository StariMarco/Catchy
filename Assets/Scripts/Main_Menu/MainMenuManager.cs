using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    public GameObject bgDecorations;
    public GameObject title;
    public ButtonsAnimations buttons;
    public float waitTime;

	public void StartGame()
    {
        //exit animations
        bgDecorations.GetComponent<PlayAnimation>().RunPlayAnimation();
        title.GetComponent<TitleAnimations>().RunExitAnimation();
        buttons.RunExitAnimation();
        //loade scene
        StartCoroutine(LoadTargetScene(1));
    }

    IEnumerator LoadTargetScene(int n)
    {
        //wait for x seconds
        yield return new WaitForSeconds(waitTime);
        //load scene
        SceneManager.LoadScene(n);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
