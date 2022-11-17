using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Text PlayerNameText;
    public void StartGame()
    {
        Debug.Log("in MenuScript.StartGame");

        DataManager.Instance.PlayerName = PlayerNameText.text;
        DataManager.Instance.GameScore = 0;

        SceneManager.LoadScene("main");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
		Application.Quit(); 
#endif
    }

}
