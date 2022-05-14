using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace VRInteract.Blocks
{
    public class StartBlockController : BlockController
    {
        [SerializeField] private OutConnector outConnector;
        [SerializeField] private StartBlock startBlock;
        public override IBlock Block => startBlock;

        private void Start()
        {
            outConnector.OnConnect += OnOutConnected;
            outConnector.OnDisConnect += OnOutDisconnected;
        }

        private void OnOutConnected(InConnector connector)
        {
            startBlock.next = connector.Block;
        }
        private void OnOutDisconnected()
        {
            startBlock.next = null;
        }
    }
}