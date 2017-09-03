using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Manages the menu buttons
public class MenuManager : MonoBehaviour
{
    // Called by Button1 : Activates 1 Player game mode and loads the game scene
    public void Load1Player()
    {
        GameParameters._TwoPlayers = false;
        SceneManager.LoadScene("Game");
    }

    // Called by Button2 : Activates 2 Player game mode and loads the game scene
    public void Load2Players()
    {
        GameParameters._TwoPlayers = true;
        SceneManager.LoadScene("Game");
    }
}
