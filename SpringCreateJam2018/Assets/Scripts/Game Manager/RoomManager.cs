using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour {

    /*
     *  Missing function that implements the buttons to the panel
     *  in a grid formation.
     */
    private RoomManager instance;
    public Rooms[] rooms;
    private Fade fade;

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


            for (int i = 0; i < rooms.Length; i++){
                Debug.Log(rooms[i].name);
                Debug.Log(rooms[i].isDead);
            }
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
                Debug.Log(rooms[personNum].name);
                Debug.Log(rooms[personNum].isDead);
            }
            else{
                Debug.Log("This one is already dead, pick another one");
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
