using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float high = 13;
    public float gravityModifier =2.6f;
    private bool isOnGround = true;
    public bool gameOver = false;
    private Animator playAnim;
    public ParticleSystem expParticle; 
    public ParticleSystem dirtParticle;  
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource audi;
    // Start is called before the first frame update
    void Start()
    {
        audi = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        playAnim = GetComponent<Animator>();
        Physics.gravity = Physics.gravity * gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && gameOver == false)
        {
            playerRb.AddForce(Vector3.up * high, ForceMode.Impulse);
            isOnGround = false;
            playAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            audi.PlayOneShot(jumpSound, 0.9f);
        }
    }

    private void OnCollisionEnter(Collision collision){
        

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle")){
            Debug.Log("Game Over!");
            gameOver = true;
            playAnim.SetBool("Death_b", true);
            playAnim.SetInteger("DeathType_int", 1);
            expParticle.Play();
            dirtParticle.Stop();
            audi.PlayOneShot(crashSound, 0.9f);
            
        }
    }
}
