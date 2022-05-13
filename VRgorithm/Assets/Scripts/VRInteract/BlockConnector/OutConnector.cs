using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace VRInteract
{
    public class OutConnector : BlockConnector
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private float checkDist;
        [SerializeField] private LayerMask layerMask;
        public InConnector Connected { get; private set; }
        public event Action<InConnector> OnConnect = delegate {};
        public event Action OnDisConnect = delegate {};
        private Coroutine _lineRoutine;
        private Vector3 _pointPosition;
 
        public void OnSelectEnter(SelectEnterEventArgs eventArgs)
        {
            if (Connected != null)
            {
                Connected.DisConnect(this);
                DisConnect();
            }
            _lineRoutine = StartCoroutine(LineConnectingRoutine(eventArgs.interactorObject.transform.GetComponent<LineRenderer>()));
        }

        public void OnSelectExit(SelectExitEventArgs eventArgs)
        {
            StopCoroutine(_lineRoutine);
            var find = Physics.OverlapSphere(_pointPosition, checkDist, layerMask)
                .FirstOrDefault(v => v.TryGetComponent<InConnector>(out var hit));
            
            if (find != null)
            {
                var connector = find.GetComponent<InConnector>();
                Connect(connector);
                connector.Connect(this);
                DrawLine(connector.transform.position);
                StartCoroutine(LineMaintainRoutine());
            }
            else
            {
                DrawLine(transform.position);
            }
        }

        private void Connect(InConnector inConnector)
        {
            Connected = inConnector;
            OnConnect(inConnector);
        }
        private void DisConnect()
        {
            Connected = null;
            OnDisConnect();
        }
        
        private void DrawLine(Vector3 endPoint)
        {
            lineRenderer.SetPosition(0,transform.position);
            lineRenderer.SetPosition(1,endPoint);
        }
        private IEnumerator LineConnectingRoutine(LineRenderer line)
        {
            while (true)
            {
                _pointPosition = line.GetPosition(1);
                DrawLine(_pointPosition);
                yield return null;
            }
        }

        private IEnumerator LineMaintainRoutine()
        {
            while (Connected != null)
            {
                DrawLine(Connected.transform.position);
                yield return null;
            }
            DrawLine(transform.position);
        }
    }
}

