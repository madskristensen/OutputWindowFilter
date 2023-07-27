using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;

namespace OutputWindowFilter
{
    public class OutputFilterTagger : ITagger<IClassificationTag>, IDisposable
    {
        private readonly IWpfTextView _view;
        private readonly IClassificationType _invisible;
        private readonly IClassificationType _highlight;

        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

        public OutputFilterTagger(IWpfTextView view, IClassificationTypeRegistryService classificationRegistry)
        {
            _view = view;
            _invisible = classificationRegistry.GetClassificationType(ClassificationTypeDefinitions.Invisible);
            _highlight = classificationRegistry.GetClassificationType(ClassificationTypeDefinitions.Highlight);
            FilterCommand.FilterChanged += OnFilterChanged;
        }

        private void OnFilterChanged(object sender, string e)
        {
            _view.ViewScroller.EnsureSpanVisible(new SnapshotSpan(_view.TextBuffer.CurrentSnapshot, 0, 0));
            SnapshotSpan span = new(_view.TextBuffer.CurrentSnapshot, 0, _view.TextBuffer.CurrentSnapshot.Length);
            TagsChanged?.Invoke(this, new SnapshotSpanEventArgs(span));
        }

        public IEnumerable<ITagSpan<IClassificationTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            if (string.IsNullOrEmpty(FilterCommand.Filter) || spans[0].IsEmpty)
            {
                yield break;
            }

            foreach (SnapshotSpan span in spans)
            {
                string text = span.GetText();
                MatchCollection matches = Regex.Matches(text, FilterCommand.Filter, RegexOptions.IgnoreCase);

                if (matches.Count == 0)
                {
                    yield return new TagSpan<IClassificationTag>(span, new ClassificationTag(_invisible));
                }
                else
                {
                    foreach (Match match in matches)
                    {
                        SnapshotSpan matchSpan = new(span.Snapshot, span.Start + match.Index, match.Length);
                        yield return new TagSpan<IClassificationTag>(matchSpan, new ClassificationTag(_highlight));
                    }
                }
            }
        }

        public void Dispose()
        {
            FilterCommand.FilterChanged -= OnFilterChanged;
        }
    }
}
