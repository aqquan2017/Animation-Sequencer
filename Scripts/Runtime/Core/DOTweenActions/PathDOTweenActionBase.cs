using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace BrunoMikoski.AnimationSequencer
{
    [Serializable]
    public abstract class PathDOTweenActionBase : DOTweenActionBase
    {
        public override Type TargetComponentType => typeof(Transform);

        [SerializeField]
        protected bool isLocal;
        [SerializeField]
        private Color gizmoColor;
        [SerializeField]
        private int resolution = 10;
        [SerializeField]
        private PathMode pathMode = PathMode.Full3D;
        [SerializeField]
        private PathType pathType = PathType.CatmullRom;

        protected override Tweener GenerateTween_Internal(GameObject target, float duration)
        {
            TweenerCore<Vector3, Path, PathOptions> tween;
            
            if (!isLocal)
                tween = target.transform.DOPath(GetPathPositions(), duration, pathType, pathMode, resolution, gizmoColor);
            else
                tween = target.transform.DOLocalPath(GetPathPositions(), duration, pathType, pathMode, resolution, gizmoColor);

            return tween;
        }


        protected abstract Vector3[] GetPathPositions();
    }
}
