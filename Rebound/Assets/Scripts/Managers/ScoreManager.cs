using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    // Score Manager

    public TMP_Text curScoreTxt;

    private float lastPlayerYPos = -12f;
    private float DEFAULT_PLAYER_POSITION = -12f;

    private int curScore = 0;

    public void UpdateScore(float playerY)
    {
        if (playerY > lastPlayerYPos)
        {
            curScore++;
            curScoreTxt.text = curScore.ToString();
            lastPlayerYPos = playerY;
        }
    }

    public void ResetScoreManager()
    {
        lastPlayerYPos = DEFAULT_PLAYER_POSITION;
        SetGameOverPalet(curScore);
        curScore = 0;
        curScoreTxt.text = curScore.ToString();
    }

    // Highscore Manager

    public SaveManager saveManager;

    public TMP_Text lastScoreTxt;
    public TMP_Text highscoreTxt;

    private void SetGameOverPalet(int lastScore)
    {
        lastScoreTxt.text = lastScore.ToString();
        if (isHighscoreValid(lastScore))
            highscoreTxt.text = lastScore.ToString();
    }

    private bool isHighscoreValid(int lastScore)
    {
        if (lastScore > saveManager.state.highscore)
        {
            saveManager.state.highscore = lastScore;
            saveManager.Save();
            return true;
        }

        return false;
    }

}
