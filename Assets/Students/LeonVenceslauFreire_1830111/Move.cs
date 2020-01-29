using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Front,
    Back,
    Up,
    Down
}

public class Move : MonoBehaviour
{
    //
    Vector3 startPosition;
    Vector3 endPosition;
    public float speed;
    public float distance;
    public Direction direction;
    bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        switch (direction)
        {
            case Direction.Front:
                endPosition.z = startPosition.z + distance;
                break;
            case Direction.Back:
                endPosition.z = startPosition.z - distance;
                break;
            case Direction.Up:
                endPosition.y = startPosition.y + distance;
                break;
            case Direction.Down:
                endPosition.y = startPosition.y - distance;
                break;
            default:
                break;
        }
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            switch (direction)
            {
                case Direction.Front:
                    transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime);
                    if (transform.position.z > endPosition.z)
                    {
                        isMoving = !isMoving;
                    }
                    break;
                case Direction.Back:
                    transform.Translate(new Vector3(0, 0, -speed) * Time.deltaTime);
                    if (transform.position.z < endPosition.z)
                    {
                        isMoving = !isMoving;
                    }
                    break;
                case Direction.Up:
                    transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
                    if (transform.position.y > endPosition.y)
                    {
                        isMoving = !isMoving;
                    }
                    break;
                case Direction.Down:
                    transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime);
                    if (transform.position.y < endPosition.y)
                    {
                        isMoving = !isMoving;
                    }
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (direction)
            {
                case Direction.Front:
                    transform.Translate(new Vector3(0, 0, -speed) * Time.deltaTime);
                    if (transform.position.z < startPosition.z)
                    {
                        isMoving = !isMoving;
                    }
                    break;
                case Direction.Back:
                    transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime);
                    if (transform.position.z > startPosition.z)
                    {
                        isMoving = !isMoving;
                    }
                    break;
                case Direction.Up:
                    transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime);
                    if (transform.position.y < startPosition.y)
                    {
                        isMoving = !isMoving;
                    }
                    break;
                case Direction.Down:
                    transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
                    if (transform.position.y > startPosition.y)
                    {
                        isMoving = !isMoving;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
