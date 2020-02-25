using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardInformations : MonoBehaviour {

	public CharacterCreationSystem system;

	[SerializeField] TextMeshProUGUI titleText;
	[SerializeField] TextMeshProUGUI descriptionText;
	public GameObject addCardButton;
	public GameObject inputButton;
	public Text inputButtonText;

	public Card card;

	// Use this for initialization
	void Start () {
		system = GameObject.Find("CharacterCreationSystem").GetComponent<CharacterCreationSystem>();
	}

	public void setTitle(string title) {
		titleText.text = title;
	}

	public void setDescription(string description) {
		descriptionText.text = description;
	}

	public void setCard(Card card){
		this.card = card;
	}

	public void addCard() {
		system.addCard(gameObject);
		addCardButton.SetActive(false);
	}

	public void displayInput() {
		if(card.action.hasInput())
			inputButton.SetActive(true);
	}

	public void setInput() {
		Debug.Log("SetInput");

		if(!waitingForKey)
            StartCoroutine(AssignKey());
		
	}


    private Event keyEvent;
	private KeyCode newKey;
	private bool waitingForKey;

	void OnGUI()
    {
        /*keyEvent dictates what key our user presses
         * bt using Event.current to detect the current
         * event
         */
        keyEvent = Event.current;

        //Executes if a button gets pressed and
        //the user presses a key
        if(keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode; //Assigns newKey to the key user presses
            waitingForKey = false;
        }
    }


	IEnumerator WaitForKey()

    {
        while(!keyEvent.isKey)
            yield return null;

    }


	public IEnumerator AssignKey()

    {
        waitingForKey = true;

        yield return WaitForKey(); //Executes endlessly until user presses a key
 
		card.action.setInput(newKey);
		inputButtonText.text = newKey.ToString();
        
        yield return null;
    }
}
