﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeManager : MonoBehaviour
{
    public GridManager gridScript;
    int yMin;
    int yMax;
    int xMin;
    int xMax;
    public GameObject [,] slimeTile;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateSlime(){
        yMin = gridScript.myxoMinPosY;
        yMax = gridScript.myxoMaxPosY;
        xMin = gridScript.myxoMinPosX;
        xMax = gridScript.myxoMaxPosX;
        slimeTile = new GameObject[40, 40];
        GameObject referenceSlime = (GameObject)Instantiate(Resources.Load("myxoTile"));
        //  for (int row = 0; row < gridScript.rows; row++)
        // {
        //     for (int col = 0; col < gridScript.cols; col++)
        //     {
        //         if (col >= xMin && row >= yMin && col <= xMax && row <= yMax){
        //             slimeTile[col,row] = (GameObject)Instantiate(referenceSlime, transform, false);
        //             slimeTile[col,row].transform.SetParent(referenceSlime.transform, false);
        //             slimeTile[col,row].name = "slimeTile [" + col + "," + row + "]";

        //             float posX = col * gridScript.tileSize;
        //             float posY = row * -gridScript.tileSize;
        //             slimeTile[col,row].transform.position = new Vector2(posX, posY);
        //         }
            // }
        // }
        for (int col = xMin; col <= xMax; col++){
            //Debug.Log(xMin);
            for (int row = yMin; row <= yMax; row++){
                slimeTile[col,row] = (GameObject)Instantiate(referenceSlime, new Vector2(gridScript.tile[col,row].transform.position.x,gridScript.tile[col,row].transform.position.y), Quaternion.identity);
                 slimeTile[col,row].transform.SetParent(gridScript.gameObject.transform, true);
                slimeTile[col,row].name = "slimeTile [" + col + "," + row + "]";
                Debug.Log(gridScript.tile[col,row]);
                slimeTile[col,row].transform.position = gridScript.tile[col,row].transform.position;
            }
        }
        Destroy(referenceSlime);
    }
}
