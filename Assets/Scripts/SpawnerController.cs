using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject zombiePrefab;
    private float lifeTimer;

    void Update()
    {
        if ((lifeTimer += Time.deltaTime) > 1.0f)
        {
            GameObject exploude = Instantiate(zombiePrefab, transform.position, transform.rotation);
            lifeTimer = 0;
        }

    }
    
        
    
}
