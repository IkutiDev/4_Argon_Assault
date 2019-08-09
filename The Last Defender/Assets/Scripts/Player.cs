using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] private float speed = 20f;

    [SerializeField] private float xScreenEdgeValue = 10f;

    [SerializeField] private float yScreenEdgeValue = 6f;

    [SerializeField] private float positionPitchFactor = -4f;
    [SerializeField] private float positionYawFactor=4f;
    [SerializeField] private float controlPitchFactor = -24f;
    [SerializeField] private float controlRollFactor = -24f;

    private float xThrow, yThrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotating();
    }

    private void Rotating()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow= pitchDueToPosition + yThrow*controlPitchFactor;
        float yawDueToPosition=transform.localPosition.x*positionYawFactor;
        float rollDueToControlThrow=xThrow* controlRollFactor;
        transform.localRotation= Quaternion.Euler(pitchDueToControlThrow, yawDueToPosition, rollDueToControlThrow);
    }

    private void Movement()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * speed * Time.deltaTime;

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yScreenEdgeValue, yScreenEdgeValue);
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xScreenEdgeValue, xScreenEdgeValue);
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
