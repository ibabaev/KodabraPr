using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    public bool Right;
    public float Speed = 0.1f;

    private void Update()
    {
        if (Right)
            transform.Translate(Speed, 0, 0);
        else
            transform.Translate(-Speed, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerPhysicalFourth>().GetDamage();
        }
        else if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().GetDamage();
        }
        else if (!other.CompareTag("Ground")) return;

        Destroy(gameObject);

    }
}