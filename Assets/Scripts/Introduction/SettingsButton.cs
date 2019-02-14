using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButton : MonoBehaviour
{
    // On Click function for SettingsButton
    public void LoadSettings() => SceneManager.LoadScene("Settings");
}
