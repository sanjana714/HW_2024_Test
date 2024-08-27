using UnityEngine;

public class DoofusMovement : MonoBehaviour
{
    public float speed = 3.0f;  // Set this from the JSON file
    private Vector3 direction;
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        MoveDoofus();
    }

    void MoveDoofus()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        direction = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pulpit"))
        {
            // If Doofus lands on a new pulpit, increase the score
            scoreManager.IncreaseScore();
        }
    }
}