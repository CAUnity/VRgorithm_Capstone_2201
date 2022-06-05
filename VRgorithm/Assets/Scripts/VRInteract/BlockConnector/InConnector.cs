using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRInteract
{
    public class InConnector : BlockConnector
    {
        private readonly List<OutConnector> _connectedList  = new List<OutConnector>();
        private readonly Dictionary<OutConnector, Coroutine> _coroutineDict = new Dictionary<OutConnector, Coroutine>();
        public event Action<OutConnector> OnConnect = delegate {};
        public event Action<OutConnector> OnDisConnect = delegate {};
        
        public void Connect(OutConnector connector)
        {
            _connectedList.Add(connector);
            OnConnect(connector);
        }
        public void DisConnect(OutConnector connector)
        {
            _connectedList.Remove(connector);
            OnDisConnect(connector);
        }
    }
}