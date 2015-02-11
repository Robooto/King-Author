using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	// Distance the player can move in the x-axis before camera moves
	public float xMargin = 1.5f;

	// Distance the player can move in the y-axis before camera moves
	public float yMargin = 1.5f;

	// How smoothly the camera catches up
	public float xSmooth = 1.5f;

	// smooth in the y direction
	public float ySmooth = 1.5f;

	// max x and y the camera can have
	private Vector2 maxXAndY;

	// min x and y the camera can have
	private Vector2 minXAndY;

	// reference to the player
	public Transform player;

	void Awake() {
		player = GameObject.Find ("Player").transform;

		if (player == null) {
			Debug.LogError("No player found!");		
		}

		//get the bounds from the background image
		var backgroundBounds = GameObject.Find ("Background").renderer.bounds;

		// viewable bounds of the camera
		var camTopLeft = camera.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		var camBottomRight = camera.ViewportToWorldPoint (new Vector3 (1, 1, 0));

		//automatically set the x and y values
		minXAndY.x = backgroundBounds.min.x - camTopLeft.x;
		maxXAndY.x = backgroundBounds.max.x - camBottomRight.x;
	}

	bool CheckXMargin(){
		// Returns true if the distance between the camera and the player is
		// greater than the xMargin
		return Mathf.Abs (transform.position.x - player.position.x) > xMargin;
	}

	bool CheckYMargin(){
		// Returns true if the distance between the camera and the player is
		// greater than the yMargin
		return Mathf.Abs (transform.position.y - player.position.y) > yMargin;
	}

	void FixedUpdate() {
		// By default the target x and y coordinates of the camera
		// are it's current x and y coordinates.
		float targetX = transform.position.x; 
		float targetY = transform.position.y;

		//if the player moves beyond the xmargin
		if (CheckXMargin ()) {
		// the camera will leap to the player's position
			targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.fixedDeltaTime);
		}

		//if the player moves beyond the xmargin
		if (CheckYMargin ()) {
			// the camera will leap to the player's position
			targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.fixedDeltaTime);
		}

		//target x and y should not be larger than the camera's
		targetX = Mathf.Clamp (targetX, minXAndY.x, maxXAndY.x);
		targetY = Mathf.Clamp (targetY, minXAndY.y, maxXAndY.y);

		// make sure the camera and target are on the same z scale
		transform.position = new Vector3 (targetX, targetY, transform.position.z);
	}

}
