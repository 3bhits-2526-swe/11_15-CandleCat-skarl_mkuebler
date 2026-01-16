using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    void Start()
    {
        DifficultySettings.CurrentDropRate = 0.4f;
        DifficultySettings.ModeName = "Easy";
    }

    public void SelectEasy() {
        DifficultySettings.CurrentDropRate = 0.4f;
        DifficultySettings.ModeName = "Easy";
        Debug.Log("Schwierigkeit auf EASY gesetzt.");
    }

    public void SelectMedium() {
        DifficultySettings.CurrentDropRate = 0.8f;
        DifficultySettings.ModeName = "Medium";
        Debug.Log("Schwierigkeit auf MEDIUM gesetzt.");
    }

    public void SelectHard() {
        DifficultySettings.CurrentDropRate = 1.5f;
        DifficultySettings.ModeName = "Hard";
        Debug.Log("Schwierigkeit auf HARD gesetzt.");
    }

    public void StartGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScreen");
    }
}