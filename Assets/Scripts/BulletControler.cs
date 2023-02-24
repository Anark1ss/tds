using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControler : MonoBehaviour
{
    public GameObject exploudePrefab;

    private float lifeTimer;
    
    void Update()
    {
        if ((lifeTimer += Time.deltaTime) > 1.0f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Building"))
        {    
            SpawnExploudeParticle();
        }
        if (collision.gameObject.CompareTag("Zombie"))
        {
            Destroy(gameObject);
        }
    }

    void SpawnExploudeParticle()//spawn exploude particles
    {
        GameObject exploude = Instantiate(exploudePrefab, transform.position, transform.rotation);
        var explodeParticle = exploude.GetComponent<ParticleSystem>();
        explodeParticle.Play();
        Destroy(explodeParticle);
        Destroy(gameObject);       
    }
}
