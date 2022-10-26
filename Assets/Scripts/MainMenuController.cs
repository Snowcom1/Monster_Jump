using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void playGame()
    {
        int selectedCharacter = 
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);      
        
        GameManager.instance.CharIndex = selectedCharacter;
        Debug.Log("Selected character: " + selectedCharacter);
        if(selectedCharacter == 0)
        SceneManager.LoadScene("GameplayP1");
        else if(selectedCharacter == 1)
        SceneManager.LoadScene("GameplayP2");
    }
}
