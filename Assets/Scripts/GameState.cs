using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; } = null;
    public bool pauseBool = false;
    public int playerHealth;
    public GameObject playerObject;
    public GameObject pauseCanvas;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        /*if (Time.timeScale == 1 && pauseBool)
        {
            PauseGame();
        }
        if (Time.timeScale == 0 && !pauseBool)
        {
            ResumeGame();
        }*/
        if (Input.GetKeyDown("p") && Time.timeScale == 1)
        {
            pauseBool = true;
            PauseGame();
        }
        if (Input.GetKeyUp("p") && Time.timeScale == 0)
        {
            //pauseBool = false;
            //ResumeGame();
        }
    }
    public void PauseGame ()
    {
        playerObject.GetComponent<FPSController>().canLook = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseCanvas.SetActive(true);
        Time.timeScale = 0;
        //Debug.Log("Paused");
    }
    public void ResumeGame ()
    {
        playerObject.GetComponent<FPSController>().canLook = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    
}
