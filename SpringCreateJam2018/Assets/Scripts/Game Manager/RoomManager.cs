﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour {

    public static RoomManager instance;
    public Rooms[] rooms;
    public Canvas gridPanel;
    public Canvas backCanvas;

    GameObject audioObj;
    AudioManager audio;

    private Fade fade;

    public int days;
    public int questions;
    public bool newDay;

    public Image[] gridImg;
    public Image[] aliveImg;
    public Image[] deadImg;

    private bool lobbyRoom;

	private void Awake()
	{
        if(instance != null){
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);
            fade = GetComponent<Fade>();
            audioObj = GameObject.Find("AudioSystem");
            audio = audioObj.GetComponent<AudioManager>();
        }
         
	}

	private void Update()
	{
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            CheckArea(); //Checks which one of the grid rooms it is, if it is one.
            DrawGrid();
            StartNewDay(); //Loop that starts to restart the game.
        }


	}

    public void GridButton(int personNum){
        if(lobbyRoom){
            if (!rooms[personNum].isDead)
            {
                audio.PlaySound2D("Door"); //Door sound
                fade.FadeTo(rooms[personNum].roomName);
            }
            else{
                audio.PlaySound2D("Locked");
            }
        }
        else if(!lobbyRoom && SceneManager.GetActiveScene().name == "Choose"){
            if(!rooms[personNum].isDead){
                rooms[personNum].isDead = true;
                audio.PlaySound2D("Death Scream"); //Door sound
                if(days >= 8){
                    fade.FadeTo("EndScene");
                }
                else{
                    newDay = true;
                }

            }
            else{
                audio.PlaySound2D("Denied");
            }
        }

    }

    public void GoBack(){
        audio.PlaySound2D("Click"); //Input click sound
        fade.FadeTo("Bellboy");
    }

    private void DrawGrid(){
        if (SceneManager.GetActiveScene().name == "Bellboy" || SceneManager.GetActiveScene().name == "Choose")
        {
            gridPanel.enabled = true;
            backCanvas.enabled = false; 

            for (int i = 0; i < gridImg.Length; i++)
            {
                if (gridImg[i] != null)
                {
                    if (!rooms[i].isDead)
                    {
                        gridImg[i].sprite = aliveImg[i].sprite;
                    }
                    else
                    {
                        gridImg[i].sprite = deadImg[i].sprite;
                    }
                }
            }
        }
        else{
            gridPanel.enabled = false;

            if(SceneManager.GetActiveScene().name != "MainMenu" || SceneManager.GetActiveScene().name != "EndScene"){
                backCanvas.enabled = true;
            }
        }
    }

    private void CheckArea(){
        if (SceneManager.GetActiveScene().name == "Bellboy")
        {
            lobbyRoom = true;
        }
        else
        {
            lobbyRoom = false;
        }
    }

    private void StartNewDay(){
        if(newDay){
            days++;

            if(days >= 8){
                fade.FadeTo("EndScene");
                newDay = false; //breaks the loop
            }
            else{
                questions = 10 - days;
                fade.FadeTo("Bellboy");
                newDay = false; //Breaks the loop
            }
        }

        if(!newDay && questions < 0 && SceneManager.GetActiveScene().name != "Choose" && days != 8){
            fade.FadeTo("Choose");
        }
    }

	[System.Serializable]
    public class Rooms{
        public string name;
        public bool isDead;
        public string roomName;
    }
}
