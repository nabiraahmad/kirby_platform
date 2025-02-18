using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 moveDistance = new Vector3(0, 3, 0);
    public float moveSpeed = 2f;
    public float waitTime = 1f;

    private Vector3 startPos;
    private Vector3 endPos;
    private bool isMoving = false;

    private void Start()
    {
        startPos = transform.position;
        endPos = startPos + moveDistance;
    }

    public void Activate()
    {
        Debug.Log("Activate() called on MovingPlatform!");

        if (!isMoving) 
        {
            Debug.Log("Starting platform movement!");
            StartCoroutine(MovePlatform());
        }
        else
        {
            Debug.Log("Platform is already moving, ignoring request.");
        }
    }


    private IEnumerator MovePlatform()
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, endPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(waitTime);

        while (Vector3.Distance(transform.position, startPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        isMoving = false;
    }
}