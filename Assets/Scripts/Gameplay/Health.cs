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
                SoundManager.Instance.PlaySound(5);
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
            if (target.transform.parent.GetComponent<Health>() != null)
            {
                target.transform.parent.GetComponent<Health>().healthNum = target.transform.parent.GetComponent<Health>().healthNum - DamageAmt;
            }
        }
        if (target.name == "Player")
        {
            target.GetComponent<FPSController>().hurtBool = true; //error here?
            SoundManager.Instance.PlaySound(3);
        }
        if(target.name == "Player Capsule")
        {
            target.transform.parent.GetComponent<FPSController>().hurtBool = true;
            SoundManager.Instance.PlaySound(3);
        }
        if (target.tag == "Enemy")
        {
            target.GetComponent<EnemyBehavior>().hurtBool = true;

            SoundManager.Instance.PlaySound(4);
        }
        
    }
    void OnDeath()
    {
        if(this.tag == "Enemy")
        {
            this.GetComponent<EnemyBehavior>().dead = true;
            SoundManager.Instance.PlaySound(1);
            Destroy(this.gameObject);
        }
        else if (this.name == "Player")
        {
            SceneManager.LoadSceneAsync("Game Scene");
            //PlayerDeath.OnDeath();
        }
    }
}
