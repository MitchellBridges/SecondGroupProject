using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Health : MonoBehaviour
{
    //public TextMeshProUGUI healthText;

    public Slider slider;
    public float health = 10;

    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        //healthText.text = "Health: " + health;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        string otherTag = collision.gameObject.tag;
        
        if (otherTag == "ObjectDamage")
        {
            health -= 2;
            if (health <= 0)
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
        else if (otherTag == "Enemy1")
        {
            health -= 0.1f;
            slider.value = health;
    
            if (health <= 0)
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
        //else if (otherTag == "EBulletDamage")
        //{
            //health -= 4;
            //if (health <= 0)
            //{
                //Scene scene = SceneManager.GetActiveScene();
                //SceneManager.LoadScene(scene.name);
            //}
        //}
        
    }
}
