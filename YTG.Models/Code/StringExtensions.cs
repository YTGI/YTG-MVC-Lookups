// --------------------------------------------------------------------------------
/*  Copyright © 2020, Yasgar Technology Group, Inc.

    Purpose: String Extension Methods

    Description: Various string extension methods for use throughout applications

*/
// --------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Text;

namespace YTG.Models.Code
{
    public static class StringExtensions
    {

        /// <summary>
        /// Convert a string to a Decimal, return null if fails
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal? ToDecimal(this string value)
        {
            if (decimal.TryParse(value, out decimal decItem))
            { return decItem; }
            else
            { return null; }

        }

        /// <summary>
        /// Convert a string to a boolean, return false unless value is "True", "true" or "1"
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ToBoolean(this string value)
        {
            if (value == null) { return false; }
            if (value.ToLower() == "true" || value == "1" || value == "yes")
            { return true; }
            else
            { return false; }
        }


        /// <summary>
        /// Convert a string in CCYYMMDD format to a valid date
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToDateFromCCYYMMDD(this string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (value == "99999999")
                {
                    return DateTime.MaxValue;
                }
                else
                {
                    string _value = value.Trim();
                    if (_value.Trim().Length == 8)
                    {
                        int.TryParse(_value.Substring(0, 4), out int year);
                        int.TryParse(_value.Substring(4, 2), out int month);
                        int.TryParse(_value.Substring(6, 2), out int day);

                        DateTime datItem = new DateTime(year, month, day);
                        return datItem;
                    }
                }
            }

            return DateTime.MinValue;

        }

        /// <summary>
        /// Convert a string in MM/DD/CCYY format to a valid date
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToDateFromString(this string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if ((value == "99999999") || (value == "99/99/9999"))
                {
                    return DateTime.MaxValue;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        DateTime.TryParse(value, out DateTime _value);
                        return _value;
                    }
                    else
                    {
                        return DateTime.MinValue;
                    }
                }
            }

            return DateTime.MinValue;

        }


        /// <summary>
        /// Trim a string down to a particular size
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Trim(this string value, int p_MaxLength)
        {
            try
            {
                if (value != null)
                {
                    return value.Substring(0, Math.Min(p_MaxLength, value.Length));
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Remove special characters from a string with option to retain Dashes and Hash signs
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveSpecialChars(this string value, bool p_DashOkay = false, bool p_HashOkay = false)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                if (value != null)
                {
                    if (p_DashOkay && p_HashOkay)
                    {
                        foreach (char c in value)
                        {
                            if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '-' || c == '#' || c == ' ')
                            {
                                sb.Append(c);
                            }
                        }
                    }
                    else if (p_DashOkay && p_HashOkay == false)
                    {
                        foreach (char c in value)
                        {
                            if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '-' || c == ' ')
                            {
                                sb.Append(c);
                            }
                        }
                    }
                    else if (p_DashOkay == false && p_HashOkay)
                    {
                        foreach (char c in value)
                        {
                            if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '#' || c == ' ')
                            {
                                sb.Append(c);
                            }
                        }
                    }
                    else if (!p_DashOkay && !p_HashOkay)
                    {
                        foreach (char c in value)
                        {
                            if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == ' ')
                            {
                                sb.Append(c);
                            }
                        }
                    }

                }

                return sb.ToString();

            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Strip spaces from a string. Adding StripInternal param of true will strip spaces from within the string as well
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="p_Input"></param>
        /// <param name="p_StripInternal"></param>
        /// <returns></returns>
        public static string RemoveSpaces(this string value, bool StripInternal = false)
        {
            if (!string.IsNullOrWhiteSpace(value))
                if (StripInternal)
                {
                    return new string(value.ToCharArray()
                                        .Where(c => !Char.IsWhiteSpace(c))
                                        .ToArray());
                }
                else
                {
                    return value.Trim();
                }
            else
            {
                return string.Empty;
            }
        }


    }
}
