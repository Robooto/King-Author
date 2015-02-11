using UnityEngine;
using System.Collections;

public class NavigationPrompt : MonoBehaviour {

	bool showDialog;

	void OnCollisionEnter2D(Collision2D col){
	
		// Only allow the player to travel if they are allowed
		if (NavigationManager.CanNavigate(this.tag)){
			showDialog = true;
		}
	}

	void OnCollisionExit2D(Collision2D col){
		showDialog = false;
	}

	void OnGUI() {

		if (showDialog) {
		
			//layout start
			GUI.BeginGroup(new Rect(Screen.width / 2 - 150, 50, 300, 250));

			//the menu box
			GUI.Box(new Rect(0, 0, 300, 250), "");

			//information text from navigation manager
			GUI.Label(new Rect(15, 10, 300, 68), "Do you want to travel to " + NavigationManager.GetRouteInfo(this.tag) +"?");

			// player wants to leave the area
			if(GUI.Button(new Rect(55, 100, 180, 40), "Travel")) {
				showDialog = false;

				//Load different scene
				//NavigationManager.NavigateTo(this.tag);
			}

			if(GUI.Button(new Rect(55, 150, 180, 40), "Stay")){
				showDialog = false;
			}

			//end group
			GUI.EndGroup();

		}
	}
}
