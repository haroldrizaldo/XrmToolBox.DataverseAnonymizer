using System.Text.RegularExpressions;

namespace XrmToolBox.DataverseAnonymizer.Rules
{
    public class RegexMaskRule
    {
        // Regular expression pattern to match the parts of the string that should be masked
        public string Pattern { get; set; }

        // Character to use for masking
        public char MaskingCharacter { get; set; } = '*';

        // Method to apply the regex mask to a given input string
        public string ApplyMask(string input)
        {
            if (string.IsNullOrEmpty(Pattern) || string.IsNullOrEmpty(input))
            {
                return input;
            }

            // Replace matches with masking characters
            return Regex.Replace(input, Pattern, match => new string(MaskingCharacter, match.Length));
        }

        public override string ToString() => $"Pattern: {Pattern}, MaskingCharacter: {MaskingCharacter}";
    }
}
