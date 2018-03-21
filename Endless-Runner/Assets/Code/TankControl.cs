using UnityEngine;

/// <summary>
/// Implements player control of tanks, as well as collision detection.
/// </summary>
public class TankControl : MonoBehaviour {
    /// <summary>
    /// How fast to drive
    /// </summary>
    public float ForwardSpeed = 1f;
    /// <summary>
    /// How fast to turn
    /// </summary>
    public float RotationSpeed = 80f;
    /// <summary>
    /// Delay between shooting
    /// </summary>
    public float FireCooldown = 0.5f;

    /// <summary>
    /// Keyboard controls for the player.
    /// </summary>
    public KeyCode ForwardKey, LeftKey, RightKey, FireKey;

    /// <summary>
    /// Prefab for the bullets we fire.
    /// </summary>
    public GameObject Projectile;

    ///<summary>
    ///Holds the time at which next shot can be fired
    ///</summary>
    private float NextFire;

    /// <summary>
    /// Current rotation of the tank (in degrees).
    /// We need this because Unity's 2D system is built on top of its 3D system and so they don't
    /// give you a method for finding the rotation that doesn't require you to know what a quaternion
    /// is and what Euler angles are.  We haven't talked about those yet.
    /// </summary>
    private float Rotation {
        get
        {
            return transform.rotation.eulerAngles.z;
        }
        set {
            transform.rotation = Quaternion.Euler(new Vector3 (0, 0, value)); // don't worry about this just yet
        }
    }

    void Update()
    {
        if(Input.GetKey(ForwardKey))  
            transform.position += transform.up * ForwardSpeed * Time.deltaTime;

        if (Input.GetKey(LeftKey))
            Rotation += RotationSpeed * Time.deltaTime;

        if (Input.GetKey(RightKey))
            Rotation += -RotationSpeed * Time.deltaTime;

        if(Input.GetKeyDown(FireKey) && Time.time>NextFire)
        {
            GameObject bullet=Instantiate(Projectile);
            bullet.GetComponent<Projectile>().Init(gameObject, transform.position+transform.up*1.5f, gameObject.transform.up);
            NextFire = Time.time + FireCooldown;
        }
    }

    internal void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.tag)
        {
            case "Projectile":
                ScoreManager.IncreaseScore(other.gameObject.GetComponent<Projectile>().Creator, 10);
                Destroy(other.gameObject);
                    break;

            case "Mine":
                ScoreManager.IncreaseScore(this.gameObject, -20);
                Destroy(other.gameObject);
                break;           
        }
    }

}


