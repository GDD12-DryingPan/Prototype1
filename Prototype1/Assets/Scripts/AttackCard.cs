using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : MonoBehaviour
{
    public int Damage = 10;
    public HealthBehaviour Enemy;

    public AudioClip AttackSoundEffect;

    public void Play()
    {
        Enemy.HitPoints = 0;

        AudioSource.PlayClipAtPoint(AttackSoundEffect, Vector2.zero);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
