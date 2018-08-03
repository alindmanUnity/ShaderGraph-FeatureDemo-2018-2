using System.Reflection;

namespace UnityEditor.ShaderGraph
{
    [Title("Math", "Wave", "Triangle Wave Sample")]
    class TriangleWaveSampleNode : CodeFunctionNode
    {
        public TriangleWaveSampleNode()
        {
            name = "Triangle Wave Sample";
        }

        public override string documentationURL
        {
            get { return "https://github.com/Unity-Technologies/ShaderGraph/wiki/Triangle-Wave-Node"; }
        }

        protected override MethodInfo GetFunctionToConvert()
        {
            return GetType().GetMethod("TriangleWaveSample", BindingFlags.Static | BindingFlags.NonPublic);
        }

        static string TriangleWaveSample(
            [Slot(0, Binding.None)] DynamicDimensionVector In,
            [Slot(1, Binding.None)] out DynamicDimensionVector Out)
        {
            return
                @"
{
    Out = abs( frac( In + 0.5 ) * 2.0 - 1.0 );
}
";
        }
    }
}
