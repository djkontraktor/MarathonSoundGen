namespace MarathonSoundGen.Controls.Effects
{
    public interface IEffectParameter
    {
        string EffectName { get; }
        string Name { get; }
        Type ValueType { get; }
        Control Control { get; set; }
        object UntypedDefaultValue { get; set; }
        object UntypedMinValue { get; set; }
        object UntypedMaxValue { get; set; }
    }
}
