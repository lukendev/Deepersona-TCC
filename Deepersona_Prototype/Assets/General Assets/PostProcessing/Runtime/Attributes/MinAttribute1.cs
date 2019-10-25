namespace UnityEngine.PostProcessing
{
    public sealed class MinAttribute1 : PropertyAttribute
    {
        public readonly float min;

        public MinAttribute1(float min)
        {
            this.min = min;
        }
    }
}
