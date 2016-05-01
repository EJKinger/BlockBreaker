using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Paddle paddle;
	
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;

	// Use this for initialization
	void Start () {
		paddleToBallVector = this.transform.position - paddle.transform.position;
		print (paddleToBallVector);
	}
	
	// Update is called once per frame
	void Update () {		
		if (!hasStarted) {
			if (Input.GetMouseButtonDown(0)){
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2 (0f, 20f);
			}
			this.transform.position = paddle.transform.position + paddleToBallVector;
		}
	}
}
