using UnityEngine;
using UnityEditor;
using System.Collections;

public class PositionManager : MonoBehaviour {

	//Define menu opition in the editor
	[MenuItem("Assets/Create/PositionManager")]
	public static void CreateVoidAsset() {

		//create new instance of our scriptable object
		ScriptableObject positionManager = ScriptableObject.CreateInstance<ScriptingObjects>();

		//create asset file for our new object and save it
		AssetDatabase.CreateAsset (positionManager, "Assets/newPositionManager.asset");

		//switch our view to the new item in the inspector
		EditorUtility.FocusProjectWindow ();
		Selection.activeObject = positionManager;
	}
}
