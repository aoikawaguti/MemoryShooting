using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitletoinGame : MonoBehaviour {
    
    public void onStartButtonClicked()
    {
        //ボタンが押された際はゲーム内へ
        SceneManager.LoadScene("inGame");
        
    }
    public void onQuitButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif
    }

}
