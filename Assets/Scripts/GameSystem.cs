using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSystem : MonoBehaviour {

    // prefabs
	public GameObject player;
    public GameObject ballPrefab;
    public GameObject lifeBarsPrefab;

    // display informations
    public GameObject scoreDisplay;
    public GameObject endDisplay;
    [SerializeField] TextMeshProUGUI leftSideText;
    [SerializeField] TextMeshProUGUI rightSideText;
    [SerializeField] TextMeshProUGUI endDisplayText;

    // private variables
    private int scoreLeft = 0;
    private int scoreRight = 0;
    private GameObject ball;
    private GameObject lifeBars;

    // Use this for initialization
    void Start () {
		//Creating Player 1
		GameObject player1 = Instantiate(player, new Vector3(-5f, 0.5f, 0), Quaternion.identity);
		Character char1 = player1.GetComponent<Character>();
		StaticCharacters.setAttributes(StaticCharacters.character1, char1);
		char1.init();

		//Creating Player 2
		GameObject player2 = Instantiate(player, new Vector3(5f, 0.5f, 0), Quaternion.identity);
		Character char2 = player2.GetComponent<Character>();
		StaticCharacters.setAttributes(StaticCharacters.character2, char2);
		char2.init();

        //init score
        leftSideText.text = scoreLeft.ToString();
        rightSideText.text = scoreRight.ToString();
        scoreDisplay.SetActive(true);

        //init
        initLifeAndBall();

        //TEST PURPOSE

        char2.leftKey = KeyCode.A;
        char2.rightKey = KeyCode.D;
        char2.upKey = KeyCode.W;
        char2.downKey = KeyCode.S;
        //ActionPress tmp1 = (ActionPress) char2.action1;
        //ActionPress tmp2 = (ActionPress) char2.action2;
        //ActionPressRelease tmp3 = (ActionPressRelease) char2.action3;
        //tmp1.actionKey = KeyCode.H;
        //tmp2.actionKey = KeyCode.J;
        //tmp3.actionKey = KeyCode.K;


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void score(CharacterSide side)
    {
        if (side == CharacterSide.Left)
        {
            scoreLeft++;
            leftSideText.text = scoreLeft.ToString();
        } else
        {
            scoreRight++;
            rightSideText.text = scoreRight.ToString();
        }
        initLifeAndBall();
    }
    
    public void endGame(CharacterSide winner)
    {
        string text = "Le match est finis, le gagnant est : ";
        if (winner == CharacterSide.Left)
        {
            text += "Joueur 1.";
        } else
        {
            text += "Joueur 2.";
        }

        endDisplayText.text = text;
        endDisplay.SetActive(true);
        scoreDisplay.SetActive(false);
    }

    private void initLifeAndBall() {
        if (ball != null) {
            Destroy(ball);
        }
        ball = Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        if (lifeBars != null) {
            Destroy(lifeBars);
        }
        lifeBars = Instantiate(lifeBarsPrefab, new Vector3(0, 0, 0), Quaternion.identity);

    }
}
