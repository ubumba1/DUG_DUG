using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ParticleSpawner : MonoBehaviour
{
    public ParticleSystem particleSystemPrefab;
    private bool isPlaying = false;

    public void SpawnParticle(Vector3 position) // Добавлен аргумент position
    {
        if (!isPlaying)
        {
            ParticleSystem newParticleSystem = Instantiate(particleSystemPrefab, position, Quaternion.identity); // Используем переданную позицию
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
