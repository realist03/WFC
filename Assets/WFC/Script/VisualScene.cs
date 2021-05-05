using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class VisualScene : MonoBehaviour
{
    public int VisualCounts = 64;
    public Material Material;
    public bool isEditor;
    public WFC wfc;
    List<GameObject> renderList;
    Tile selectTile;
    Dictionary<Vector3, Tile> tileDic;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isEditor)
        {
            wfc.InitTile(VisualCounts);
            tileDic = wfc.tileDic;
            RenderTile();
        }
        else
        {
            ClearRender();
        }
        CheckMouse();
    }

    private void CheckMouse()
    {
        RaycastHit hit;
        Camera sceneCam;
        if(Camera.current != null)
        {
            sceneCam = Camera.current;
        }
        else
        {
            sceneCam = SceneView.lastActiveSceneView.camera;
        }
        //Debug.Log(sceneCam);
        Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
        Debug.DrawRay(ray.origin, ray.direction*10);
        if (Physics.Raycast(ray, out hit))
        {
            tileDic.TryGetValue(hit.transform.position - Vector3.one * 0.5f, out selectTile);
        }

        if (selectTile != null && !selectTile.isFill && Input.GetMouseButtonDown(0))
        {
            wfc.Generate(selectTile);
        }
    }

    private void RenderTile()
    {
        if (renderList == null)
        {
            renderList = new List<GameObject>();
        }

        if (renderList.Count > 0) return;

        foreach (var item in tileDic)
        {
            item.Value.tileObject.transform.position = item.Value.pivotPostion;
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.layer = LayerMask.NameToLayer("WFC");
            cube.transform.SetParent(item.Value.tileObject.transform);
            cube.transform.localPosition = Vector3.zero;
            cube.transform.localScale = Vector3.one * 0.9f;
            renderList.Add(cube);
            //cube.GetComponent<Collider>().enabled = false;
            cube.GetComponent<MeshRenderer>().sharedMaterial = Material;
        }

    }

    private void ClearRender()
    {
        if (renderList == null) return;
        foreach (var item in renderList)
        {
            DestroyImmediate(item);
        }
        renderList.Clear();

        if (tileDic == null) return;
        foreach (var item in tileDic)
        {
            DestroyImmediate(item.Value.tileObject);
        }
        tileDic.Clear();
    }

    private void OnDisable()
    {
        ClearRender();
    }

    private void OnDrawGizmos()
    {
        if (selectTile != null)
        {
            Gizmos.DrawWireCube(selectTile.pivotPostion, Vector3.one * 0.95f);
        }
    }
}
