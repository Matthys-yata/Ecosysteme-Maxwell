using UnityEngine;

public class ArrowsCharacterController : MonoBehaviour
{

    [Tooltip("Defines the speed (in units/s) of the character.")]
    public float speed;

    void Update()
    {
        Vector3 moveDirection = new Vector3();

        if (Input.GetKey(KeyCode.RightArrow) /* == true */)
        {
            moveDirection.x += 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection.x -= 1;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection.z += 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection.z -= 1;
        }
        if (moveDirection != Vector3.zero)
        {
            moveDirection.Normalize();

            transform.position += moveDirection * speed * Time.deltaTime;

            transform.forward = moveDirection;
        }
    }

}