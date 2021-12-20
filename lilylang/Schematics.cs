using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fonder.Lilian.New
{
    public static partial class Interpreter
    {
        public static class Schematics
        {
            public class Feature
            {
                public Feature(params IFeaturePlaceholder[] featurePlaceholders)
                {
                    Structure = featurePlaceholders;
                }
                public string Name { get; }
                public string Description { get; }

                public IFeaturePlaceholder[] Structure { get; }

                public interface IFeaturePlaceholder
                {

                }

                public struct StringFeaturePlaceholder : IFeaturePlaceholder
                {
                    public StringFeaturePlaceholder(string str)
                    {
                        Literal = str;
                    }
                    public string Literal { get; }
                }

                public struct AnyContentFeaturePlaceholder : IFeaturePlaceholder
                {

                }

                public struct ConditionalContentFeaturePlaceholder : IFeaturePlaceholder
                {

                }

                [Flags]
                public enum FeaturePlaceholderType
                {
                    Fixed = 0,
                    Value = 1,
                    Condition = 2,
                    Switch = 4,
                }

                public struct EitherOneOfThese
                {
                    public EitherOneOfThese(params string[] things)
                    {
                        Switches = things;
                    }
                    public string[] Switches { get; }
                }
            }
        }
    }
}
