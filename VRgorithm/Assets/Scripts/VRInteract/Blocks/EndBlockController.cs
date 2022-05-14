using UnityEngine;

namespace VRInteract.Blocks
{
    public class EndBlockController : BlockController
    {
        [SerializeField] private InConnector inConnector;
        [SerializeField] private EndBlock endBlock;
        public override IBlock Block => endBlock;
        private void Start()
        {
            inConnector.OnConnect += OnInConnected;
            inConnector.OnDisConnect += OnInDisconnected;
        }

        private void OnInConnected(OutConnector connector)
        {
            endBlock.prev.Add(connector.Block);
        }
        private void OnInDisconnected(OutConnector connector)
        {
            endBlock.prev.Remove(connector.Block);
        }
    }
}