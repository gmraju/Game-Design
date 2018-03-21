using System;
using UnityEngine;

/// <summary>
/// Creates yummies for the frog to eat.
/// Also detects when the yummy falls off the bottom of the screen.
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
public class YummySpawner : MonoBehaviour {
    /// <summary>
    /// The prefab of the yummy to spawn
    /// </summary>
    public GameObject YummyPrefab;
	/// <summary>
	/// The initiation of YummyPrefab
	/// </summary>
	public GameObject cloneyummy;
	/// <summary>
	/// The position to produce yummy
	/// </summary>
	public Vector3 cloneposition = new Vector3(4, 11, 0);
    /// <summary>
    /// Number of seconds between spawns
    /// </summary>
    public float SpawnRate = 5.0f;
    /// <summary>
    /// Rate at which to decrease the spawn rate.
    /// </summary>
    public float SpawnAcceleration = 0.05f;
    /// <summary>
    /// Time at which the next spawn will occur
    /// </summary>
    ///private float nextSpawn;

    /// <summary>
    /// Event handlers to call if the frog misses the yummy
    /// </summary>
    public event Action YummyMissed;
	/// <summary>
	/// Time at which the next spawn will occur
	/// </summary>
	public float nextTime;
	/// <summary>
	/// The seconds between two yummies
	/// </summary>
	public float SpawnTime;
    /// <summary>
    /// Check if it's time to create a new yummy
    /// </summary>
    internal void Update(){
		if (Time.time > nextTime) { SpawnYummy (); }
    }
    
    /// <summary>
    /// Make a new yummy
    /// </summary>
    void SpawnYummy(){
		cloneyummy = (GameObject)Instantiate(YummyPrefab, cloneposition, transform.rotation);
		SpawnTime = SpawnRate - SpawnAcceleration;
		nextTime = Time.time + SpawnTime;
    }

    /// <summary>
    /// Called when a yummy hits the spawner's collider, which should be
    /// placed at the bottom of the screen
    /// </summary>
    /// <param name="yummy">The object collided with, i.e. the yummy</param>
    internal void OnTriggerEnter2D(Collider2D yummy) {
		Destroy (cloneyummy);
		YummyMissed.Invoke ();
    }
}
