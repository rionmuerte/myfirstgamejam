using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void LoadIntroduction() => SceneManager.LoadScene("Introduction");

}
