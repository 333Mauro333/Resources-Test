using UnityEngine;


namespace ResourcesTest
{
	public class ColumnScript : MonoBehaviour
	{
		Renderer r;
		Material materialAsset;



		void Awake()
		{
			r = GetComponent<Renderer>();

			LoadResources();
		}

		void OnDestroy()
		{
			UnloadResources();
		}



		void LoadResources()
		{
			Material materialAsset = Resources.Load<Material>("Materials/Column");


			materialAsset.mainTextureScale = new Vector2(1, 5);

			r.material = materialAsset;
		}

		void UnloadResources()
		{
			Resources.UnloadAsset(materialAsset);
		}
	}
}
