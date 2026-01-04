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
                Marshal.GetNativeVariantForObject(Filter ?? string.Empty, args.OutValue);
            }
            else
            {
                // Handle both null and string input values
                string text = args.InValue as string;
                string newFilter = text?.Trim() ?? string.Empty;

                if (newFilter != Filter)
                {
                    Filter = newFilter;
                    FilterChanged?.Invoke(this, Filter);
                }
            }
        }

        public static event EventHandler<string> FilterChanged;
    }
}
