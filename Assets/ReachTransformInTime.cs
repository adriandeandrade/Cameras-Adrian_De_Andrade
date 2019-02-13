using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachTransformInTime : MonoBehaviour
{
    public Transform target;
    public float reachingTime;

    private float initialTime;
    private Transform initialTransform;

    private Vector3 initialPostion;
    private Quaternion initialRotation;

    private bool isReaching;
    private bool attachToTarget;

    public void InitReaching(Transform pTarget, float pReachingTime, bool pAttachToTarget)
    {
        initialTime = Time.time;
        initialTransform = transform;

        initialPostion = transform.position;
        initialRotation = transform.rotation;

        target = pTarget;
        reachingTime = pReachingTime;
        attachToTarget = pAttachToTarget;
        isReaching = true;
    }

    private void Update()
    {
        if (!isReaching) return;

        float timeRatio = (Time.time - initialTime) / reachingTime;

        if (timeRatio > 1)
        {
            timeRatio = 1;
            isReaching = false;
        }

        transform.position = Vector3.Lerp(initialTransform.position, transform.position, timeRatio
            );

        transform.rotation = Quaternion.Slerp(initialTransform.rotation, target.rotation, timeRatio);

        if(timeRatio >= 1)
        {
            if(attachToTarget)
            {
                transform.SetParent(target);
            }
            Destroy(gameObject);
        }
    }
}
