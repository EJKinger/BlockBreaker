using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	void OnLevelWasLoaded(int level) {
		Brick.breakableCount = 0;
	}

	public void LoadLevel(string name){
		Debug.Log ("Level load requested for: " + name);
		Application.LoadLevel(name);
	}
	
	public void QuitRequest(string name){
		Debug.Log ("Quit requested for: " + name);
		Application.Quit();
	}
	
	public void LoadNextLevel () {
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed(){
		if (Brick.breakableCount <= 0){
			LoadNextLevel();
		}
	}
}
