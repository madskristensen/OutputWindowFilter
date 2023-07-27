using System.Runtime.InteropServices;

namespace OutputWindowFilter
{
    [Command(PackageIds.Filter)]
    internal sealed class FilterCommand : BaseCommand<FilterCommand>
    {
        public static string Filter { get; private set; }

        protected override void Execute(object sender, EventArgs e)
        {
            OleMenuCmdEventArgs args = (OleMenuCmdEventArgs)e;

            if (args.OutValue != IntPtr.Zero)
            {
                Marshal.GetNativeVariantForObject(Filter, args.OutValue);
            }
            else if (args.InValue is string text && text != Filter)
            {
                Filter = text.Trim();
                FilterChanged?.Invoke(this, Filter);
            }
        }

        public static event EventHandler<string> FilterChanged;
    }
}
