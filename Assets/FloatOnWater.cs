using UnityEngine;

public class FloatOnWater : MonoBehaviour
{
    public float floatStrength = 1f; 

    private Vector3 originalPosition; 
    public Material material;

    void Start()
    {
        originalPosition = transform.position; 
    }

    void Update()
    {
        float waveAmplitude = material.GetFloat("_Wave_Amplitude");
        float waveSpeed = material.GetFloat("_Wave_Speed");

        float yOffset = Mathf.Sin(Time.time * waveSpeed) * waveAmplitude;
        transform.position = originalPosition + Vector3.up * yOffset * floatStrength;
    }
}
