using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public static ParticleSystem bulletSpark;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpark = GetComponent<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void Spark(ParticleSystem spark)
    {
        spark.Play();
    }
}
