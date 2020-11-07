using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelfDestroy : MonoBehaviour
{
    public float waittime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnBecameInvisible()
    {
        yield return new WaitForSecondsRealtime(waittime);
        Destroy(this.gameObject);
    }


}
