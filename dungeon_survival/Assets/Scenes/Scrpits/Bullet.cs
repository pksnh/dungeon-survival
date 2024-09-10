using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;

    public GameObject effect;

    public AudioClip sound1;
    public AudioClip sound2;

    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody= GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 6f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController pc = other.GetComponent<PlayerController>();

            if(pc != null)
            {
                audio.PlayOneShot(sound1);

                Instantiate(effect, transform.position, Quaternion.identity);

                pc.Die();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
