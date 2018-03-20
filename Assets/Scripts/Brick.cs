using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;

	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (tag == "Breakable");
		// keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
		}

		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		AudioSource.PlayClipAtPoint(crack, transform.position, 1.5f);

		if (isBreakable) {
			HandleHits();
		}
	}

	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;

		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}

	void LoadSprites() {
		int spriteIndex = timesHit - 1;

		if (hitSprites[spriteIndex]) {
			GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
}
