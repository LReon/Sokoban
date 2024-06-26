using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManagerScript : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject boxPrefab;

    int[,] map;

    GameObject[,] field;
   

    //void PrintArray()
    //{
    //    string debugText = "";
    //    for (int i = 0; i < map.Length; i++)
    //    {
    //        debugText += map[i].ToString() + ",";
    //    }
    //    Debug.Log(debugText);
    //}


   

    private  Vector2Int GetPlayerIndex()
    {
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                if (field[y, x] == null) { continue; }
                if (field[y,x].tag == "Player")
                {
                    return new Vector2Int(x, y);
                }
           
               
            }
        }
        return new Vector2Int(-1,-1);
    }


    bool MoveNumber(Vector2Int moveFrom,Vector2Int moveTo) { 
        if(moveTo.x < 0 || moveTo.x >= field.GetLength(0)) { return false; }
        {

            return false;
        }
        if (moveTo.y < 0 || moveTo.y >= field.GetLength(2)) { return false; }
        {

            return false;
        }

        if (field[moveTo.y,moveTo.x] != null && field[moveTo.y,moveTo.x].tag == "Box")
        {
            Vector2Int velocity = moveTo - moveFrom;
            bool success = MoveNumber(moveTo, moveTo + velocity);
            if(!success)
            {
                return false;
            }
        }

        field[moveTo.x,moveTo.y] = field[moveFrom.y,moveFrom.x];
        field[moveFrom.x,moveFrom.y] = null;
        field[moveFrom.y, moveFrom.x].transform.position = new Vector3(moveTo.x, map.GetLength(0) - moveTo.y, 0);
        return true;
    }

    bool IsCleard()
    {
        List<Vector2Int> goals = new List<Vector2Int>();
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 3)
                {
                    goals.Add(new Vector2Int(x, y));
                }
            }
        }
    
        for (int i = 0; i < goals.Count; i++)
        {
            GameObject f = field[goals[i].y, goals[i].x];
            if(f == null || f.tag != "Box")
            {
                return false;
            }
            
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        


        map = new int[,]{
        {0,0,0,2,0 },
        {1,0,2,0,0 },
        {0,0,0,0,2 }
    };
        field = new GameObject[map.GetLength(0), map.GetLength(1)];

        string debugText = "";

        for (int y = 0;y < map.GetLength(0); y++)
        {
            for(int x = 0;x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    field[y,x] = Instantiate(playerPrefab,new Vector3(x,map.GetLength(0) - y,0), Quaternion.identity);
                }
                if (map[y, x] == 2)
                {
                    field[y, x] = Instantiate(boxPrefab, new Vector3(x, map.GetLength(0) - y, 0), Quaternion.identity);
                }

                debugText += map[y, x].ToString() + ",";
            }
            debugText += "\n";
        }

        Debug.Log(debugText);

        //map = new int[] { 0,0,2,1,0,2,0,0,0};
        // PrintArray();



    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector2Int playerIndex = GetPlayerIndex();
            MoveNumber(playerIndex,playerIndex + new Vector2Int(1,0));
        }
    }
}
