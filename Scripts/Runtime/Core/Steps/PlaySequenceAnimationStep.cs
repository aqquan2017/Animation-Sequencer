﻿using System;
using DG.Tweening;
using UnityEngine;

namespace BrunoMikoski.AnimationSequencer
{
    [Serializable]
    public sealed class PlaySequenceAnimationStep : AnimationStepBase
    {
        public override string DisplayName => "Play Sequence";

        [SerializeField]
        private AnimationSequencerController sequencer;

        public override void AddTweenToSequence(Sequence animationSequence)
        {
            Sequence sequence = sequencer.GenerateSequence();
            sequence.AppendInterval(Delay);
            if (FlowType == FlowType.Join)
                animationSequence.Join(sequence);
            else
                animationSequence.Append(sequence);
        }

        public override string GetDisplayNameForEditor(int index)
        {
            string display = "NULL";
            if (sequencer != null)
                display = sequencer.name;
            return $"{index}. Play {display} Sequence";
        }

        public void SetTarget(AnimationSequencerController newTarget)
        {
            sequencer = newTarget;
        }
    }
}
