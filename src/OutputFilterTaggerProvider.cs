using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;

namespace OutputWindowFilter
{
    [Export(typeof(IViewTaggerProvider))]
    [ContentType("Output")]
    [TagType(typeof(IClassificationTag))]
    public class OutputFilterTaggerProvider : IViewTaggerProvider
    {
        [Import]
        internal IClassificationTypeRegistryService _classificationRegistry = null;

        public ITagger<T> CreateTagger<T>(ITextView textView, ITextBuffer buffer) where T : ITag
        {
            OutputFilterTagger tagger = new(textView as IWpfTextView, _classificationRegistry);
            return buffer.Properties.GetOrCreateSingletonProperty(() => tagger) as ITagger<T>;
        }
    }
}
