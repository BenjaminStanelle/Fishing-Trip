using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public float waitSecs;
    // Start is called before the first frame update

    void OnBecameInvisible()
    {
        Destroy(this.gameObject, waitSecs); //second variable is time to wait before destroying, in seconds.
    }
}
