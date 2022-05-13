using UnityEngine;

namespace VRInteract
{
    public abstract class BlockController : MonoBehaviour
    {
        public abstract IBlock Block { get; }
    }
}