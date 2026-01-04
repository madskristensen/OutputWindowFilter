using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace OutputWindowFilter
{
    public class ClassificationTypeDefinitions
    {
        public const string Invisible = "OutputWindowFilter.Invisible";
        public const string Highlight = "OutputWindowFilter.Highlight";

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(Invisible)]
        public static ClassificationTypeDefinition InvisibleDefinition { get; set; }

        [Name(Invisible)]
        [UserVisible(false)]
        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = Invisible)]
        [Order(Before = Priority.Default)]
        public sealed class InvisibleFormat : ClassificationFormatDefinition
        {
            public InvisibleFormat()
            {
                FontRenderingSize = 0.0001;
                FontHintingSize = 0.0001;
                ForegroundColor = System.Windows.Media.Colors.Transparent;
            }
        }

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(Highlight)]
        public static ClassificationTypeDefinition HighlightDefinition { get; set; }

        [Name(Highlight)]
        [UserVisible(false)]
        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = Highlight)]
        [Order(Before = Priority.Default)]
        public sealed class HighlightFormat : ClassificationFormatDefinition
        {
            public HighlightFormat()
            {
                ForegroundBrush = System.Windows.Media.Brushes.White;
                BackgroundBrush = System.Windows.Media.Brushes.DarkOrange;
            }
        }
    }
}
