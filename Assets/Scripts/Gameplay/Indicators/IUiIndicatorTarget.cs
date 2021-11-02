using System;
using UnityEngine;

namespace Gameplay.Indicators
{
    public interface IUiIndicatorTarget
    {
        event Action BeforeDestroy;
        
        Vector3 IndicatorPivot { get; }
    }
}