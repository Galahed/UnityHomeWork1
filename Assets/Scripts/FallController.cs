using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallController : MonoBehaviour
{
    public Transform FollowTarget;
    private float _fixedY;
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        Vector3 initialPosition = transform.position;
        _offset = initialPosition - FollowTarget.transform.position;
        _fixedY = initialPosition.y;
    }

    private void LateUpdate()
    {
        Vector3 newPosition = FollowTarget.transform.position + _offset;
        newPosition.y = _fixedY;
        transform.position = newPosition;
    }
}
