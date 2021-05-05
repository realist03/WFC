using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WFC : MonoBehaviour
{
    public List<Module> Modules;
    public Dictionary<Vector3, Tile> tileDic;

    void Start()
    {

    }

    void Update()
    {

    }

    private void InitWFC()
    {

    }

    private List<Module> CheckNeighbors(Tile tile)
    {
        List<Module> adaptModules = new List<Module>();
        foreach (var item in tile.neibors)
        {
            if(item == null) continue;
            foreach (var module in Modules)
            {
                if(item.up && module.up)
                {
                    adaptModules.Add(module);
                }
                else if(item.down && module.down)
                {
                    adaptModules.Add(module);
                }
                else if(item.left && module.left)
                {
                    adaptModules.Add(module);
                }
                else if(item.right && module.right)
                {
                    adaptModules.Add(module);
                }
                else if(item.forward && module.forward)
                {
                    adaptModules.Add(module);
                }
                else if(item.back && module.back)
                {
                    adaptModules.Add(module);
                }

            }
        }
        return adaptModules;
    }

    public void InitTile(int VisualCounts)
    {
        if (tileDic == null)
        {
            tileDic = new Dictionary<Vector3, Tile>();
        }

        if (tileDic.Count > 0) return;

        int length = (int)Mathf.Pow(Mathf.Abs(VisualCounts), 1f / 3f);

        for (int z = -length; z < length; z++)
        {
            for (int y = -length; y < length; y++)
            {
                for (int x = -length; x < length; x++)
                {
                    Vector3 centerPos = new Vector3(x, y, z) + new Vector3(0, length, 0);
                    Tile tile = new Tile(centerPos);
                    tile.tileObject = new GameObject();
                    tile.tileObject.transform.SetParent(transform);
                    tile.tileObject.name = "tile_" + x + y + z;
                    tileDic.Add(centerPos, tile);
                }
            }
        }
        InitTileNeighbors();
    }

    public void InitTileNeighbors()
    {
        foreach (var item in tileDic)
        {
            item.Value.neibors.Add(GetNeighborPos(item.Value, Vector3.up));
            item.Value.neibors.Add(GetNeighborPos(item.Value, Vector3.down));
            item.Value.neibors.Add(GetNeighborPos(item.Value, Vector3.left));
            item.Value.neibors.Add(GetNeighborPos(item.Value, Vector3.right));
            item.Value.neibors.Add(GetNeighborPos(item.Value, Vector3.forward));
            item.Value.neibors.Add(GetNeighborPos(item.Value, Vector3.back));
        }
    }

    Tile GetNeighborPos(Tile tile, Vector3 towards)
    {
        Tile neighbor;
        tileDic.TryGetValue(tile.centerPostion + towards, out neighbor);
        if(neighbor == null)
        {
            if(towards == Vector3.up)
            {
                tile.up = false;
            }
            if(towards == Vector3.down)
            {
                tile.down = false;
            }
            if(towards == Vector3.left)
            {
                tile.left = false;
            }
            if(towards == Vector3.right)
            {
                tile.right = false;
            }
            if(towards == Vector3.forward)
            {
                tile.forward = false;
            }
            if(towards == Vector3.back)
            {
                tile.back = false;
            }
        }
        return neighbor;
    }

    public void Generate(Tile tile)
    {
        List<Module> adptModules = CheckNeighbors(tile);
        int r = Random.Range(0, adptModules.Count);
        Module selectModule = adptModules[r];
        GameObject.Instantiate(selectModule, tile.tileObject.transform);
        tile.isFill = true;
        tile.up = selectModule.up;
        tile.down = selectModule.down;
        tile.left = selectModule.left;
        tile.right = selectModule.right;
        tile.forward = selectModule.forward;
        tile.back = selectModule.back;

    }
}
