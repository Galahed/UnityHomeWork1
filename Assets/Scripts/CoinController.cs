using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    float speed = 90.0f;
    float height = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.active)
        {
            transform.Rotate(0, speed * Time.deltaTime, 0, Space.Self);
            /*            Vector3 position = transform.position;
                        position.y = height * Mathf.Sin(Time.deltaTime);
                        Debug.Log(position[2]);
                        transform.position = position;
            */
            transform.Translate(Vector3.up * height * Mathf.Sin(Time.deltaTime * 2));
        }
    }

}
