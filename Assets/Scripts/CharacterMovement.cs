using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	#region private vars
	// animator component instace for player
	private Animator anim;

	// rigidbody compontent instance for the player
	private Rigidbody2D playerRigidBody2D;

	// player game object component
	private GameObject playerSprite;

	// how much movement is need per input
	private float movePlayerVector;

	// tell which way the player is face
	private bool facingRight;
	#endregion

	#region public vars
	//speed modifier for player movement
	public float speed = 4.0f;
	#endregion

	// initialize our component reference
	void Awake () {
		playerRigidBody2D = (Rigidbody2D)GetComponent (typeof(Rigidbody2D));

		playerSprite = transform.Find ("PlayerSprite").gameObject;

		anim = (Animator)playerSprite.GetComponent (typeof(Animator));
	}

	// Update is called once per frame
	void Update () {
		// Move the player horizontally
		movePlayerVector = Input.GetAxis ("Horizontal");

		anim.SetFloat ("speed", Mathf.Abs(movePlayerVector));

		playerRigidBody2D.velocity = new Vector2 (movePlayerVector * speed, playerRigidBody2D.velocity.y);

		if (movePlayerVector > 0 && !facingRight) {
			Flip ();
		} else if (movePlayerVector < 0 && facingRight) {
			Flip();
		}
	}

	void Flip() {
		//flip the way the player is facing
		facingRight = !facingRight;

		// multiply the players localScale x by -1
		Vector3 theScale = playerSprite.transform.localScale;

		theScale.x *= -1;

		playerSprite.transform.localScale = theScale;
	}
}
