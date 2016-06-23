using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			if (Input.GetMouseButtonDown(0)){
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2 (3f, 8f);
			}
			this.transform.position = paddle.transform.position + paddleToBallVector;
		}
	}
	
	void OnCollisionEnter2D () {
		if (this.rigidbody2D.velocity.x > -1 && this.rigidbody2D.velocity.x < 1) {
			this.rigidbody2D.velocity = new Vector2(3f, this.rigidbody2D.velocity.y);
		}
		
		if (this.rigidbody2D.velocity.y > -3 && this.rigidbody2D.velocity.y < 3) {
			this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x, 8f);
		}
	}
}
