#if TMP_ENABLED

using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;

namespace BrunoMikoski.AnimationSequencer
{

    [Serializable]
    public sealed class TMP_TextDOTweenAction : DOTweenActionBase
    {
        public override Type TargetComponentType => typeof(TMP_Text);
        public override string DisplayName => "TMP Text";

        [SerializeField]
        private string text;
        [SerializeField]
        private bool richText;
        [SerializeField]
        private ScrambleMode scrambleMode = ScrambleMode.None;
        
        private TMP_Text tmpTextComponent;

        protected override Tweener GenerateTween_Internal(GameObject target, float duration)
        {
            if (tmpTextComponent == null)
            {
                tmpTextComponent = target.GetComponent<TMP_Text>();
                if (tmpTextComponent == null)
                {
                    Debug.LogError($"{target} does not have {TargetComponentType} component");
                    return null;
                }
            }

            TweenerCore<string, string, StringOptions> tween = tmpTextComponent.DOText(text, duration, richText, scrambleMode);
            return tween;
        }


    }
}
#endif
