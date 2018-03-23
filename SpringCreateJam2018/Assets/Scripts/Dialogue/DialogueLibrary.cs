using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLibrary : MonoBehaviour {

    public string[] dialog;

    private bool[] spoken;

    private void Awake()
    {
        spoken = new bool[dialog.Length];
	}

	public string ChooseLine(int diaChoice){
        if(spoken[diaChoice]){
            spoken[diaChoice] = false;
            return dialog[diaChoice];
        }
        else{
            print("This has already been asked");
            return null;
        }
    }
}
