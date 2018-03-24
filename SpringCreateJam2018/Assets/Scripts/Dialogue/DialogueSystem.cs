using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueSystem : MonoBehaviour {

    // Text variables 

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    public GameObject diaBox;
    public bool isMale;

    private Queue<string> sentences;

    GameObject obj;
    RoomManager roomManager;

    GameObject audioObj;
    AudioManager audio;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();

        obj = GameObject.Find("RoomManager");
        roomManager = obj.GetComponent<RoomManager>();

        audioObj = GameObject.Find("AudioSystem");
        audio = audioObj.GetComponent<AudioManager>();

	}
	
    public void StartDialogue(Dialogue dialogue)
    {
        diaBox.SetActive(true);

        if(isMale){
            audio.PlaySound2D("Male Voices");
        }
        else{
            audio.PlaySound2D("Female Voices");
        }

        nameText.text = dialogue.name;

        animator.SetBool("isOpen",true);

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }

        

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        if(roomManager.questions > 0){
            
            roomManager.questions -= 1;

            if (isMale)
            {
                audio.PlaySound2D("Male Voices");
            }
            else
            {
                audio.PlaySound2D("Female Voices");
            }

            string sentence = sentences.Dequeue();

            dialogueText.text = sentence;
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
        else if(roomManager.questions - 1 == -1){
            roomManager.questions = -1;
        }


    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;

        }
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);

    }

}
