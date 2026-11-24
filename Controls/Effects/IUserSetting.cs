namespace MarathonSoundGen.Controls.Effects
{
    public interface IUserSetting
    {
        string EffectName { get; }
        string ParamName { get; }
        Type ValueType { get; }
        object UntypedValue { get; set; }
    }
}
