using UnityEngine;

namespace EFT.UI
{
    public sealed class RandomMaterialChanger : MonoBehaviour
    {
        [Header("Materials list")]
        [SerializeField]
        private Material[] _materials;

        [Header("Material change on start")]
        [SerializeField]
        private bool _changeOnStart = true;

        [Header("Material change on object activation")]
        [SerializeField]
        private bool _changeOnEnable;

        private Renderer _objectRenderer;

        private void Awake()
        {
            _objectRenderer = GetComponent<Renderer>();
        }

        private void Start()
        {
            if (_changeOnStart)
                ChangeMaterial();
        }

        private void OnEnable()
        {
            if (_changeOnEnable)
                ChangeMaterial();
        }

        public void ChangeMaterial()
        {
            if (_objectRenderer == null)
                _objectRenderer = GetComponent<Renderer>();

            if (_objectRenderer == null || _materials == null || _materials.Length == 0)
                return;

            Material randomMaterial = _materials[Random.Range(0, _materials.Length)];

            if (randomMaterial == null)
                return;

            _objectRenderer.material = randomMaterial;
        }

        public RandomMaterialChanger()
        {
        }
    }
}