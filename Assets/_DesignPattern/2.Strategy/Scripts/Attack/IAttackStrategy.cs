﻿

namespace Strategy
{
    using UnityEngine;


    public interface IAttackStrategy
    {
        void Attack(Transform transform);
    }
}