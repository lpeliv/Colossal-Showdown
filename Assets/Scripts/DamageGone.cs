using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGone : MonoBehaviour
{
    public float destroyTime = 0.4f;
    public Vector3 Offset = new Vector3(0, 2, 0);
    public Vector3 RandomizeIntensity = new Vector3(5.5f, 0, 3.0f);

    void Start()
    {
        Destroy(gameObject, destroyTime);

        transform.localPosition += Offset;
        transform.localPosition += new Vector3(Random.Range(-RandomizeIntensity.x, RandomizeIntensity.x), Random.Range(-RandomizeIntensity.y, RandomizeIntensity.y), Random.Range(-RandomizeIntensity.z, RandomizeIntensity.z));
    }

}
