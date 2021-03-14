using System;
using System.Diagnostics.CodeAnalysis;

namespace meal_planner.Units
{
    public abstract class IUnit : IEquatable<IUnit>
    {
        public abstract string Symbol();

        //TODO: test all this equality
        protected abstract bool EqualsImplementation(IUnit other);

        public bool Equals([AllowNull] IUnit other)
        {
            return !(other is null)
                && EqualsImplementation(other);
        }

        #region Overriding object

        public override bool Equals(object obj)
        {
            return obj is IUnit
                && EqualsImplementation(obj as IUnit);
        }

        public override int GetHashCode()
        {
            return Symbol()
                .GetHashCode();
        }

        public static bool operator ==(IUnit a, IUnit b)
        {
            return a.EqualsImplementation(b);
        }

        public static bool operator !=(IUnit a, IUnit b)
        {
            return !a.EqualsImplementation(b);
        }

        #endregion
    }
}
