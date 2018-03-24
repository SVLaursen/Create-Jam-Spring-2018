using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour {

    private RoomManager instance;
    public Rooms[] rooms;
    private Fade fade;

    public int days;
    public int questions;

    public Image[] gridImg;
    public Image[] aliveImg;
    public Image[] deadImg;

    private bool lobbyRoom;

	private void Awake()
	{
        if(instance != null){
            Destroy(this.gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);
            fade = GetComponent<Fade>();


        }
	}

	private void Update()
	{
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            CheckArea();
            DrawGrid();
        }
	}

    public void GridButton(int personNum){
        if(lobbyRoom){
            if (!rooms[personNum].isDead)
            {
                fade.FadeTo(rooms[personNum].roomName);
                Debug.Log("Is there an error here?");
            }
            else
            {
                Debug.Log("Dead, can't go there");
                Debug.Log(lobbyRoom);
            }
        }
        else if(!lobbyRoom && SceneManager.GetActiveScene().name == "Choose"){
            if(!rooms[personNum].isDead){
                rooms[personNum].isDead = true;
                //TODO: After one has been checked go to day switch screen!
            }
            else{
                //TODO: Initiate dialogue that says it can't be chosen.
            }
        }

    }

    public void GoBack(){
        fade.FadeTo("Bellboy");
    }

    private void DrawGrid(){

        for (int i = 0; i < gridImg.Length; i++){
            if(gridImg[i] != null){
                if(!rooms[i].isDead){
                    gridImg[i].sprite = aliveImg[i].sprite;
                }
                else{
                    gridImg[i].sprite = deadImg[i].sprite;
                }
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

	[System.Serializable]
    public class Rooms{
        public string name;
        public bool isDead;
        public string roomName;
    }
}
