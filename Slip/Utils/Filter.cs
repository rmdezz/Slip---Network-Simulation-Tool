namespace Slip.Utils
{
    internal static class Filter
    {
        internal static bool ValidateFilter(string filter)
        {
            bool filterValid = WinDivert.CheckFilter(filter);
            return filterValid;
        }
        
        internal static string GetFilter(bool isCustomCheckboxChecked, string customFilter, string presetFilter)
        {
            if (isCustomCheckboxChecked) return customFilter;
            return presetFilter;
        }
    }
}