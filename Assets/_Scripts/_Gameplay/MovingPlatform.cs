using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public List<GameObject> movePoints;
    int currentMovePointIndex;
    Vector3 targetpos;

    public int speed = 15;

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(movePoints[currentMovePointIndex].transform.position.magnitude - transform.position.magnitude) < .1f)
        {
            currentMovePointIndex++;

            if (currentMovePointIndex >= movePoints.Count)
                currentMovePointIndex = 0;
        }

        targetpos = movePoints[currentMovePointIndex].transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
            collision.gameObject.transform.SetParent(transform);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
            collision.gameObject.transform.SetParent(null);
    }
}
