using System;
using UnityEngine;

namespace VRInteract
{
    public abstract class BlockConnector : MonoBehaviour
    {
        [SerializeField] protected BlockController blockController;
        public IBlock Block => blockController.Block;
        public BlockController BlockController => blockController;

    }
}