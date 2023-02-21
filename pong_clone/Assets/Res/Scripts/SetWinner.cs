using UnityEngine;
using TMPro;

public class SetWinner : MonoBehaviour
{
    [SerializeField]
    GameObject placecholder;


   static TextMeshProUGUI winnerPlayerName;

    private void Start()
    {
        winnerPlayerName = this.placecholder.GetComponent<TextMeshProUGUI>();
        SetWinner.SetWinnerName();
    }

    public static void SetWinnerName()
    {
        if(ScoreSystem.player1Score >= ScoreSystem.savedGoalToWin.goalToWin)
        {
           winnerPlayerName.text = "Player 1 Win!";
        }else if (ScoreSystem.player2Score >= ScoreSystem.savedGoalToWin.goalToWin)
        {
           winnerPlayerName.text = "Player 2 Win!";
        }
        
    }


}
