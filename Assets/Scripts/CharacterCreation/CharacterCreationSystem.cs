using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class CharacterCreationSystem : MonoBehaviour {

	public GenerateRandom generator;
	public GameObject cardPrefab;
	public GameObject cardDisplay;
	public GameObject player1Display;
	public GameObject player2Display;
	[SerializeField] TextMeshProUGUI information;
	public GameObject launchGameButton;

	private List<GameObject> cards = new List<GameObject>();
	private CharacterSide sideChosing;

	private List<GameObject> cardsPlayer1 = new List<GameObject>();
	private List<GameObject> cardsPlayer2 = new List<GameObject>();

	public Sprite normal;
    public Sprite recovery;
    public Sprite ko;

	private int counterCard = 0;

	// Use this for initialization
	void Start () {
		generator.generateRandom();
		
		foreach (Card card in generator.getCards()) {
			GameObject cardCreated = GameObject.Instantiate(cardPrefab, new Vector2(0,0), Quaternion.identity);
			cardCreated.transform.parent = cardDisplay.transform;
			CardInformations modifier = cardCreated.GetComponent<CardInformations>();
			modifier.setTitle(card.title);
			modifier.setDescription(card.description);
			modifier.setCard(card);
			cards.Add(cardCreated);
		}
		sideChosing = CharacterSide.Left;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addCard(GameObject card) {
		CardInformations modifier = card.GetComponent<CardInformations>();
		modifier.displayInput();
		modifier.card.generator.addPrefab(sideChosing, modifier.card.action);
		modifier.card.action.setSide(sideChosing);
		
		GameObject playerDisplay = null;
		if (sideChosing == CharacterSide.Right) {
			playerDisplay = player2Display;
			sideChosing = CharacterSide.Left;
			cardsPlayer2.Add(card);
			information.text = "Joueur 1 choisit une carte";
		}
		else 
		{
			playerDisplay = player1Display;
			sideChosing = CharacterSide.Right;
			cardsPlayer1.Add(card);
			information.text = "Joueur 2 choisit une carte";
		}
		card.transform.parent = playerDisplay.transform;

		counterCard++;
		if (counterCard == 10) {
			information.text = "";
			launchGameButton.SetActive(true);
		}
	}

	public void launchGame() {

        StaticCharacters.character1 = this.createCharacter(CharacterSide.Left);
        StaticCharacters.character2 = this.createCharacter(CharacterSide.Right);

        SceneManager.LoadScene("GameScene");

	}

	private CharacterAttributes createCharacter(CharacterSide side) {

		List<GameObject> cards = cardsPlayer1;
		if (side == CharacterSide.Right) {
			cards = cardsPlayer2;
		}

		List<ActionPlayer> actions = new List<ActionPlayer>();

		foreach (GameObject card in cards) {
			CardInformations info = card.GetComponent<CardInformations>();
			ActionPlayer action = info.card.action;
			actions.Add(action);
		}
		CharacterAttributes character = new CharacterAttributes(side, 0.2f, actions, normal, recovery, ko);
		return character;

	}

	private void setMapping() {
		foreach (GameObject card in cardsPlayer1) {
			CardInformations info = card.GetComponent<CardInformations>();
			ActionPlayer action = info.card.action;

		
		}
	}
}
