using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayBtn : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        ScoreSystem.ResetScore();
        ScoreSystem.savedGoalToWin.gameObject.SetActive(true);
    }
}
