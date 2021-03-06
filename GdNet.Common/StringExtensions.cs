﻿using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace GdNet.Common
{
    /// <summary>
    /// Extension methods for String
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Trim a string
        /// </summary>
        public static string TrimSafe(this string input)
        {
            return (input == null) ? null : input.Trim();
        }

        /// <summary>
        /// Build a safe file name from a given string candidate. The result file will have no space.
        /// </summary>
        public static string GetSafeFileName(this string input, string spaceReplacement = "-")
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            var fileName = input.Trim().Replace(" ", spaceReplacement);

            var ignoreCharacters = new List<char>(Path.GetInvalidFileNameChars())
            {
                '#',
                '?',
                '&'
            };

            return string.Join(string.Empty, fileName.Where(x => !ignoreCharacters.Contains(x)));
        }

        /// <summary>
        /// Convert unicode string to ascii
        /// </summary>
        public static string ToVietnameseNoSign(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            var expectedChars = input.Normalize(NormalizationForm.FormD)
                .Where(x => CharUnicodeInfo.GetUnicodeCategory(x) != UnicodeCategory.NonSpacingMark);

            return new string(expectedChars.ToArray()).Replace("đ", "d").Replace("Đ", "D");
        }
    }
}