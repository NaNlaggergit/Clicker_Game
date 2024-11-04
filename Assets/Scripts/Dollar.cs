using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dollar : MonoBehaviour
{
    private float launchSpeed = 1f;
    private float fallSpeed = 3f;
    private Vector3 moveDirection;
    private bool isFall = false;
    private Transform targetObject;
    private Camera cam;
    public void LaunchInRandomDirection(Transform transform,Camera camera)
    {
        targetObject = transform;
        cam = camera;
        float randomAngle = Random.Range(-45f, 45f);
        moveDirection = Quaternion.Euler(0, 0, randomAngle) * Vector3.up;
        StartCoroutine(Movement());
    }
    private IEnumerator Movement()
    {
        while(true)
        {

            if (!isFall)
            {
                transform.position += moveDirection * launchSpeed*Time.deltaTime;
                if (transform.position.y >= targetObject.position.y-1f)
                {
                    isFall = true;
                    moveDirection = Vector3.down;
                }
            }
            else
            {
                transform.position+=moveDirection*fallSpeed*Time.deltaTime;
                if (transform.position.y < cam.ScreenToWorldPoint(Vector3.zero).y - 0.1f)
                    Destroy(gameObject);
            }
            //transform.Rotate(0, 0, Random.Range(-100f, 100f) * Time.deltaTime);
            yield return null;
        }
    }

    void Update()
    {

    }
}
