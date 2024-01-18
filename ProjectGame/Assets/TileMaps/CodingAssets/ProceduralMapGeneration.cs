using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Tilemaps;

public class ProceduralMapGeneration : MonoBehaviour
{


    public Tilemap grid;
    public Tile tile1;

    public int MapX;
    public int MapY;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = -(MapX/2); x < (MapX/2); x++) 
        {

            for (int y = -(MapY/2); y < (MapY/2); y++) 
            {
                grid.SetTile(new Vector3Int(x, y, 0), tile1);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
