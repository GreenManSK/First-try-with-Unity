using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StarSkyController : MonoBehaviour
{

    public List<TileBase> tiles;
    public int width;
    public int height;

    private HashSet<TileBase> bag;
    
    // Start is called before the first frame update
    void Start()
    {
        var tilemap = GetComponent<Tilemap>();
        if (tilemap)
        {
            GenerateStars(tilemap);
        }
    }

    private void GenerateStars(Tilemap tilemap)
    {
        for (var x = -width/2; x < width/2; x++)
        {
            for (var y = -height/2; y < height/2; y++)
            {
                tilemap.SetTile(new Vector3Int(x,y,0), GetRandomTile());
            }
        }
    }

    private TileBase GetRandomTile()
    {
        if (bag == null || bag.Count == 0)
        {
            bag = new HashSet<TileBase>(tiles);
        }

        var tile = bag.ElementAt(Random.Range(0, bag.Count - 1));
        bag.Remove(tile);
        return tile;
    }
}
