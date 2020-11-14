using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeBoost : MonoBehaviour
{
    public float boostDuration = 5;

    private float boostTimer, OriginalBaseSpeed;
    private bool boosting;
    private PlayerMove MyPlayer;

    // Awake is called before Start
    void Awake()
    {
        boostTimer = 0;
        boosting = false;
        MyPlayer = FindObjectOfType<PlayerMove>();
    }
    // Start is called before the first frame update
    void Start()
    {
        OriginalBaseSpeed = MyPlayer.BaseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (boosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= boostDuration)
            {
                boostTimer = 0;
                MyPlayer.BaseSpeed = OriginalBaseSpeed;
                boosting = false;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "coffee")
        {
            boosting = true;
            MyPlayer.BaseSpeed = OriginalBaseSpeed*2;
        }
    }
}
