using UnityEngine;
using System.Collections;

public class MessagingClientReceiver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MessageManager.Instance.Subscribe (ThePlayerIsTryingToLeave);
	}
	
	void ThePlayerIsTryingToLeave()
	{
		Debug.Log("Oi Don't Leave me!! - " + tag.ToString());
	}
}
