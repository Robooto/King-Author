using UnityEngine;
using UnityEditor;
using System.Collections;

/*
 * Creating conversations from the editor
 */

public class ConversationAssetCreator : MonoBehaviour {

	[MenuItem("Assets/Create/Conversation")]
	public static void CreateAsset() {
		CustomAssetUtility.CreateAsset<Conversation> ();
	}
}
