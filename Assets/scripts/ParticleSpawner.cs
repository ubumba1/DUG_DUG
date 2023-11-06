using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ParticleSpawner : MonoBehaviour
{
    public ParticleSystem particleSystemPrefab;
    private bool isPlaying = false;

    public void SpawnParticle()
    {
        if (!isPlaying)
        {
            ParticleSystem newParticleSystem = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);
            newParticleSystem.Play();
            Destroy(newParticleSystem.gameObject, newParticleSystem.main.duration);
            isPlaying = true;
            StartCoroutine(ResetIsPlaying());
        }
    }

    private IEnumerator ResetIsPlaying()
    {
        yield return new WaitForSeconds(particleSystemPrefab.main.duration);
        isPlaying = false;
    }
}
