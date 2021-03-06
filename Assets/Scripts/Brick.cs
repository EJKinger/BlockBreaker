﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	private int hits;
	private LevelManager levelManager;
	private bool isBreakable;
	
	public AudioClip crack;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	public Sprite[] hitSprites;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		hits = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D () {
		smoke.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
		smoke.GetComponent<ParticleSystem>().Play();
//		Instantiate (smoke, this.transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint(crack, transform.position, 0.04f);
	    if (isBreakable) {
			handleHits ();
	    }
  	}
  	
  	void handleHits () {
		hits++;
		int maxHits = hitSprites.Length + 1;
		if (hits >= maxHits){
			breakableCount--;
			print ("somke stuf");
//			Instantiate (smoke, this.transform.position, Quaternion.identity);
			smoke.GetComponent<ParticleSystem>().Play();
			print (gameObject.transform.position);
			Destroy(gameObject);
			levelManager.BrickDestroyed();
		} else {
			changeSprite ();
        }
  	}
  	
  	void changeSprite () {
  	  int spriteIndex = hits - 1;
  	  if (hitSprites[spriteIndex]){
				this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];  	  
  	  } else {
  	  	Debug.LogError("Brick sprite missing!");
  	  }
  	}
  	
  	// TODO Remove this method when actual win conditions are completed
  	void Win() {
  		levelManager.LoadNextLevel();
  	}
}
