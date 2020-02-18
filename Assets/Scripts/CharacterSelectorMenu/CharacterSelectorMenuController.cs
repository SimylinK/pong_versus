using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectorMenuController : MonoBehaviour {

    public CreateFighter createFighter;

	public void fighter() {
        StaticCharacters.character1 = createFighter.createFighter(CharacterSide.Left);
        StaticCharacters.character2 = createFighter.createFighter(CharacterSide.Right);

        SceneManager.LoadScene("GameScene");
    }

    public void back() {
        SceneManager.LoadScene("MainMenu");
    }
}
