using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility.QueryManagement
{
    public class QueryManager
    {
        private static readonly Dictionary<Operator, string> StrOperators;
        private static readonly Dictionary<Relation, string> StrRelations;

        static QueryManager()
        {
            StrOperators = new Dictionary<Operator, string>
                               {
                                   {Operator.Equal, "="},
                                   {Operator.GreaterEqualThan, ">="},
                                   {Operator.GreaterThan, ">"},
                                   {Operator.LessEqualThan, "<="},
                                   {Operator.LessThan, "<"},
                                   {Operator.IsNull, "Is Null"},
                                   {Operator.IsNotNull, "Is Not Null"},
                                   {Operator.Like, "like"}
                               };

            StrRelations = new Dictionary<Relation, string>
                               {
                                   {Relation.And, "and"},
                                   {Relation.Empty, ""},
                                   {Relation.Or, "or"}
                               };
        }

        /// <summary>
        /// Build the query string and parameters
        /// </summary>
        /// <param name="elements">query elements</param>
        /// <param name="queryStr"></param>
        /// <param name="parameters"></param>
        public static void BuildQueryStrAndParams(List<QueryElement> elements, out string queryStr,
                                                  out List<object> parameters)
        {
            parameters = new List<object>();
            var sb = new StringBuilder();

            if (elements != null && elements.Count > 0)
            {
                //Empty the first "Relation to Left"
                elements[0].RelationToLeft = Relation.Empty;

                //Validate the elements
                if (elements.Count(o => o.WithLeftBracket) != elements.Count(o => o.WithRightBracket))
                {
                    throw new Exception("查询语句错误，左右括号不匹配！");
                }

                if (elements.Count(o => o.RelationToLeft == Relation.Empty) > 1)
                {
                    throw new Exception("查询语句错误，缺少关系连接词（and/or）！");
                }

                if (elements.Count(
                        o => (o.Operator == Operator.IsNotNull || o.Operator == Operator.IsNull) && o.Value != null) > 0)
                {
                    throw new Exception("查询语句错误，\"Is Null\" 或 \"Is Not Null\"语句中的Value必须为空！");
                }

                //Build the query string
                int i = 1;
                foreach (var queryElement in elements)
                {
                    //Relation
                    sb.Append(" ");
                    sb.Append(StrRelations[queryElement.RelationToLeft]);
                    sb.Append(" ");

                    //Left bracket
                    if (queryElement.WithLeftBracket)
                    {
                        sb.Append("(");
                    }

                    //Field
                    sb.Append("it." + queryElement.FieldName);

                    //Operator
                    sb.Append(" " + StrOperators[queryElement.Operator] + " ");

                    //Parameter and Placeholder
                    if (queryElement.Value != null)
                    {
                        sb.AppendFormat("@p{0}", i++);
                        if (queryElement.Operator == Operator.Like)
                        {
                            queryElement.Value = "%" + ((string) queryElement.Value) + "%";
                        }
                        parameters.Add(queryElement.Value);
                    }

                    //Right Bracket
                    if (queryElement.WithRightBracket)
                    {
                        sb.Append(")");
                    }
                }
            }

            queryStr = sb.ToString().Trim();

            if (string.IsNullOrWhiteSpace(queryStr))
            {
                queryStr = "1=1";
            }
        }
    }
}
