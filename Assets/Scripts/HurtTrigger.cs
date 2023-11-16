using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class HurtTrigger : MonoBehaviour
{
    public GameObject playerEntity;
    public Health Health;
    public GameObject healthEntity;
    public GameObject doorObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(this.name == "Slime")
        {
            if (collision.gameObject.name == "Player")
            {
                Health.Damage(playerEntity, 5);
            }
        }
        if(this.name == "Health")
        {
            if (collision.gameObject.name == "Player")
            {
                
                Health.Heal(playerEntity, 100);
                Destroy(healthEntity);
            }
        }
        if(this.name == "TriggerLeave")
        {
            SceneManager.LoadSceneAsync("Main Menu");
        }
        if(this.name == "Door Trigger")
        {
            Destroy(doorObject);
        }
    }
}
