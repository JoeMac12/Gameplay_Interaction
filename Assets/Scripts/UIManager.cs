using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gamePlay;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject winMenu;
    public GameObject loseMenu;

    public void UIMainMenu()
    {
        mainMenu.SetActive(true);
        gamePlay.SetActive(false);
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        winMenu.SetActive(false);
        loseMenu.SetActive(false);
    }

    public void UIGamePlay()
    {
        mainMenu.SetActive(false);
        gamePlay.SetActive(true);
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        winMenu.SetActive(false);
        loseMenu.SetActive(false);
    }

    public void UIPauseMenu()
    {
        mainMenu.SetActive(false);
        gamePlay.SetActive(false);
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
        winMenu.SetActive(false);
        loseMenu.SetActive(false);
    }

    public void UIOptionsMenu()
    {
        mainMenu.SetActive(false);
        gamePlay.SetActive(false);
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
        winMenu.SetActive(false);
        loseMenu.SetActive(false);
    }

    public void UIWinMenu()
    {
        mainMenu.SetActive(false);
        gamePlay.SetActive(false);
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        winMenu.SetActive(true);
        loseMenu.SetActive(false);
    }

    public void UILoseMenu()
    {
        mainMenu.SetActive(false);
        gamePlay.SetActive(false);
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        winMenu.SetActive(false);
        loseMenu.SetActive(true);
    }
}
