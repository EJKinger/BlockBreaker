using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	private int hits;
	private LevelManager levelManager;
	
	public Sprite[] hitSprites;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		hits = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D () {
		hits++;
		if (hits >= maxHits){
			Destroy(gameObject);
		} else {
			changeSprite ();
		}

  	}
  	
  	void changeSprite () {
  	  int spriteIndex = hits - 1;
  	  this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
  	}
  	
  	// TODO Remove this method when actual win conditions are completed
  	void simulateWin() {
  		levelManager.LoadNextLevel();
  	}
}
