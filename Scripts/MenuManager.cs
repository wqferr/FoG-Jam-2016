using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public void QuitGame(){

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

    // Read level from save file?
    // Read save file to unlock levels in a level select screen?
    public void LoadLevelByIndex(int level){
        SceneManager.LoadScene(level);
    }
}
