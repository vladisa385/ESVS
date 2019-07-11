using System;
using System.Collections.Generic;
using System.Linq;
using ESVS.Application.Extensions;
namespace ESVS.Application.Infrastructure.Query
{
    public class ListOptions
    {
        public ListOptions() : this(PageSizeValue.Default) { }
        public ListOptions(PageSizeValue pageSize) : this(pageSize.AsInt32()) { }
        public ListOptions(int? pageSize) { PageSize = pageSize; }
        public int? PageSize { get; set; }

        public int Page { get; set; }

        /// <summary>
        /// Sorting fields.
        /// Formats:
        ///     1. Sort ascending: "propName" / "+propName"
        ///     2. Sort descending: "-propName"
        ///     3. Multiple: "prop1Name, -prop2Name"
        /// </summary>
        public string Sort { get; set; } = "Id";

        public IEnumerable<SortDesc> GetSorts()
        {
            if (string.IsNullOrWhiteSpace(Sort)) yield break;
            foreach (string str in Sort.Split(new[] { ',', ' ', ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var sd = SortDesc.Parse(str);
                yield return sd;
            }
        }

        public IQueryable<T> ApplySort<T>(IQueryable<T> query, string defaultSort = null)
        {
            var sortDescEnumerator = GetSorts().GetEnumerator();

            if (sortDescEnumerator.MoveNext())
            {
                try
                {
                    // extensions from https://gist.github.com/zaverden/c2d611f33f60cbe8234b420d87671c10
                    IOrderedQueryable<T> orderedQuery = query.OrderBy(sortDescEnumerator.Current.PropertyName, sortDescEnumerator.Current.Desc);

                    while (sortDescEnumerator.MoveNext())
                    {
                        orderedQuery = orderedQuery.ThenBy(sortDescEnumerator.Current.PropertyName, sortDescEnumerator.Current.Desc);
                    }

                    return orderedQuery;
                }
                catch (MissingMemberException exc)
                {
                    throw new WrongSortPropertyException(sortDescEnumerator.Current.PropertyName, exc);
                }
            }

            if (defaultSort != null)
            {
                var ds = SortDesc.Parse(defaultSort);
                IOrderedQueryable<T> orderedQuery = query.OrderBy(ds.PropertyName, ds.Desc);
                return orderedQuery;
            }

            return query;
        }

        public IQueryable<T> ApplyPaging<T>(IQueryable<T> query)
        {
            if (PageSize == null)
            {
                return query;
            }

            int skip = PageSize.Value * (Page - 1);

            if (skip > 0)
            {
                query = query.Skip(skip);
            }

            query = query.Take(PageSize.Value);
            return query;
        }

        public int CalculatePagesCount(int itemsCount)
        {
            if (itemsCount == 0 || PageSize == null)
            {
                return 1;
            }

            int pageSize = PageSize.Value;
            int pagesCount = itemsCount / pageSize + (itemsCount % pageSize == 0 ? 0 : 1);

            return pagesCount;
        }
    }

    public class SortDesc
    {
        public string PropertyName { get; set; }

        public bool Desc { get; set; }

        public static SortDesc Parse(string str)
        {
            var sd = new SortDesc { PropertyName = str };

            if (str[0] != '+' && str[0] != '-') return sd;
            sd.Desc = str[0] == '-';
            sd.PropertyName = str.Substring(1);

            return sd;
        }
    }

    /// <summary>
    /// Predefined values for ListOptions.Count
    /// Allows integer values.
    /// </summary>
    public enum PageSizeValue
    {
        NoLimit = -0xAAAA,
        First = 1,
        Default = 10
    }

    /// <summary>
    /// Extensions for enum Zerobased.CountValue
    /// </summary>
    public static class PageSizeValueExtensions
    {
        /// <summary>
        /// Convert Zerobased.CountValue to System.Int32 value.
        /// </summary>
        /// <param name="topValue">Value to convert.</param>
        /// <returns>
        /// Returns <value>Defaul</value> if value less then <value>1</value>.
        /// Returns <value>NULL</value> if <paramref name="topValue"/> is <value>NoLimit</value>.
        /// </returns>
        public static int? AsInt32(this PageSizeValue topValue)
        {
            int? value = null;

            if (topValue != PageSizeValue.NoLimit)
            {
                value = (int)(topValue < PageSizeValue.First ? PageSizeValue.Default : topValue);
            }

            return value;
        }
    }

    public class WrongSortPropertyException : Exception
    {
        public WrongSortPropertyException(string sortProperty, Exception innerException = null)
            : base($"Property {sortProperty} does not exists in sorted entity.", innerException)
        {
            SortProperty = sortProperty;
        }

        public string SortProperty { get; }
    }
}