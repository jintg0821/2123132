using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
   
        // Start is called before the first frame update
        

    

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetKeyDown(KeyCode.F4))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        
       

            if (Input.GetKeyDown(KeyCode.Escape)) 
            {
                Application.Quit();
            }
        
    }
}
