using System.Collections.Generic;
using Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

namespace VRInteract
{
    public class BlockBuilder : MonoSingleton<BlockBuilder>
    {
        [SerializeField] private Transform tray;
        [SerializeField] private Transform environment;
        [Header("Prefabs")]
        [SerializeField] private GameObject blockButtonPrefab;
        [SerializeField] private List<GameObject> blockPrefabs;

        private void Awake()
        {
            foreach (var prefab in blockPrefabs)
            {
                AddBuildButton(prefab);
            }
        }
        public void SetPos(Vector3 worldPos)
        {
            transform.position = worldPos;
        }
        private void AddBuildButton(GameObject go)
        {
            var buttonInstance = Instantiate(blockButtonPrefab,tray);
            var btn = buttonInstance.GetComponent<Button>();
            var textUI = buttonInstance.GetComponentInChildren<TextMeshProUGUI>();
            btn.onClick.AddListener(() => BuildBlock(go));
            textUI.text = go.name;
        }

        private void BuildBlock(GameObject go)
        {
            Instantiate(go,environment).transform.position = transform.position + Vector3.up;
        }
    }
}

