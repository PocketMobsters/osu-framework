// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Transforms;

namespace osu.Framework.Graphics.UserInterface
{
    /// <summary>
    /// A drawable object that supports counting to values.
    /// </summary>
    public class Counter : CompositeDrawable
    {
        private double count;
        /// <summary>
        /// The current count.
        /// </summary>
        protected double Count
        {
            get { return count; }
            private set
            {
                if (count == value)
                    return;
                count = value;

                OnCountChanged(count);
            }
        }

        /// <summary>
        /// Invoked when <see cref="Count"/> has changed.
        /// </summary>
        protected virtual void OnCountChanged(double count) { }

        public TransformSequence<Counter> CountTo(double endCount, double duration = 0, Easing easing = Easing.None)
            => this.TransformTo(nameof(Count), endCount, duration, easing);
    }

    public static class CounterTransformSequenceExtensions
    {
        public static TransformSequence<Counter> CountTo(this TransformSequence<Counter> t, double endCount, double duration = 0, Easing easing = Easing.None)
            => t.Append(o => o.CountTo(endCount, duration, easing));
    }
}
