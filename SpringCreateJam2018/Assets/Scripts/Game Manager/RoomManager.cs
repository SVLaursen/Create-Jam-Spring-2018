using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour {

    public Rooms[] rooms;

	private void Update()
	{
        for (int i = 0; i < rooms.Length; i++)
        {
            Debug.Log(rooms[i].name);
            Debug.Log(rooms[i].isDead);
            Debug.Log(rooms[i].roomName);
        }
	}



	[System.Serializable]
    public class Rooms{
        public string name;
        public bool isDead;
        public string roomName;
    }
}
