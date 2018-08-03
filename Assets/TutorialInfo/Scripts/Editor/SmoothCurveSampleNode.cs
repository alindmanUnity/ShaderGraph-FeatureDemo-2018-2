using System.Reflection;

namespace UnityEditor.ShaderGraph
{
    [Title("Math", "Wave", "Smooth Curve Sample")]
    class SmoothCurveSampleNode : CodeFunctionNode
    {
        public SmoothCurveSampleNode()
        {
            name = "Smooth Curve Sample";
        }

        public override string documentationURL
        {
            get { return "https://github.com/Unity-Technologies/ShaderGraph/wiki/Smooth-Curve-Node"; }
        }

        protected override MethodInfo GetFunctionToConvert()
        {
            return GetType().GetMethod("SmoothCurveSample", BindingFlags.Static | BindingFlags.NonPublic);
        }

        static string SmoothCurveSample(
            [Slot(0, Binding.None)] DynamicDimensionVector In,
            [Slot(1, Binding.None)] out DynamicDimensionVector Out)
        {
            return
                @"
{
    Out = In * In *( 3.0 - 2.0 * In );
}
";
        }
    }
}
