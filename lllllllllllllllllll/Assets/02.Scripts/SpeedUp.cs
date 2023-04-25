using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Item
{
    public override void DestroyAfterTime()
    {
        Invoke("DestroyThis", 10.0f);
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }
    public override void ApplyItem()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
