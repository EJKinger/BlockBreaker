using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float mousePosInBlocks = Mathf.Clamp((Input.mousePosition.x / Screen.width * 16), 0.5f, 15.5f);
		
		this.transform.position = new Vector3(mousePosInBlocks, this.transform.position.y, 1f);
	}
}
