using UnityEngine;

public class PlayerSimple : MonoBehaviour
{
    //I hope that children know something about float numbers. If they know nothing it s a good chance to explain it to them.
    public float Speed = 1;

    //Lets talk about binary operations. Its simple.
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            MoveUp();
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            MoveDown();
        }
    }

    public void MoveLeft()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;
    }

    public void MoveRight()
    {
        transform.position += Vector3.right * Speed * Time.deltaTime;
    }

    public void MoveUp()
    {
        transform.position += Vector3.up * Speed * Time.deltaTime;
    }

    public void MoveDown()
    {
        transform.position += Vector3.down * Time.deltaTime * Speed;
    }
}