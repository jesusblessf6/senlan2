namespace Utility.QueryManagement
{
    public class QueryElement
    {
        public string FieldName { get; set; }
        public object Value { get; set; }
        public Operator Operator { get; set; }
        public bool WithLeftBracket { get; set; }
        public bool WithRightBracket { get; set; }
        public Relation RelationToLeft { get; set; }

        public QueryElement()
        {
            FieldName = string.Empty;
            Value = null;
            Operator = Operator.Equal;
            WithLeftBracket = false;
            WithRightBracket = false;
            RelationToLeft = Relation.And;
        }
    }
}
