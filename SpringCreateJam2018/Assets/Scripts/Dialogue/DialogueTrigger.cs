using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;

    GameObject obj;
    RoomManager roomManager;

	private void Awake()
	{
        obj = GameObject.Find("RoomManager");
        roomManager = obj.GetComponent<RoomManager>();
	}

	public void TriggerDialogue()
    {
        FindObjectOfType<DialogueSystem>().StartDialogue(dialogue);
    }


}
