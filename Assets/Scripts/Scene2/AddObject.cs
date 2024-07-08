using UnityEngine;

    internal class AddObject: MonoBehaviour
    {
        private Transform _transform;
        private MeshRenderer _meshRenderer;
        System.Random rndPos = new System.Random();
        public AddObject(GameObject gameObject)
        {
            _transform = gameObject.transform;
            _transform.position = new Vector3(rndPos.Next(-25, 0), 2.0f, rndPos.Next(-25, 25));
            //Instantiate(gameObject, _transform);
            Instantiate <GameObject>(gameObject, _transform);
        }
    }
