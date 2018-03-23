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

    public Rooms[] rooms;

    private bool lobbyRoom;

	private void Update()
	{
        CheckArea();
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
