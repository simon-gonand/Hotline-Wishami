using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBehavior : MonoBehaviour
{
    // Transform of the GameObject you want to shake
    private Transform self;

    // Desired duration of the shake effect
    private float shakeDurationTimer = 0f;

    // A measure of magnitude for the shake. Tweak based on your preference
    private float shakeMagnitude = 0.1f;

    // A measure of how quickly the shake effect should evaporate
    private float dampingSpeed = 1.0f;

    // The initial position of the GameObject
    Vector3 initialPosition;

    void Awake()
    {
        if (self == null)
        {
            self = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        initialPosition = self.localPosition;
    }

    void Update()
    {
        if (shakeDurationTimer > 0)
        {
            self.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDurationTimer -= Time.deltaTime * dampingSpeed;
        }
        else if (shakeDurationTimer != 0.0f)
        {
            shakeDurationTimer = 0f;
            self.localPosition = initialPosition;
        }
    }

    public void TriggerShake(float shakeDuration)
    {
        shakeDurationTimer = shakeDuration;
        initialPosition = self.localPosition;
    }

}
