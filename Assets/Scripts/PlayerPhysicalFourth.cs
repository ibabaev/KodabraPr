using UnityEngine;

public class PlayerPhysicalFourth : MonoBehaviour
{
    public int Health = 4;

    public float Speed = 1;
    public float BulletSpeed = 1;

    public Rigidbody PlayerRb;

    public GameObject BulletRight;
    public GameObject BulletLeft;

    private const float _jumpForce = 250;

    private bool _canJump;

    void Start()
    {
        if (PlayerRb == null)
        {
            PlayerRb = GetComponent<Rigidbody>();
        }

        _canJump = true;
    }

    void Update()
    {
        int multiplayer = 0;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            multiplayer = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            multiplayer = 1;
        }

        Move(multiplayer);

        if (_canJump && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            _canJump = false;
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Fire(true);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Fire(false);
        }
    }

    public void Move(int multiplayer)
    {
        PlayerRb.velocity = new Vector3(multiplayer * Speed, PlayerRb.velocity.y, PlayerRb.velocity.z);
    }

    public void Jump()
    {
        PlayerRb.AddForce(new Vector3(0, _jumpForce, 0));
    }

    public void GetDamage()
    {
        Health--;

        if (Health <= 0)
            GameManager.Instance.ResetActiveScene();
    }

    private void Fire(bool right)
    {
        if (right)
        {
            var clone = Instantiate(BulletRight, BulletRight.transform.position, Quaternion.identity);
            clone.SetActive(true);
        }
        else
        {
            var clone = Instantiate(BulletLeft, BulletLeft.transform.position, Quaternion.identity);
            clone.GetComponent<LinearMovement>().Right = false;
            clone.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            _canJump = true;
        }
    }
}