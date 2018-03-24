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
    public Fade fade;

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
        if(!rooms[personNum].isDead){
            fade.FadeTo(rooms[personNum].roomName);
        }
        else{
            Debug.Log("Dead, can't go there");
        }
    }

    public void GoBack(){
        fade.FadeTo("Bellboy");
    }

    private void DrawGrid(){

        for (int i = 0; i < gridImg.Length; i++){
            if(gridImg[i] != null){
                if(!rooms[i].isDead){
                    gridImg[i] = aliveImg[i];
                }
                else{
                    gridImg[i] = deadImg[i];
                }
            }
        }
    }

    private void CheckArea(){
        if (SceneManager.GetActiveScene().name == "Bellboy" || SceneManager.GetActiveScene().name == "Choose")
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
