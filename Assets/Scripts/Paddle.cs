using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool AutoPlay = false;
	private Ball ball;
	// Update is called once per frame
	
	void Start () {
		ball = GameObject.FindObjectsOfType<Ball>()[0];
		if (AutoPlay){
			ball.AutoStart();
		}
	}
	void Update () {
		
		if (!AutoPlay) {
			MoveWithMouse();
		} else {
			MoveAutomatically();
		}
		
	}
	
	void MoveWithMouse () {
		float mousePosInBlocks = Mathf.Clamp((Input.mousePosition.x / Screen.width * 16), 0.5f, 15.5f);
		this.transform.position = new Vector3(mousePosInBlocks, this.transform.position.y, 1f);
	}
	
	void MoveAutomatically () {
		this.transform.position = new Vector3(ball.transform.position.x, this.transform.position.y, 1f);
	}
}
