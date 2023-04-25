using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour
{
    public Transform TranslatePositon;
    public string transferMapName;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
           player = FindObjectOfType<Player>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("portal"))
        {
            SceneManager.LoadScene("WTF");
        }

        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(transferMapName);
        }
    }
}