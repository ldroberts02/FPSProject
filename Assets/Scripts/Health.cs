using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int healthNum;
    void Start()
    {
        
    }


    void Update()
    {
        if (healthNum <= 0)
        {
            OnDeath();
        }
    }
    public void Heal(GameObject target, int HealAmt)
    {
        if (target != null)
        {
            if (target.GetComponent<Health>() != null)
            {
                target.GetComponent<Health>().healthNum = target.GetComponent<Health>().healthNum + Mathf.Abs(HealAmt); // absolute value of healamount so you can't use this function as a health remover
            }
        }
        if (target.name == "Player")
        {
            //target.GetComponent<FPSController>().hurtBool = true;
        }
    }
    public void Damage(GameObject target, int DamageAmt)
    {
        if (target != null)
        {
            if (target.GetComponent<Health>() != null)
            {
                target.GetComponent<Health>().healthNum = target.GetComponent<Health>().healthNum - DamageAmt;
            }
        }
        if (target.name == "Player")
        {
            target.GetComponent<FPSController>().hurtBool = true;
        }
        if (target.tag == "Enemy")
        {
            target.GetComponent<EnemyBehavior>().hurtBool = true;
        }
    }
    void OnDeath()
    {
        if(this.tag == "Enemy")
        {
            this.GetComponent<EnemyBehavior>().dead = true;
            Destroy(this.gameObject);
        }
        else if (this.name == "Player")
        {
            SceneManager.LoadSceneAsync("Test Scene");
        }
    }
}
