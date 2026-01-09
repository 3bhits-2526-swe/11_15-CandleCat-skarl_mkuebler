using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void SelectEasy() {
        DifficultySettings.CurrentDropRate = 0.4f;
        StartGame();
    }

    public void SelectMedium() {
        DifficultySettings.CurrentDropRate = 0.8f;
        StartGame();
    }

    public void SelectHard() {
        DifficultySettings.CurrentDropRate = 1.5f;
        StartGame();
    }

    public void StartGame() {
        SceneManager.LoadScene("GameScene");
    }
}