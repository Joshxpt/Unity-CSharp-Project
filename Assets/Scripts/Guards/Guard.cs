using UnityEngine;

public class Guard : MonoBehaviour
{
    public Movement movement { get; private set; }
    public GuardRoaming roam { get; private set; }
    public GuardHome home { get; private set; }
    public GuardMobilised mobilised { get; private set; }
    public GuardBehaviour initalBehaviour;
    public GuardBehaviour nextBehaviour;
    public Transform target;

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
        this.home = GetComponent<GuardHome>();
        this.roam = GetComponent<GuardRoaming>();
        this.mobilised = GetComponent<GuardMobilised>();
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.movement.ResetRound();
        this.mobilised.Disable();
        this.roam.Enable();

        if (this.home != this.initalBehaviour)
        {
            this.roam.Enable();
        }
        else
        {
            this.home.HomeEnable();
        }



        //if (this.initalBehaviour = null)
        //{
        //this.home.Enable();
        //}

        //if (this.initalBehaviour == this.home)
        //{
        //this.home.Enable();
        //}
        //else
        //{
        //this.home.Disable();
        //}
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Prisoner"))
        {
            FindObjectOfType<GameManager>().PrisonerCaptured();

        }
    }

    public void SetPosition(Vector3 position)
    {
        // Keep the z-position the same since it determines draw depth
        position.z = transform.position.z;
        transform.position = position;
    }

}

