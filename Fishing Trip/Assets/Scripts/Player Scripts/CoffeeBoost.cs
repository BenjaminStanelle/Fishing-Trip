using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeBoost : MonoBehaviour
{
    private float boostDuration = 5;
    public float CoffeeBaseChange = 0, CoffeeAlterChange = 0; //do not change, used to prevent a glitch with speed changing while coffee is applied
    private float boostTimer, OriginalBaseSpeed, OriginalAlterSpeed;
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
                MyPlayer.BaseSpeed = OriginalBaseSpeed + CoffeeBaseChange;
                MyPlayer.AlterSpeed = OriginalAlterSpeed + CoffeeAlterChange;
                boosting = false;
            }

        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "coffee")
        {
            boosting = true;
            OriginalBaseSpeed = MyPlayer.BaseSpeed;
            OriginalAlterSpeed = MyPlayer.AlterSpeed;
            MyPlayer.BaseSpeed = OriginalBaseSpeed *2 ;
            MyPlayer.AlterSpeed = OriginalAlterSpeed * 2;
        }
    }
}
