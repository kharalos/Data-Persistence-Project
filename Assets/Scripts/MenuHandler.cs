using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuHandler : MonoBehaviour
{
    public Button startButton;
    public InputField inputField;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void TypedNamer()
    {
        SavedDataHandler.Instance.playerName = inputField.text;
    }
    public void ChangeScene(int sceneID)
    {
        if (string.IsNullOrEmpty(SavedDataHandler.Instance.playerName))
            SavedDataHandler.Instance.playerName = "Unnamed Player";
        SceneManager.LoadScene(sceneID);
    }
    public void ExitApp()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
