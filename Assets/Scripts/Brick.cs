using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private int hits;
	private LevelManager levelManager;
	private bool isBreakable;
	
	public static int breakableCount = 0;
	
	public Sprite[] hitSprites;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			print("breakablecount ++");
			breakableCount++;
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		hits = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D () {
	    if (isBreakable) {
			handleHits ();
	    }
  	}
  	
  	void handleHits () {
		hits++;
		int maxHits = hitSprites.Length + 1;
		if (hits >= maxHits){
			breakableCount--;
			Destroy(gameObject);
			print ("breakable count is..");
			print(breakableCount);
			levelManager.BrickDestroyed();
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
  	void Win() {
  		levelManager.LoadNextLevel();
  	}
}
