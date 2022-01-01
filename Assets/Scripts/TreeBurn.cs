using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBurn : MonoBehaviour
{
    [SerializeField] ParticleSystem collectParticle = null;

    void Start()
    {
        Collect();
    }

    public void Collect()
    {
        //play graphics
        collectParticle.Play();
        //play sound
    }

}
