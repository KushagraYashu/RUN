using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int healMultiplier = 1;
    public int speedBoosts = 0;
    public int heal = 0;
    public Text speedBoostsText;
    public Text healText;
    
    public Text score;
    
    private bool healing = false;
    [SerializeField] private float health;
    public GameObject hpGlow;
    public GameObject enemy;
    public GameObject critical;
    public RawImage deadBG;
    public GameObject dead;
    public Text healthText;
    public Text deadTxt;
    public float hpDuration;
    [SerializeField] private float maxHealth = 100;
    
    private float healRate = 0.50f;
    public bool shot = false;
    

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        

    }

    // Update is called once per frame
    void Update()
    {
        
        

        if (health > 0)
        {
            speedBoostsText.text = "" + (int)speedBoosts;
            healText.text = "" + (int)heal;
            healthText.text = "" + (int)health;

            if (health < 30)
            {
                hpGlow.SetActive(true);
                critical.SetActive(true);
            }
            else
            {

                hpGlow.SetActive(false);
                critical.SetActive(false);


            }
            if(Input.GetKeyDown(KeyCode.E) && heal > 0 && health < maxHealth)
            {
                HealAbility();
                //health += healRate * 3 * Time.deltaTime;
                
                heal--;
            }
            else
            {
               // healMultiplier = 1;
            }
            

        }
        if (health <= 0)
        {
           
            //Destroy(healthText);
            Destroy(critical);
            Destroy(speedBoostsText);
            Destroy(healText);
            Destroy(healthText) ;
            this.GetComponent<Movement>().enabled = false;
            Dead();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Speed")
        {
            Destroy(other.gameObject);
            speedBoosts++;
        }
        if(other.tag == "Heal")
        {
            Destroy(other.gameObject);
            heal++;
        }
        if (other.tag == "Enemy")
        {
            int par;
            health = par = (int)health - 15;
            if (health <= maxHealth / 15)
                health = 0;
            shot = true;
            //Destroy(this.gameObject);
        }
        else
        {
            shot = false;
        }
        if(other.tag == "Bullet")
        {
            Bullet bulletScript = other.gameObject.GetComponent<Bullet>();
            shot = true;
            health -= bulletScript.damage;
            Destroy(other.gameObject);
        }
        else
        {
            shot = false;
        }

    }

    private void FixedUpdate()
    {
        score.text = this.transform.position.z.ToString("0");
        if (health < maxHealth && health > 0 && healing == false)
        {
            if(!shot)
            {
                
                float Par;
                Par = healRate;
                //Debug.Log((int)Par);
                health += Par * Time.deltaTime ;
                //Debug.Log(health);
                
            }
        }

        
    }

    private void HealAbility()
    {
        
        while(!shot && health < maxHealth)
        {
            healthText.text = "" + (int)health;
            healMultiplier = 40;
            health += healRate * healMultiplier * Time.deltaTime;
            
        }
        healMultiplier = 1;
    }

    void Dead()
    {
        
        StartCoroutine(Fade());
    }
    IEnumerator Fade()
    {
        dead.SetActive(true);
        for (float i = 0; i <= 1; i += Time.unscaledDeltaTime * 3)
        {
            // set color with i as alpha
            deadBG.color = new Color(1, 1, 1, i);
            yield return null;
        }
        StartCoroutine(Txt());
    }
     IEnumerator Txt()
    {
        for (float i = 250; i > 145; i -= Time.unscaledDeltaTime * 100)
        {
            deadTxt.fontSize = (int)i;
            yield return null;
        }
    }

    

}
