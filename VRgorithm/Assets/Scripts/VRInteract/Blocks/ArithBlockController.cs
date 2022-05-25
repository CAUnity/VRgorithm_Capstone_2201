using UnityEngine;
using VRInteract.Operands;

namespace VRInteract.Blocks
{
    public class ArithBlockController : BlockController
    {
        [SerializeField] private InConnector inConnector;
        [SerializeField] private OutConnector outConnector;
        [SerializeField] private ArithBlock arithBlock;
        [SerializeField] private VariableController leftVar, rightVar;
        [SerializeField] private AssignVariableController result;
        [SerializeField] private ArithOperandController operand;
        
        public override IBlock Block => arithBlock;
        private void Awake()
        {
            inConnector.OnConnect += OnInConnected;
            inConnector.OnDisConnect += OnInDisconnected;
            
            outConnector.OnConnect += OnOutConnected;
            outConnector.OnDisConnect += OnOutDisconnected;

            leftVar.OnUpdate += OnLeftVarUpdate;
            rightVar.OnUpdate += OnRightVarUpdate;
            operand.OnUpdate += OnOperandUpdate;
            result.OnUpdate += OnResultUpdate;
        }
        
        private void OnInConnected(OutConnector connector)
        {
            arithBlock.prev.Add(connector.Block);
        }
        private void OnInDisconnected(OutConnector connector)
        {
            arithBlock.prev.Remove(connector.Block);
        }
        private void OnOutConnected(InConnector connector)
        {
            arithBlock.next = connector.Block;
        }
        private void OnOutDisconnected()
        {
            arithBlock.next = null;
        }

        private void OnLeftVarUpdate(IntVariable variable)
        {
            arithBlock.lhs = variable;
        }
        private void OnRightVarUpdate(IntVariable variable)
        {
            arithBlock.rhs = variable;
        }
        private void OnOperandUpdate(IArithOperator arith)
        {
            arithBlock.arith = arith;
        }
        private void OnResultUpdate(IntVariable variable)
        {
            arithBlock.ret = variable;
        }
    }
}