﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;

	private int timesHit;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		timesHit++;
		SimulateWin();
	}

	// TODO remove this method once we can actually win
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}
}
