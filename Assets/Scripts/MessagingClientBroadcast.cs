using UnityEngine;
using System.Collections;

public class MessagingClientBroadcast : MonoBehaviour {

	public void OnCollisionEnter2D(Collision2D col){
		MessageManager.Instance.Broadcast ();
	}
}
