using UnityEngine;
using System.Collections;

public class TerrainGenerator : MonoBehaviour
{
    public static TerrainGenerator Instance { get; private set; }

	float scale = 100f;
	int wide = 100;
	int deep = 10;
	public Material mat;
    GameObject cubesParent;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
    }

	public void Generate ()
	{
		cubesParent = new GameObject("cubesParent");
		cubesParent.transform.parent = GameManager.Instance.sceneParent;

		Random.seed = 42;

		for (int i = -wide / 2; i <  wide / 2; i++)
		{
			for (int j = -deep / 2; j <  deep / 2; j++)
			{
				GameObject newGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
				newGO.transform.position = new Vector3(i * scale, Random.Range(-6f, 0f) - 5.5f, j * scale);
				newGO.transform.localScale = new Vector3(scale, 10f, scale);
				newGO.renderer.material = mat;
				newGO.transform.parent = cubesParent.transform;
			}
		}
	}
}
