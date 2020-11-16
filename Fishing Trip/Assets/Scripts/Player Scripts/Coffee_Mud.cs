using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee_Mud : MonoBehaviour
{
    private float boostDuration = 5;
    public float BaseChange = 0, AlterChange = 0; //do not change, used to prevent a glitch with speed changing while coffee is applied
    private float boostTimer = 0, OriginalBaseSpeed, OriginalAlterSpeed;
    private bool boosting = false, slow = false;
    private PlayerMove MyPlayer;

    // Awake is called before Start
    void Awake()
    {
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
                if(!slow)//if coffee wears off outside of mud calculate new base speed
                {
                    MyPlayer.BaseSpeed = OriginalBaseSpeed + BaseChange;
                    MyPlayer.AlterSpeed = OriginalAlterSpeed + AlterChange;
                    BaseChange = 0;
                    AlterChange = 0;
                }
                else//if coffee wears off inside of mud, adjust current speed
                {
                    MyPlayer.BaseSpeed = MyPlayer.BaseSpeed / 2;
                    MyPlayer.AlterSpeed = MyPlayer.AlterSpeed / 2;
                }
                boosting = false;
            }

        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "coffee")
        {
            boosting = true;
            if (!slow) //if get coffee, save original speed and adjust speed.
            {
                OriginalBaseSpeed = MyPlayer.BaseSpeed;
                OriginalAlterSpeed = MyPlayer.AlterSpeed;
                MyPlayer.BaseSpeed = OriginalBaseSpeed * 2;
                MyPlayer.AlterSpeed = OriginalAlterSpeed * 2;
            }
            else if (boosting)//if get coffee and already boosting, reset timer.
            {
                boostTimer = 0;
            }
            else //if get coffee while in mud, adjust current speed.
            {
                MyPlayer.BaseSpeed = MyPlayer.BaseSpeed * 2;
                MyPlayer.AlterSpeed = MyPlayer.AlterSpeed * 2;
            }
        }

        else if (other.tag == "Mud")
        {
            slow = true;
            if (!boosting)// if enter mud, save original speed and adjust speed
            {
                OriginalBaseSpeed = MyPlayer.BaseSpeed;
                OriginalAlterSpeed = MyPlayer.AlterSpeed;
                MyPlayer.BaseSpeed = OriginalBaseSpeed / 2;
                MyPlayer.AlterSpeed = OriginalAlterSpeed / 2;
            }
            else// if enter mud while boosting, adjust current speed.
            {
                MyPlayer.BaseSpeed = MyPlayer.BaseSpeed / 2;
                MyPlayer.AlterSpeed = MyPlayer.AlterSpeed / 2;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Mud")
        {
            slow = false;
            if (!boosting)// if leave mud, restore original speed with any speed increases from time progression, and set speed increases from time to 0
            {
                MyPlayer.BaseSpeed = OriginalBaseSpeed + BaseChange;
                MyPlayer.AlterSpeed = OriginalAlterSpeed + AlterChange;
                BaseChange = 0;
                AlterChange = 0;
            }
            else// if leave mud and boosting, calculate new current speed in case of speed change due to time
            {
                MyPlayer.BaseSpeed = OriginalBaseSpeed * 2 + BaseChange;
                MyPlayer.AlterSpeed = OriginalAlterSpeed * 2 + AlterChange;
                // not multiplying the speed increase from progression to be consistent with the functionality of the speed increase occuring while boosting
            }
        }
    }
}
