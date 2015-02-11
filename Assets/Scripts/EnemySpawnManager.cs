using UnityEngine;
using System.Collections;

public class EnemySpawnManager : MonoBehaviour {

	// time before spawn
	public float spawnTime = 5f;

	// delay before spawn
	public float spawnDelay = 3f;

	// array of prefabs to spawn
	public GameObject[] enemies;

	// Use this for initialization
	void Start () {
	
		//Start calling spawn after some delay
		InvokeRepeating ("Spawn", spawnDelay, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn() {
		//Instanitate a random enemy
		int enemyIndex = Random.Range(0, enemies.Length);
		Instantiate (enemies [enemyIndex], transform.position, transform.rotation);
	}
}
