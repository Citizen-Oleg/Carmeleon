using System.Collections.Generic;
using UnityEngine;

namespace Loot
{
    public class ReagentPool : MonoBehaviour
    {
        [SerializeField]
        private Transform _containerReagent;
        [SerializeField]
        private List<Reagent> _reagents = new List<Reagent>();

        private readonly Dictionary<int, MonoBehaviourPool<Reagent>> _reagentPool =
            new Dictionary<int, MonoBehaviourPool<Reagent>>();

        private void Awake()
        {
            for (int i = 0; i < _reagents.Count; i++)
            {
                _reagents[i].ID = i;
            }
            
            foreach (var reagent in _reagents)
            {
                var pool = new MonoBehaviourPool<Reagent>(reagent, _containerReagent);
                _reagentPool.Add(reagent.ID, pool);
            }
        }

        public Reagent GetReagent(Reagent reagent)
        {
            if (_reagentPool.ContainsKey(reagent.ID))
            {
                return _reagentPool[reagent.ID].Take();
            }
           
            var pool = new MonoBehaviourPool<Reagent>(reagent, _containerReagent);
            _reagentPool.Add(reagent.ID, pool);
            return _reagentPool[reagent.ID].Take();
        }

        public void ReleaseReagent(Reagent reagent)
        {
            _reagentPool[reagent.ID].Release(reagent);
        }
    }
}