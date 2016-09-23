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
		GetComponent<AudioSource>().volume = 0.04f;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			if (Input.GetMouseButtonDown(0)){
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (3f, 8f);
			}
			this.transform.position = paddle.transform.position + paddleToBallVector;
		}
	}
	
	void OnCollisionEnter2D () {
		if (hasStarted){
			GetComponent<AudioSource>().Play();
		}
		if (this.GetComponent<Rigidbody2D>().velocity.x > -1 && this.GetComponent<Rigidbody2D>().velocity.x < 1) {
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 8f);
		}
		
		if (this.GetComponent<Rigidbody2D>().velocity.y > -3 && this.GetComponent<Rigidbody2D>().velocity.y < 3) {
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 8f);
		}
	}
	
	public void AutoStart () {
		hasStarted = true;
		this.GetComponent<Rigidbody2D>().velocity = new Vector2 (3f, 8f);
	}
}
