using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    RoomManager roomManager;
    Fade fade;
    EndingManager endingManager;

    public static GameManager instance;

	private void Awake()
	{
        if(instance != null){
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);

            roomManager = GetComponent<RoomManager>();
            fade = GetComponent<Fade>();
            endingManager = GetComponent<EndingManager>();

        }
	}

	void Update () {
		
	}
}
