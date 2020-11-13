using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoad : MonoBehaviour
{

    public Terrain terrain;
    public GameObject ColisionObject;

    private float terrainWidth;
    private float terrainLength;
    public float yOffset = 10f;
    private float xTerrainPos;
    private float zTerrainPos;

    // Start is called before the first frame update
    void Start()
    {
        //Get terrain size
        terrainWidth = terrain.terrainData.size.x;
        terrainLength = terrain.terrainData.size.z;

        //Get terrain position
        xTerrainPos = terrain.transform.position.x;
        zTerrainPos = terrain.transform.position.z;
        for (int i = 0; i < 100; i++)
        {
            generateObjectOnTerrain(i);
        }

    }
    void generateObjectOnTerrain(int i)
    {
        //Generate random x,z,y position on the terrain
        float randX = UnityEngine.Random.Range(xTerrainPos, xTerrainPos + (terrainWidth ));
        float randZ = UnityEngine.Random.Range(zTerrainPos, zTerrainPos + (terrainLength));
        float yVal = Terrain.activeTerrain.SampleHeight(new Vector3(randX, 0, randZ));

        //Apply Offset if needed
        yVal = yVal + yOffset;

        //Generate the Prefab on the generated position
        var CreatedCaret = (GameObject)Instantiate(ColisionObject, new Vector3(randX, 0, randZ), Quaternion.identity);        
    }
}
