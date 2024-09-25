using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.CommonEnum
{
    public static class LOV
    {
        public  enum LOVId
        {
            
            DepartmentType = 1,
            RequestType = 3,
            WorkStatus = 7,
            Severity = 29,
            Rating = 34,
            Status = 10,
            StatusActive = 11,
            StatusInactive = 12,
            QuestionType = 13,
            MCQ = 14,
            OneTo10Rating = 15,
            Summary = 16,
            Abstract = 17,
            MCQwithMultipleChoice = 18,
            EditableType = 19,
            Editable = 20,
            NotEditable = 21,
            SurveyStatus = 22,
            SurveyStatus_Pending = 23,
            SurveyStatus_Incomplete = 24,
            SurveyStatus_Complete = 25,
            RatingTable = 42,
            MarkingTable = 43,
            Reopened = 44,

        }


    }
}