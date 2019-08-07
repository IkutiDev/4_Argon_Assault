using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] private float xSpeed = 4f;

    [SerializeField] private float xScreenEdgeValue = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x+xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xScreenEdgeValue, xScreenEdgeValue);
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y,transform.localPosition.z);
    }
}
