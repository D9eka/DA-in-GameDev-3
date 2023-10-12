using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame(int levelIndex){
        LevelController.ChangeLevelNum(levelIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + levelIndex);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
