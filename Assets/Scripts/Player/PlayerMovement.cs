using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    public LayerMask obstacleLayer;
    Vector2 move;

    public new Rigidbody2D rigidbody { get; private set; }
    public Vector3 startingPosition { get; private set; }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Time.deltatime = Time between frames
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(move * speed * Time.deltaTime);
    }

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
        this.startingPosition = this.transform.position;
    }
    private void Start()
    {
        ResetRound();
    }

    public void ResetRound()
    {
        this.transform.position = this.startingPosition;
        this.rigidbody.isKinematic = false;
        this.enabled = true;
    }
}
