using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    [SerializeField] float smoothing = 5f;
    Vector3 offset;
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(changeSpeedOfWiehgtLift.AiIsEnabled == true)
        {
            Vector3 targetCameraPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetCameraPosition, smoothing * Time.deltaTime);
        }
    }
}
