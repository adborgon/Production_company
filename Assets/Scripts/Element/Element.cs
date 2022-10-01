using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Element
{
    [Serializable]
    public abstract class Element
    {
        [SerializeField] protected string _id;
        public string id => _id;
        [SerializeField] protected bool _available = true;

        public abstract void Init(int id);

        public virtual void Release()
        {
            _available = true;
        }

        public virtual void Assign(Step.Step step = null)
        {
            _available = false;
        }

        public virtual bool isRealised()
        {
            return _available;
        }
    }
}