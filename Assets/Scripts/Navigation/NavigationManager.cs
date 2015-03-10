using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Naviagation manager holds all the navigation locations and loads those scenes when called
 */

public class NavigationManager : MonoBehaviour {

	public static Dictionary <string, string> RouteInformation = new Dictionary<string, string> () 
	{
		{"World", "the big world"},
		{"Cave", "the dark cave"},
	};

	public static string GetRouteInfo ( string Destination) {
		return RouteInformation.ContainsKey (Destination) ?
			RouteInformation [Destination] : null;
	}

	public static bool CanNavigate ( string Destination) {
		return true;
	}

	public static void NavigateTo ( string Destination) {
		//commented out till routes are created
		//Application.loadLevel (Destination);
	}
}
