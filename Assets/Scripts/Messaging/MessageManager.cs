using System;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour {

	// static singlton variable
	public static MessageManager Instance {
				get;
				private set;
	}

	// public property for manager
	private List<Action> subscribers = new List<Action>();

	// 
	void Awake() {

		Debug.Log ("Messaging Manager Started");
		//Check if there are any instances conflicting

		if (Instance != null && Instance != this) {
			// Destory other instances if they are not the same
			Destroy(gameObject);
		}

		// Save our current instance
		Instance = this;

		// Make sure the instance isn't destoryed between scenes
		DontDestroyOnLoad (gameObject);
	}

	// subscribe method for manager
	public void Subscribe(Action subscriber){
		Debug.Log("Subscriber registered");
		subscribers.Add(subscriber);
	}

	// unsubscribe method for manager
	public void Unsubscribe(Action subscriber){
		Debug.Log ("Subscriber unregistered");
		subscribers.Remove (subscriber);
	}

	// clear messages
	public void ClearAllSubscribers(){
		subscribers.Clear ();
	}

	// Broadcast method
	public void Broadcast() {
		Debug.Log ("Number of subscribers " + subscribers.Count);
		foreach (var subscriber in subscribers) {
			subscriber();
		}
	}
}
