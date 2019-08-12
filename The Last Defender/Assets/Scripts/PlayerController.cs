using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] private float controlSpeed = 20f;
    [SerializeField] private GameObject[] guns;

    [SerializeField] private float xScreenEdgeValue = 10f;

    [SerializeField] private float yScreenEdgeValue = 6f;
    [Header("Screen-position Based")]
    [SerializeField] private float positionPitchFactor = -4f;
    [SerializeField] private float positionYawFactor=4f;
    [Header("Control-throw ")]
    [SerializeField] private float controlPitchFactor = -24f;
    [SerializeField] private float controlRollFactor = -24f;
    

    private float xThrow, yThrow;

    private bool isDead;
    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            Movement();
            Rotating();
            ProcessFiring();
        }
    }

    private void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
        }
        else
        {
            DeactivateGuns();
        }
    }

    private void DeactivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }

    private void ActivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(true);
        }
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
        float yOffset = yThrow * controlSpeed * Time.deltaTime;

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yScreenEdgeValue, yScreenEdgeValue);
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * controlSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xScreenEdgeValue, xScreenEdgeValue);
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void TurnOffControls()
    {
        isDead = true;
    }
}
