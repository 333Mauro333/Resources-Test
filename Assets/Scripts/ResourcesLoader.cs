using UnityEngine;


namespace ResourcesTest
{
    public class ResourcesLoader : MonoBehaviour
    {
        [Header("Input Configuration")]
        [SerializeField] KeyCode keyToLoad = KeyCode.None;
        [SerializeField] KeyCode keyToUnload = KeyCode.None;


        GameObject column; // Objeto que va a guardar la columna.



        void Awake()
        {
            column = null;
        }

		void Update()
		{
            if (Input.GetKeyDown(keyToLoad))
			{
                LoadResources();
			}
            
            if (Input.GetKeyDown(keyToUnload))
			{
                UnloadAssets();
			}
		}



        void LoadResources()
		{
            // Si el objeto en la escena no existe...
            if (column == null)
            {
                GameObject loadedAsset = Resources.Load<GameObject>("Prefabs/Column"); // Guardo la referencia al
                                                                                       // asset en una variable.


                column = Instantiate(loadedAsset); // Se crea una instancia de la columna, la cual se guarda en el
                                                   // campo "column".

                column.transform.position = new Vector3(0.0f, column.transform.localScale.y / 2.0f, 0.0f); // Se ajusta la
                                                                                                           // posición.
            }
        }

        void UnloadAssets()
		{
            // Si la columna existe...
            if (column != null)
			{
                Destroy(column); // Se destruye.

                // Libera recursos que no estén en uso.
                Resources.UnloadUnusedAssets();
            }
        }
	}
}
