using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetBox : MonoBehaviour
{
    /// <summary>
    /// Targets that move past this point score automatically.
    /// </summary>
    public static float OffScreen;

    internal void Start() {
        OffScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width-100, 0, 0)).x;
    }

    internal void Update()
    {
        if (transform.position.x > OffScreen)
            Scored();
    }

    private void Scored()
    {
        // FILL ME IN
        Color green = new Color(0f, 255f, 0f);
        if (gameObject.GetComponent<SpriteRenderer>().color != green)
        {
            gameObject.GetComponent<SpriteRenderer>().color = green;
            ScoreKeeper.AddToScore(gameObject.GetComponent<Rigidbody2D>().mass);

            //Checking if Robot scene
            if (SceneManager.GetActiveScene().name == "Robot" && GameObject.FindGameObjectWithTag("Bomb"))
                RobotTalk.ChangeText();
        }     
    }

    internal void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Scored();
        }

    }
}
