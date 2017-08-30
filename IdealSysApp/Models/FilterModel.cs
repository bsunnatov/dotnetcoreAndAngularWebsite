using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace IdealSysApp.Models
{
  [DataContract]
  public class Filter
  {
    public int take { get; set; }
    public int skip { get; set; }  /// <summary>
                                   /// Gets or sets the name of the sorted field (property). Set to <c>null</c> if the <c>Filters</c> property is set.
                                   /// </summary>
    [DataMember(Name = "field")]
    public string Field { get; set; }
    /// <summary>
    /// default -nothing,0-int,1-guid
    /// </summary>
    [DataMember(Name = "type")]
    public string Type { get; set; }
    /// <summary>
    /// Gets or sets the filtering operator. Set to <c>null</c> if the <c>Filters</c> property is set.
    /// </summary>
    [DataMember(Name = "operator")]
    public string Operator { get; set; }

    /// <summary>
    /// Gets or sets the filtering value. Set to <c>null</c> if the <c>Filters</c> property is set.
    /// </summary>
    [DataMember(Name = "value")]
    public object Value { get; set; }

    /// <summary>
    /// Gets or sets the filtering logic. Can be set to "or" or "and". Set to <c>null</c> unless <c>Filters</c> is set.
    /// </summary>
    [DataMember(Name = "logic")]
    public string Logic { get; set; }

    /// <summary>
    /// Gets or sets the child filter expressions. Set to <c>null</c> if there are no child expressions.
    /// </summary>
    [DataMember(Name = "filters")]
    public IEnumerable<Filter> Filters { get; set; }

    /// <summary>
    /// Mapping of Kendo DataSource filtering operators to Dynamic Linq
    /// </summary>
    private static readonly IDictionary<string, string> operators = new Dictionary<string, string>
    {
        {"eq", "="},
        {"neq", "!="},
        {"lt", "<"},
        {"lte", "<="},
        {"gt", ">"},
        {"gte", ">="},
        {"startswith", "StartsWith"},
        {"endswith", "EndsWith"},
        {"contains", "Contains"}
    };

    /// <summary>
    /// Get a flattened list of all child filter expressions.
    /// </summary>
    public IList<Filter> All()
    {
      var filters = new List<Filter>();

      Collect(filters);

      return filters;
    }

    private void Collect(IList<Filter> filters)
    {
      if (Filters != null && Filters.Any())
      {
        foreach (Filter filter in Filters)
        {

          if (filter.Type == "guid")
          {
            filter.Value = Guid.Parse(filter.Value.ToString());
          }
          filters.Add(filter);

          filter.Collect(filters);
        }
      }
      else
      {
        filters.Add(this);
      }
    }

    /// <summary>
    /// Converts the filter expression to a predicate suitable for Dynamic Linq e.g. "Field1 = @1 and Field2.Contains(@2)"
    /// </summary>
    /// <param name="filters">A list of flattened filters.</param>
    public string ToExpression(IList<Filter> filters)
    {
      if (Filters != null && Filters.Any())
      {
        return "(" + String.Join(" " + Logic + " ", Filters.Select(filter => filter.ToExpression(filters)).ToArray()) + ")";
      }

      int index = filters.IndexOf(this);

      string comparison = operators[Operator];

      if (comparison == "StartsWith" || comparison == "EndsWith" || comparison == "Contains")
      {
        return String.Format("{0}.{1}(@{2})", Field, comparison, index);
      }

      return String.Format("{0} {1} @{2}", Field, comparison, index);
    }
  }
  public class DataSourceRequest
  {
    public DataSourceRequest()
    {
      Take = 10;
      Skip = 0;
    }
    public int Take { get; set; }
    public int Skip { get; set; }
    public long ParentId { get; set; }
    public IEnumerable<Sort> Sort { get; set; }
    public Filter Filter { get; set; }
  }
  public class Sort
  {
    /// <summary>
    /// Gets or sets the name of the sorted field (property).
    /// </summary>
    [DataMember(Name = "field")]
    public string Field { get; set; }

    /// <summary>
    /// Gets or sets the sort direction. Should be either "asc" or "desc".
    /// </summary>
    [DataMember(Name = "dir")]
    public string Dir { get; set; }

    /// <summary>
    /// Converts to form required by Dynamic Linq e.g. "Field1 desc"
    /// </summary>
    public string ToExpression()
    {
      return Field + " " + Dir;

    }
  }
  public class DataSourceResult
  {
    /// <summary>
    /// Represents a single page of processed data.
    /// </summary>
    public IEnumerable Data { get; set; }

    /// <summary>
    /// The total number of records available.
    /// </summary>
    public int Total { get; set; }
  }
}
