using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodController : MonoBehaviour
{

    
    void Start()
    {
        Destroy(gameObject, 0.1f);//destroying blood particles after playing
    }

    
}
