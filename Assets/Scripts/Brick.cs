using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

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
	    bool isBreakable = (this.tag == "Breakable");
	    if (isBreakable) {
			handleHits ();
	    }
  	}
  	
  	void handleHits () {
		hits++;
		int maxHits = hitSprites.Length + 1;
		if (hits >= maxHits){
			Destroy(gameObject);
		} else {
			changeSprite ();
        }
  	}
  	
  	void changeSprite () {
  	  int spriteIndex = hits - 1;
  	  if (hitSprites[spriteIndex]){
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];  	  
  	  }
  	}
  	
  	// TODO Remove this method when actual win conditions are completed
  	void simulateWin() {
  		levelManager.LoadNextLevel();
  	}
}
