using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour
{

    public GameObject levelEnd;
    public GameObject levelEndTxtGO;
    public Text levenEndTxt;
    public Player player;
    public Enemy enemy;
    public Movement movement;
    public RawImage img;
    public StrScrp str;

    IEnumerator TextFn(bool resize)
    {
        if(resize)
        {
            for(float i = 250; i > 145; i -= Time.deltaTime * 100)
            {
                levenEndTxt.fontSize = (int)i;
                yield return null;
            }
        }
    }
    
          
    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 0; i <= 1; i += Time.deltaTime/3)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        
        
    }

// Start is called before the first frame update
    void Start()
    {
        levelEnd.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            int j = 0;
            levelEndTxtGO.SetActive(true);
            StartCoroutine(FadeImage(true));
            StartCoroutine(TextFn(true));
            levelEnd.SetActive(true);
            player.enabled = false;
            enemy.enabled = false;
            movement.enabled = false;
            if (j == 0)
            {
                StartCoroutine(mainMenu());
                j++;
            }
        }
    }
    IEnumerator mainMenu()
    {
        yield return new WaitForSeconds(3f);
        str.MainMenu();
    }
}
