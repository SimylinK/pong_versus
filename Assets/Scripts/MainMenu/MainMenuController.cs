using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject gameModeMenu;
    public GameObject selectCharacterMenu;

    // Main menu

    public void gameMode()
    {
        mainMenu.SetActive(false);
        gameModeMenu.SetActive(true);
    }

    public void options() {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
 
    public void exitGame() {
        Application.Quit();
    }

    // Options

    public void backOption()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    // GameMode Selection

    public void fastPlay()
    {
        gameModeMenu.SetActive(false);
        selectCharacterMenu.SetActive(true);
    }

    public void draftMode()
    {
        gameModeMenu.SetActive(false);
        //selectCharacterMenu.SetActive(true);
    }

    public void backGameMode()
    {
        mainMenu.SetActive(true);
        gameModeMenu.SetActive(false);
    }

    // Select Character

    public void fighter()
    {
        StaticCharacters.character1 = createFighter.createFighter(CharacterSide.Left);
        StaticCharacters.character2 = createFighter.createFighter(CharacterSide.Right);

        SceneManager.LoadScene("GameScene");
    }

    public void backSelectCharacter()
    {
        mainMenu.SetActive(true);
        selectCharacterMenu.SetActive(false);
    }

}