using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour {
	public void ChangeToScene(string sceneName){
		SceneManager.LoadScene (sceneName, LoadSceneMode.Single);
	}
    
}
