using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    int[] map;


    void PrintArray()
    {
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int playerIndex = -1;


            for(int i = 0; i < map.Length; i++)
            {
                if (map[i] == 1)
                {
                    playerIndex = i;
                    break;
                }
            }
            if(playerIndex < map.Length -1)
            {
                map[playerIndex + 1] = 1;
                map[playerIndex] = 0;
            }
            string debugText = "";
            for(int i = 0; i < map.Length;i++)
            {
                debugText += map[i].ToString() + ",";
            }
            Debug.Log(debugText);
        }

       

    }
}
