using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroys the attached ParticleSystem's GameObject when it's over
public class OneShotParticles : MonoBehaviour
{

    public ParticleSystem _ParticleSystem;
	
    // Update is called once per frame
    void Update()
    {
        // Destroys the attached ParticleSystem's GameObject if it's over
        if (!_ParticleSystem.IsAlive()) {
            Destroy(gameObject);
        }
    }
}
