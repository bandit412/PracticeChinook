using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BusinessRuleException
/// The contents that will be placed in an instance of
/// this class will come from user code within your
/// application source, i.e. BLL Business Rule Exceptions.
/// </summary>
[Serializable] // for I/O and data transfer
public class BusinessRuleException : Exception
{
    public List<string> RuleDetails { get; set; }
    public BusinessRuleException(string message, List<string> reasons)
        : base(message)
    {
        this.RuleDetails = reasons;
    }
}