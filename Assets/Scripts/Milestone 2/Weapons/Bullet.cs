//Bullet Script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Bullet : MonoBehaviour
{
    public float damage = 10;
    public float moveSpeed = 10;

    [Header("Audio for Bullet")]
    public AudioSource bulletCollision;
    public AudioClip clip;
    public AudioClip bulletClip;

    public GameObject collisionPrefab;
    [SerializeField] private float lifespan = 2f;
    public SettingsMenu menu;

    // Start is called before the first frame update
    void Start()
    {
        bulletCollision = GetComponent<AudioSource>();
        Destroy(gameObject, lifespan);
    }
    private void Awake()
    {
        bulletCollision.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        // go
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        Pawn pawn = other.gameObject.GetComponent<Pawn>();
        if (pawn != null)
        {
            pawn.Damage(damage);
            
        }
        Destroy(gameObject);
        Impact();
        AudioSource.PlayClipAtPoint(bulletClip, transform.position, menu.sFXVolume);
    }

    //Collision Spawn the effect
    void Impact()
    {
        GameObject splatter = Instantiate(collisionPrefab, transform.position, Quaternion.identity);
        splatter.GetComponent<ParticleSystem>().Play();
    }
}
