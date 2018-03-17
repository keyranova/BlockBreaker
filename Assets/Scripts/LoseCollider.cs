using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	public LevelManager levelManager;

	private void OnTriggerEnter2D(Collider2D collision) {
		print("Trigger");
		levelManager.LoadLevel("Win");
	}
}
