namespace MarathonSoundGen.Controls.Effects
{
    public class EffectParameter<T> : IEffectParameter
    {
        public string EffectName { get; set; }

        public string Name { get; set; }

        public T DefaultValue { get; set; }

        public T MinValue { get; set; }

        public T MaxValue { get; set; }

        public Control Control { get; set; }

        public Type ValueType
        {
            get { return typeof(T); }
        }

        public object UntypedDefaultValue
        {
            get
            {
                return DefaultValue;
            }
            set
            {
                DefaultValue = SetValue(value);
            }
        }

        public object UntypedMinValue
        {
            get
            {
                return MinValue;
            }
            set
            {
                MinValue = SetValue(value);
            }
        }

        public object UntypedMaxValue
        {
            get
            {
                return MaxValue;
            }
            set
            {
                MaxValue = SetValue(value);
            }
        }

        public EffectParameter(string effectName, string name, T defaultValue, T minValue, T maxValue)
        {
            EffectName = effectName;
            Name = name;
            DefaultValue = defaultValue;
            MinValue = minValue;
            MaxValue = maxValue;
        }

        private T SetValue(object val)
        {
            if (val == null)
            {
                if (default(T) != null)
                {
                    throw new ArgumentNullException(nameof(val));
                }
                return default(T);
            }

            if (!(val is T))
            {
                throw new ArgumentException("Value must be of type " + typeof(T).FullName, nameof(val));
            }

            return (T)val;
        }
    }
}
