using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class QuestionSaver : MonoBehaviour {

    public static QuestionSaver instance;
    public SavedQuestion[] savedQuestions;

    RoomManager roomManager;

	private void Awake()
	{
        if(instance != null){
            Destroy(gameObject);
        }
        else{
            instance = this;
            roomManager = GetComponent<RoomManager>();
        }
	}

	[System.Serializable]
    public class SavedQuestion{
        public string sceneName;
        public int currentQuestion;
    }
}
