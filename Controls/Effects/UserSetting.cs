namespace MarathonSoundGen.Controls.Effects
{
    public class UserSetting<T> : IUserSetting
    {
        public string EffectName { get; set; }

        public string ParamName { get; set; }

        public T Value { get; set; }

        public Type ValueType
        {
            get { return typeof(T); }
        }

        public object UntypedValue
        {
            get
            {
                return Value;
            }
            set
            {
                Value = SetValue(value);
            }
        }

        public UserSetting(string effectName, string paramName, T value)
        {
            EffectName = effectName;
            ParamName = paramName;
            Value = value;
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
