using System.ComponentModel.Composition;
using System.Windows.Media;
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
                ForegroundColor = Colors.Transparent;
            }
        }

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(Highlight)]
        public static ClassificationTypeDefinition HighlightDefinition { get; set; }

        [Name(Highlight)]
        [UserVisible(true)]
        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = Highlight)]
        [Order(Before = Priority.Default)]
        public sealed class HighlightFormat : ClassificationFormatDefinition
        {
            public HighlightFormat()
            {
                DisplayName = "Output Filter - Match Highlight";
                // Use yellow background similar to VS find highlight - works on both light and dark themes
                BackgroundColor = Color.FromRgb(255, 235, 0);
                // Don't set foreground - let it inherit from the text, ensuring readability
            }
        }
    }
}
