using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void BackToMain() => SceneManager.LoadScene("Main");

    public void BonusButton() => SceneManager.LoadScene("Bonus");

    public void QuitGame() => Application.Quit();
    
}
