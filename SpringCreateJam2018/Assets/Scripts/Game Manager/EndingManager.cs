using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingManager : MonoBehaviour {

    public Stories[] stories;

    public Text[] nameText;
    public Text[] storyText;

    private int countdown;
    private int current = 0;

    GameObject obj;
    RoomManager roomManager;

	private void Awake () {
        obj = GameObject.Find("RoomManager");
        roomManager = obj.GetComponent<RoomManager>();

        for (int i = 0; i < 10; i++){

            if(roomManager.rooms[i].isDead == false){
                stories[i].isDead = roomManager.rooms[i].isDead;

            }
            if(!roomManager.rooms[i].isDead){
                Debug.Log("This is running");
                countdown++;

                nameText[current].text = stories[i].name;
                storyText[current].text = stories[i].endStory;

                if(countdown >= 3){
                    break;
                }

                current++;
            }
        }
	}

    public void ChangeToNext(){
        if(nameText[0].enabled){
            nameText[1].enabled = true;
            storyText[1].enabled = true;
            nameText[0].enabled = false;
            storyText[0].enabled = false;
        }
        else if(nameText[1].enabled){
            nameText[2].enabled = true;
            storyText[2].enabled = true;
            nameText[1].enabled = false;
            storyText[1].enabled = false;
        }
    }

    public void QuitGame(){
        Application.Quit();
    }

	[System.Serializable]
    public class Stories{
        public string name;
        public string endStory;
        public bool isDead;
    }
}
