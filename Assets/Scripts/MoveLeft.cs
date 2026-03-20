using UnityEngine;
using UnityEngine.InputSystem;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;

    private float leftBound = -15;

    private PlayerController playerController;

    private InputAction sprintAction;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        sprintAction = InputSystem.actions.FindAction("Sprint");
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if (sprintAction.inProgress && !playerController.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed * 2);
        }
    }
}
