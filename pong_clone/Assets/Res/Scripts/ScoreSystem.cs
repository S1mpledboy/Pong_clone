using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{

    [SerializeField]
    GameObject player1scoreTxt;

    [SerializeField]
    GameObject player2scoreTxt;

    [SerializeField]
    public int goalToWin;


    public static int player1Score, player2Score;

    TextMeshProUGUI uiTxtScorePlayer1;
    TextMeshProUGUI uiTxtScorePlayer2;

    public static ScoreSystem savedGoalToWin { get; private set; }
    
    
    private void Awake()
    {
        if (savedGoalToWin == null)
        {
            savedGoalToWin = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        ScoreSystem.savedGoalToWin.uiTxtScorePlayer1 = this.player1scoreTxt.GetComponent<TextMeshProUGUI>();
        ScoreSystem.savedGoalToWin.uiTxtScorePlayer2 = this.player2scoreTxt.GetComponent<TextMeshProUGUI>();
    }

    public void ChangeScore(string playerName)
    {
        switch (playerName)
        {
            case "player1":
                player1Score++;
                ScoreSystem.savedGoalToWin.SetScore();
                break;
            case "player2":
               player2Score++;
                ScoreSystem.savedGoalToWin.SetScore();
                break;
            default:
                Debug.LogError("Specify a Player in correct way( player1 for the left Player or player2 for the rigth Player )");
                break;
        }
    }

    private void SetScore()
    {
        ScoreSystem.savedGoalToWin.uiTxtScorePlayer1.text = player1Score.ToString();
        ScoreSystem.savedGoalToWin.uiTxtScorePlayer2.text = player2Score.ToString();

        ScoreSystem.savedGoalToWin.uiTxtScorePlayer1.ForceMeshUpdate(true);
        ScoreSystem.savedGoalToWin.uiTxtScorePlayer2.ForceMeshUpdate(true);
    }
    public void CheckWinConditions()
    {
        if (player1Score >= goalToWin || player2Score >= goalToWin)
        {
            SceneManager.LoadScene("GameOver");
            ScoreSystem.savedGoalToWin.gameObject.SetActive(false);

        }
    }
    public static void ResetScore()
    {
        ScoreSystem.player1Score = 0;
        ScoreSystem.player2Score = 0;
        ScoreSystem.savedGoalToWin.SetScore();
    }
}
