using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	
	public static bool instantiated = false;
	// Use this for initialization
	void Start () {
		AudioSource audio = GetComponent<AudioSource>();
		GameObject.DontDestroyOnLoad(gameObject);
		if (!instantiated){
			audio.Play();
			instantiated = true;
		} else {
			GameObject.Destroy (gameObject);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
