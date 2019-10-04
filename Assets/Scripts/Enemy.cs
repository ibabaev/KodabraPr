using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 3;
    public float BulletSpeed = 1;
    public bool Right;

    public GameObject BulletRight;
    public GameObject BulletLeft;

    private void Start()
    {
        InvokeRepeating("Shoot", 2f, 2f);
    }

    public void GetDamage()
    {
        Health--;

        if (Health <= 0)
            Destroy(gameObject);
    }

    private void Shoot()
    {
        if (Right)
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
}