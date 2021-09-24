using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizontal = 0;
    
    public Rigidbody rb;
    public float speed;
    public float multiplier = 1;
    public float horSpeed;
    public float boostTime = 1.5f;
    public GameObject Glow;
    public GameObject slowedText;
    public bool slowed = false;
    Vector2 movement;

    public Player playerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        slowedText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontal = Input.GetAxis("Horizontal");
        if(playerScript.speedBoosts != 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && !playerScript.shot)
            {
                multiplier = 8f;
                Glow.SetActive(true); 
                Invoke("DisableBoost", boostTime);
                playerScript.speedBoosts--;
                
            }
            
        }

        if(Input.GetAxis("Jump") > 0f)
        {
            slowed = true;
            slowedText.SetActive(true);
        }

        else
            slowed = false;
        
    }
    

    private void FixedUpdate()
    {
        movement = new Vector2(horizontal, 0);
        
        Move(speed, horSpeed);
        
    }

    private void DisableBoost()
    {
        multiplier = 1f;
        Glow.SetActive(false);
    }

    private void Move(float sp, float hrsp)
    {
        if (slowed == true)
        {
            sp = sp / 2;
            hrsp /= 2;
            transform.position += transform.forward * sp * multiplier * Time.deltaTime;
            sp = sp * 2;
            hrsp *= 2;
            rb.AddForce(movement * hrsp);
        }
        else
        {
            transform.position += transform.forward * sp * multiplier * Time.deltaTime;
            rb.AddForce(movement * hrsp);
            slowedText.SetActive(false);
        }
    }
}
