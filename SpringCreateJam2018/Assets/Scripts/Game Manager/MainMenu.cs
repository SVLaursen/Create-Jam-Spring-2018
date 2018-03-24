using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Fade fade;

    public Canvas mainCanvas;
    public Canvas tutorialCanvas;

    GameObject audioObj;
    AudioManager audio;

	private void Start()
	{
        audioObj = GameObject.Find("AudioSystem");
        audio = audioObj.GetComponent<AudioManager>();
	}

	public void PlayGame(){
        audio.PlaySound2D("Door");
        fade.FadeTo("Bellboy");
    }

    public void HowTo(){
        audio.PlaySound2D("Click");
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
        audio.PlaySound2D("Click");
        Application.Quit();
	}


}
