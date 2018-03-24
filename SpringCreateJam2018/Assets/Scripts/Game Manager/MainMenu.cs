using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Fade fade;

    public Canvas mainCanvas;
    public Canvas tutorialCanvas;

    public void PlayGame(){
        fade.FadeTo("Bellboy");
    }

    public void HowTo(){
        if(mainCanvas.enabled){
            tutorialCanvas.enabled = true;
            mainCanvas.enabled = false;
        }
        else{
            tutorialCanvas.enabled = false;
            mainCanvas.enabled = true;
        }
    }

	public void QuitGame()
	{
        Application.Quit();
	}


}
