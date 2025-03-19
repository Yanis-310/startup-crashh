using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    private bool isInArea = false;
    private bool isOn = false;

    public Light lightSource; // Référence à la lumière
    public float highIntensity = 2.0f; // Intensité haute
    public float lowIntensity = 0.5f;  // Intensité basse

    public Transform leverHandle; // Référence au levier
    public float leverDownAngle = -30f; // Angle vers le bas
    public float leverUpAngle = 0f; // Angle vers le haut
    public float leverSpeed = 5f; // Vitesse d'animation du levier

    void Start()
    {
        
    }

    void Update()
    {
        if (isInArea && Input.GetKeyDown(KeyCode.E))
        {
            isOn = !isOn;
            if (lightSource != null)
            {
                lightSource.intensity = isOn ? highIntensity : lowIntensity;
            }

            RotateLever(isOn);
            Debug.Log("Lumière " + (isOn ? "augmentée" : "réduite"));
        }
    }

    void RotateLever(bool turnOn)
    {
        if (leverHandle != null)
        {
            float targetAngle = turnOn ? leverUpAngle : leverDownAngle;
            StartCoroutine(AnimateLever(targetAngle));
        }
    }

    IEnumerator AnimateLever(float targetAngle)
    {
        Quaternion startRotation = leverHandle.localRotation;
        Quaternion endRotation = Quaternion.Euler(targetAngle, 0f, 0f);
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * leverSpeed;
            leverHandle.localRotation = Quaternion.Slerp(startRotation, endRotation, t);
            yield return null;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            isInArea = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            isInArea = false;
        }
    }
}
