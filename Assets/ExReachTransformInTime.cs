using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExReachTransformInTime : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReachTransformInTime reachTransformInTime = gameObject.AddComponent<ReachTransformInTime>();

            reachTransformInTime.InitReaching(target, 5.0f, true);

            Destroy(gameObject);
        }
    }
}
