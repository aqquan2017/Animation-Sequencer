using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace BrunoMikoski.AnimationSequencer
{
    [Serializable]
    public sealed class FillImageDOTweenAction : DOTweenActionBase
    {

        public override Type TargetComponentType => typeof(Image);
        public override string DisplayName => "Fill Amount";

        [SerializeField, Range(0, 1)]
        private float fillAmount;
        private Image image;

        protected override Tweener GenerateTween_Internal(GameObject target, float duration)
        {
            if (image == null)
            {
                image = target.GetComponent<Image>();
                if (image == null)
                {
                    Debug.LogError($"{target} does not have {TargetComponentType} component");
                    return null;
                }
            }
            
            TweenerCore<float, float, FloatOptions> tween = image.DOFillAmount(fillAmount, duration);
            return tween;
        }

    }
}
