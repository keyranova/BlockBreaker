using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			// Lock the ball relative to the paddle
			transform.position = paddle.transform.position + paddleToBallVector;

			// Wait for a mouse press to launch
			if (Input.GetMouseButtonDown(0)) {
				print("mouse clicked, launch ball");
				hasStarted = true;

				Rigidbody2D rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
				rigidbody2D.velocity = new Vector2(2f, 10f);
			}
		}
	}
}
